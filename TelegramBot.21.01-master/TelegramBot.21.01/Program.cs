using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;
using GraphQL.Common.Request;
using GraphQL.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Threading.Tasks;
using System.Text;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.InputFiles;

namespace TelegramBotApp
{
    class Program
    {
        static TelegramBotClient bot;

        static GraphQLClient graphClient;

        static DefaultContractResolver contractResolver;

        static JsonSerializerSettings jsonSerializerSettings;

        static void Main(string[] args)
        {        
            bot = new TelegramBotClient(ConfigurationManager.AppSettings["botKey"]);
   
            bot.OnMessage += BotOnMessageReceived;
            bot.OnInlineQuery += Bot_OnInlineQuery;
            bot.OnCallbackQuery += Bot_OnCallbackQuery;

            WriteBotName();

            graphClient = new GraphQLClient("https://api.kontragent.io/v3/graphql");

            contractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() };

            jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            };

            bot.StartReceiving();

            Console.ReadKey();

            bot.StopReceiving();
        }

        private static async void WriteBotName()
        {
            try
            {
                var me = await bot.GetMeAsync();
                Console.WriteLine(me.FirstName);
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
        }

        private static async Task<string> GetAccessToken(GraphQLClient graphClient, JsonSerializerSettings jsonSerializerSettings)
        {
            //Запрос для ключа
            var authotizationQuery = @"
                mutation auth {
                  authentication {
                    anonymousLogin
                  }
                }
                ";

            var request = new GraphQLRequest
            {
                Query = authotizationQuery
            };
            var finalRequest = await graphClient.PostAsync(request);

            string accessTokenJsonResult = finalRequest.GetDataFieldAs<object>("authentication").ToString();

            var accessTokenResult = JsonConvert.DeserializeObject<AuthenticationRootObject>(accessTokenJsonResult, jsonSerializerSettings);

            string accessToken = accessTokenResult.AnonymousLogin;

            return accessToken;
        }

        //Инлайн
        private static async void Bot_OnInlineQuery(object sender, InlineQueryEventArgs e)
        {
            var query = e.InlineQuery;

            if (query == null)
                return;

            Console.WriteLine($"Inline called by {query.From.FirstName} {query.From.LastName}: '{query.Query}'");

            string accessToken = await GetAccessToken(graphClient, jsonSerializerSettings);          

            var searchQuery = @"
                query search ($findString: String) {
                    search (query: $findString limit: 10) {
                        entities {
                            __typename
                            ... on Company {
                                fullName
                                shortName
                                ogrn
                                inn
                                registration{
                                  grnDate
                                }
                                terminationDate
                                address {
                                    full
                                }
                            }
                            ... on Individual {
                            firstName
                            lastName
                            middleName 
                            ogrnip
                            inn
                            registration{
                              grnDate
                            }
                            terminationDate
                            address {
                              full
                            }
                        }
                    }
                    total
                    }
                }
                ";

            graphClient.DefaultRequestHeaders.Clear();
            graphClient.DefaultRequestHeaders.Add("authorization", $"Bearer {accessToken}");
            var request = new GraphQLRequest
            {
                Query = searchQuery,
                Variables = new { findString = query.Query }
            };
            var finalRequest = await graphClient.PostAsync(request);

            string companiesFound;

            try
            {
                companiesFound = finalRequest.GetDataFieldAs<object>("search").ToString();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return;
            }

            var result = JsonConvert.DeserializeObject<RootObject>(companiesFound, jsonSerializerSettings);
            
            List<Company> companiesList = result.Entities.ToList();

            InlineQueryResultArticle[] results = new InlineQueryResultArticle[companiesList.Count];

            foreach (Company company in companiesList)
                FillNulls(company);

            //Заполнение списка результатов
            try
            {
                for (int i = 0; i < companiesList.Count; i++)
                {
                    if (companiesList[i].__typename == "Company")
                    {
                        TerminationDateNullCheck(companiesList[i], false, true);
                        results[i] = new InlineQueryResultArticle(companiesList[i].Inn + companiesList[i].Ogrn, companiesList[i].ShortName, new InputTextMessageContent("/" + companiesList[i].Inn));
                        results[i].Description = GetInlineTelegramStringRepresentation(companiesList[i], false);
                    }
                    if (companiesList[i].__typename == "Individual")
                    {
                        TerminationDateNullCheck(companiesList[i], true, true);
                        results[i] = new InlineQueryResultArticle(companiesList[i].Inn + companiesList[i].Ogrnip, @"ИП " + companiesList[i].LastName + " " + companiesList[i].FirstName + " " + companiesList[i].MiddleName, new InputTextMessageContent("/" + companiesList[i].Inn));
                        results[i].Description = GetInlineTelegramStringRepresentation(companiesList[i], true);
                    }

                    Console.WriteLine(i);
                    Console.WriteLine(results[i].Description);
                }

                await bot.AnswerInlineQueryAsync(query.Id, results);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return;
            }
        }

        private static void FillNulls(Company company)
        {
            if (company.MiddleName == null)
                company.MiddleName = "";

            if (company.ShortName == null)
                company.ShortName = company.FullName;

            if (company.Address == null)
                company.Address = new Address { Full = "Нет данных" };

            if (company.AuthorizedCapital == null)
                company.AuthorizedCapital = new AuthorizedCapital { Amount = 0 };
        }

        private static void TerminationDateNullCheck(Company company, bool isIndividual, bool isFromInline)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(Convert.ToInt32(company.Registration.GrnDate)).ToLocalTime();
            company.Registration.GrnDate = dtDateTime.ToShortDateString();
            dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

            if (!isIndividual)
            {
                if (company.TerminationDate == null)
                    company.TerminationDate = "- Организация работает";
                else
                {
                    dtDateTime = dtDateTime.AddSeconds(Convert.ToInt32(company.TerminationDate)).ToLocalTime();
                    company.TerminationDate = dtDateTime.ToShortDateString();
                    if(isFromInline)
                        company.TerminationDate = "- Закрытие: " + company.TerminationDate;
                    else
                        company.TerminationDate = "- Закрытие: " + company.TerminationDate;
                }
            }
            if (isIndividual)
            {
                if (company.TerminationDate == null)
                    company.TerminationDate = "- ИП работает";
                else
                {
                    dtDateTime = dtDateTime.AddSeconds(Convert.ToInt32(company.TerminationDate)).ToLocalTime();
                    company.TerminationDate = dtDateTime.ToShortDateString();
                    if (isFromInline)
                        company.TerminationDate = "- Закрытие: " + company.TerminationDate;
                    else
                        company.TerminationDate = "- Закрытие: " + company.TerminationDate;
                }
            }
        }

        private static string GetInlineTelegramStringRepresentation(Company company, bool isIndividual)
        {
            string representationString = "";          

            if (!isIndividual)
            {
                representationString = "ОГРН: " + company.Ogrn + " " +
                                        "- ИНН: " + company.Inn + "\n" +
                                        "Регистрация: " + company.Registration.GrnDate + " " +
                                        company.TerminationDate + "\n" +
                                        company.Address.Full;
            }
            if(isIndividual)
            {
                representationString =  "ОГРНИП: " + company.Ogrnip + " " +
                                        "- ИНН: " + company.Inn + "\n" +
                                        "Регистрация: " + company.Registration.GrnDate + " " +
                                        company.TerminationDate + "\n" +
                                        company.Address.Full;
            }

            return representationString;
        }

        //Неинлайн
        private static async void BotOnMessageReceived(object sender, MessageEventArgs e)
        {
            var message = e.Message;

            if (message == null || message.Type != MessageType.Text)
                return;

            string name = $"{message.From.FirstName} {message.From.LastName}";

            Console.WriteLine($"{name} отправил сообщение '{message.Text}'");

            if (message.Text == "/help")
            {
                string text =
                        "Список команд:\n" +
                        "/help - Список команд\n" +
                        "Ввод любого текста - Найти контрагента (not inline)\n" +
                        "@testegrul_bot [organization] - Найти контрагента (inline)\n";
                try
                {
                    await bot.SendTextMessageAsync(message.Chat.Id, text);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return;
                }
            }
            else
            {
                int total = 0;

                string accessToken = await GetAccessToken(graphClient, jsonSerializerSettings);

                var query = @"
                query search ($findString: String) {
                    search(query: $findString limit: 10) {
                        entities {
                            __typename
                            ... on Company {
                                fullName
                                shortName
                                ogrn
                                inn
                                kpp
                                authorizedCapital{
                                  amount
                                }
              	                okveds{
                                  code
                                  isPrimary
                                  description
                                }
                                head{
                                  position
                                  head{
                                    ... on Person {
                                      lastName
                                      firstName
                                      middleName
                                    }
                                  }
                                }
                                registration{
                                  grnDate
                                }
                                terminationDate
                                address {
                                  full
                                }
                                status {
                                  text
                                }
              	                extracts {
                                  list {
                                    linkForDownload
                                  }
                                }
                                founders {
                                    share
                                    amount
                                    founder {        
                                    __typename
                                    ... on Person {
                                        firstName
                                        lastName
                                        middleName
                                        inn
                                    }
                                    ... on Company {
                                        fullName
                                        inn
                                    }
                                    ... on ForeignOrganization {
                                        name
                                        inn
                                    }
                                  }
                                }
                                taxation {
                                  averageEmployeesNumber
                                  rsmpRegistry {
                                    description
                                    employees
                                  }
                                }
				                compliance {
                                  markers {
                                    occurrences {
                                      title
                                      severity
						            }
                                  }
                                }
                                finances {
                                  pnl {
                                    values
                                  }
                                }
                            }
                            ... on Individual {
                            firstName
                            lastName
                            middleName 
                            ogrnip
                            inn
                            okveds{
                              code
                              isPrimary
                              description
                            }
                            registration{
                              grnDate
                            }
                            terminationDate
                            address {
                              full
                            }
                            status {
                              text
                            }
              	            extracts {
                              list {
                                linkForDownload
                              }
                            }
                            taxation {
                              rsmpRegistry {
                                description
                                employees
                              }
                            }
                            compliance {
                              markers {
                                occurrences {
                                  title
                                  severity
                                }
                              }
                            }
                        }
                    }
                    total
                    }
                }
                ";

                graphClient.DefaultRequestHeaders.Clear();
                graphClient.DefaultRequestHeaders.Add("authorization", $"Bearer {accessToken}");
                var request = new GraphQLRequest
                {
                    Query = query,
                    Variables = new { findString = message.Text }
                };

                var finalRequest = await graphClient.PostAsync(request);

                string companiesFound = finalRequest.GetDataFieldAs<object>("search").ToString();

                var result = JsonConvert.DeserializeObject<RootObject>(companiesFound, jsonSerializerSettings);

                List<Company> companiesList = result.Entities.ToList();

                InlineQueryResultArticle[] results = new InlineQueryResultArticle[companiesList.Count];

                foreach (Company company in companiesList)
                    FillNulls(company);

                string fullMessage = "";
                total = result.Total;
                InlineKeyboardMarkup inlineKeyboardMarkup = null;

                if (companiesList.Count == 1)
                {
                    string docSourceText = "";

                    if (companiesList[0].__typename == "Company")
                    {
                        TerminationDateNullCheck(companiesList[0], false, false);
                        fullMessage += GetNotInlineSingleTelegramStringRepresentation(companiesList[0], false);
                        docSourceText = "ЕГРЮЛ";
                    }
                    if (companiesList[0].__typename == "Individual")
                    {
                        TerminationDateNullCheck(companiesList[0], true, false);
                        fullMessage += GetNotInlineSingleTelegramStringRepresentation(companiesList[0], true);
                        docSourceText = "ЕГРИП";
                    }

                    if (companiesList[0].Extracts.List.Count > 0)
                    {
                        inlineKeyboardMarkup = new InlineKeyboardMarkup(new[]
                        {
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData($"Скачать выписку из {docSourceText}", companiesList[0].Extracts.List[0].LinkForDownload)
                            }
                        });
                    }
                }
                else if (companiesList.Count > 0)
                {
                    fullMessage += "Количество результатов: " + total + $"\nПоказано: с 1 по {companiesList.Count}\n\n";

                    fullMessage += string.Join("\n\n", companiesList.Select(company => GetNotInlineMultipleTelegramStringRepresentation(company)));
                }

                //Заполнение списка результатов
                try
                {
                    if (companiesList.Count != 0)
                        if (companiesList.Count == 1)
                            if (companiesList[0].Extracts.List.Count > 0)
                                await bot.SendTextMessageAsync(message.Chat.Id, fullMessage, ParseMode.Markdown, disableWebPagePreview: true, replyMarkup: inlineKeyboardMarkup);
                            else
                                await bot.SendTextMessageAsync(message.Chat.Id, fullMessage, ParseMode.Markdown, disableWebPagePreview: true);
                        else
                            await bot.SendTextMessageAsync(message.Chat.Id, fullMessage, ParseMode.Markdown, disableWebPagePreview: true);
                    else
                        await bot.SendTextMessageAsync(message.Chat.Id, "Не найдено");
                }
                catch (Exception ex) { Console.WriteLine(ex.ToString()); return; }
            }
        }

        private static StringBuilder GetNotInlineSingleTelegramStringRepresentation(Company company, bool isIndividual)
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (!isIndividual)
            {
                string mainCode = "", mainDescription = "";
                string activityDescription;

                int years;
                if (company.TerminationDate.Contains("Закрытие:"))
                {
                    DateTime terminationDate = DateTime.ParseExact(company.TerminationDate.Split(' ')[2], "dd/MM/yyyy", null);
                    DateTime grnDate = DateTime.ParseExact(company.Registration.GrnDate, "dd/MM/yyyy", null);
                    years = terminationDate.Year - grnDate.Year;

                    activityDescription = "*Причина прекращения деятельности *: " + company.Status.Text;
                }
                else
                {
                    DateTime grnDate = DateTime.ParseExact(company.Registration.GrnDate, "dd/MM/yyyy", null);
                    years = DateTime.Now.Year - grnDate.Year;

                    for (int i = 0; i < company.Okveds.Count; i++)
                        if (company.Okveds[i].IsPrimary)
                        {
                            mainCode = company.Okveds[i].Code;
                            mainDescription = company.Okveds[i].Description;
                        }

                    activityDescription = "*Основной вид деятельности *: " + mainCode + ", " + mainDescription;
                }

                try
                {
                    stringBuilder.AppendLine("*" + company.ShortName + "*\n");
                    stringBuilder.AppendLine("*ИНН*: " + company.Inn);
                    stringBuilder.AppendLine("*ОГРН*: " + company.Ogrn);
                    stringBuilder.AppendLine("*КПП*: " + company.Kpp);
                    stringBuilder.AppendLine("*Регистрация*: " + company.Registration.GrnDate);
                    stringBuilder.AppendLine(company.TerminationDate.Replace("Закрытие", "*Закрытие*").Replace("Организация работает", "*Организация работает*").Replace("- ", ""));
                    stringBuilder.AppendLine("*Возраст*: " + years + $" {GetYearAdaptation(years)}");
                    stringBuilder.AppendLine("*Адрес*: " + company.Address.Full);
                    stringBuilder.AppendLine("*Уставной капитал*: " + company.AuthorizedCapital.Amount + " ₽");
                    if (activityDescription != "*Основной вид деятельности *: , ")
                        stringBuilder.AppendLine(activityDescription);
                    if(company.Head != null)
                        stringBuilder.AppendLine($"\n*{company.Head.Position}*:\n" + company.Head.Head.LastName + " " + company.Head.Head.FirstName + " " + company.Head.Head.MiddleName);
                    if (company.Founders.Count > 0)
                    {
                        stringBuilder.AppendLine("\n*Учредители*:");
                        foreach (FounderMain founder in company.Founders)
                        {
                            if (founder.Share == null || founder.Amount == null || founder.Share == 0 || founder.Amount == 0)
                            {
                                if (founder.Founder.__typename == "Person")
                                    stringBuilder.AppendLine($"‣ {founder.Founder.LastName} {founder.Founder.FirstName} {founder.Founder.MiddleName}");
                                else if (founder.Founder.__typename == "Company")
                                    stringBuilder.AppendLine($"‣ {founder.Founder.FullName}");
                                else if (founder.Founder.__typename == "ForeignOrganization")
                                    stringBuilder.AppendLine($"‣ {founder.Founder.Name}");
                            }
                            else
                            {
                                if (founder.Founder.__typename == "Person")
                                    stringBuilder.AppendLine($"‣ {founder.Founder.LastName} {founder.Founder.FirstName} {founder.Founder.MiddleName} {Convert.ToDouble(founder.Share * 100).ToString("#.##")}% ({Convert.ToDouble(founder.Amount).ToString("#.##")} ₽)");
                                else if (founder.Founder.__typename == "Company")
                                    stringBuilder.AppendLine($"‣ {founder.Founder.FullName} {Convert.ToDouble(founder.Share * 100).ToString("#.##")}% ({Convert.ToDouble(founder.Amount).ToString("#.##")} ₽)");
                                else if (founder.Founder.__typename == "ForeignOrganization")
                                    stringBuilder.AppendLine($"‣ {founder.Founder.Name} {Convert.ToDouble(founder.Share * 100).ToString("#.##")}% ({Convert.ToDouble(founder.Amount).ToString("#.##")} ₽)");
                            }
                            if (founder.Founder.Inn != null)
                                stringBuilder.AppendLine($"ИНН (/{founder.Founder.Inn})");
                        }
                    }
                    if (company.Taxation.RsmpRegistry != null || company.Taxation.AverageEmployeesNumber != null)
                    {
                        stringBuilder.AppendLine("\n*Размер предприятия*:");
                        if (company.Taxation.RsmpRegistry != null)
                            stringBuilder.AppendLine($"{company.Taxation.RsmpRegistry.Description} ({company.Taxation.RsmpRegistry.Employees})");
                        if (company.Taxation.AverageEmployeesNumber != null)
                            stringBuilder.AppendLine($"Среднесписочная численность: {company.Taxation.AverageEmployeesNumber} чел.");
                    }
                    if (company.Compliance.Markers[0].Occurrences[0].Severity == "NONE")
                        stringBuilder.AppendLine($"\n✓ {company.Compliance.Markers[0].Occurrences[0].Title}");
                    else
                        stringBuilder.AppendLine($"\n✘ {company.Compliance.Markers[0].Occurrences[0].Title}");
                    if (GetCompanyFinancialStatus(company, true) != null)
                        if (GetCompanyFinancialStatus(company, true).ComparisonPercent != "0")
                            stringBuilder.AppendLine($"\n*Выручка за {GetCompanyFinancialStatus(company, true).Year} год*: {GetCompanyFinancialStatus(company, true).Value} ₽ ({GetCompanyFinancialStatus(company, true).ComparisonPercent}%)");
                        else
                            stringBuilder.AppendLine($"\n*Выручка за {GetCompanyFinancialStatus(company, true).Year} год*: {GetCompanyFinancialStatus(company, true).Value} ₽");
                    if (GetCompanyFinancialStatus(company, false) != null)
                        if (GetCompanyFinancialStatus(company, false).ComparisonPercent != "0")
                            if (GetCompanyFinancialStatus(company, false).Value >= 0)
                                stringBuilder.AppendLine($"*Чистая прибыль за {GetCompanyFinancialStatus(company, false).Year} год*: {GetCompanyFinancialStatus(company, false).Value} ₽ ({GetCompanyFinancialStatus(company, false).ComparisonPercent}%)");
                            else
                                stringBuilder.AppendLine($"*Убыток за {GetCompanyFinancialStatus(company, false).Year} год*: {GetCompanyFinancialStatus(company, false).Value} ₽ ({GetCompanyFinancialStatus(company, false).ComparisonPercent}%)");
                        else
                            if (GetCompanyFinancialStatus(company, false).Value >= 0)
                                stringBuilder.AppendLine($"*Чистая прибыль за {GetCompanyFinancialStatus(company, false).Year} год*: {GetCompanyFinancialStatus(company, false).Value} ₽");
                            else
                                stringBuilder.AppendLine($"*Убыток за {GetCompanyFinancialStatus(company, false).Year} год*: {GetCompanyFinancialStatus(company, false).Value} ₽");
                    stringBuilder.AppendLine("\nПодробнее:");
                    stringBuilder.AppendLine("kontragent.io/company/" + company.Ogrn + "/" + company.Inn + "/info");
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            else
            {
                int years;

                if (company.TerminationDate.Contains("Закрытие:"))
                {
                    DateTime terminationDate = DateTime.ParseExact(company.TerminationDate.Split(' ')[2], "dd/MM/yyyy", null);
                    DateTime grnDate = DateTime.ParseExact(company.Registration.GrnDate, "dd/MM/yyyy", null);
                    years = terminationDate.Year - grnDate.Year;
                }
                else
                {
                    DateTime grnDate = DateTime.ParseExact(company.Registration.GrnDate, "dd/MM/yyyy", null);
                    years = DateTime.Now.Year - grnDate.Year;
                }

                try
                {
                    stringBuilder.AppendLine("*ИП " + company.LastName + " " + company.FirstName + " " + company.MiddleName + "*\n");
                    stringBuilder.AppendLine("*ИНН*: " + company.Inn);
                    stringBuilder.AppendLine("*ОГРНИП*: " + company.Ogrnip);
                    stringBuilder.AppendLine("*Регистрация*: " + company.Registration.GrnDate);
                    stringBuilder.AppendLine(company.TerminationDate.Replace("Закрытие", "*Закрытие*").Replace("ИП работает", "*ИП работает*").Replace("- ", ""));
                    stringBuilder.AppendLine("*Возраст*: " + years + $" {GetYearAdaptation(years)}");
                    stringBuilder.AppendLine("*Адрес*: " + company.Address.Full);
                    if (company.Taxation.RsmpRegistry != null || company.Taxation.AverageEmployeesNumber != null)
                    {
                        stringBuilder.AppendLine("\n*Размер предприятия*:");
                        if (company.Taxation.RsmpRegistry != null)
                            stringBuilder.AppendLine($"{company.Taxation.RsmpRegistry.Description} ({company.Taxation.RsmpRegistry.Employees})");
                    }
                    if (company.Compliance.Markers[0].Occurrences[0].Severity == "NONE")
                        stringBuilder.AppendLine($"\n✓ {company.Compliance.Markers[0].Occurrences[0].Title}");
                    else
                        stringBuilder.AppendLine($"\n✘ {company.Compliance.Markers[0].Occurrences[0].Title}");
                    stringBuilder.AppendLine("\nПодробнее:");
                    stringBuilder.AppendLine("kontragent.io/company/" + company.Ogrnip + "/" + company.Inn + "/info");
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }

            return stringBuilder;
        }

        private static string GetNotInlineMultipleTelegramStringRepresentation(Company company)
        {
            string stringRepresentation = "";
            
            if (company.__typename == "Company")
            {
                TerminationDateNullCheck(company, false, false);
                stringRepresentation += "*" + company.ShortName + "*\n" +
                                        "ИНН: /" + company.Inn + "\n" +
                                        "ОГРН: " + company.Ogrn + "\n" +
                                        "Регистрация: " + company.Registration.GrnDate + " " +
                                        company.TerminationDate + "\n" +
                                        "kontragent.io/company/" + company.Ogrn + "/" + company.Inn + "/info";
            }
            if(company.__typename == "Individual")
            {
                TerminationDateNullCheck(company, true, false);
                stringRepresentation += @"*ИП " + company.LastName + " " + company.FirstName + " " + company.MiddleName + "*\n" +
                                        "ИНН: /" + company.Inn + "\n" +
                                        "ОГРНИП: " + company.Ogrnip + "\n" +
                                        "Регистрация: " + company.Registration.GrnDate + " " +
                                        company.TerminationDate + "\n" +
                                        "kontragent.io/company/" + company.Ogrnip + "/" + company.Inn + "/info";
            }

            return stringRepresentation;
        }    

        private static string GetYearAdaptation(int year)
        {
            string adaptatation;

            if (year.ToString().Last() == '1')
                adaptatation = "год";
            else if (year.ToString().Last() == '2' || year.ToString().Last() == '3' || year.ToString().Last() == '4')
                adaptatation = "года";
            else
                adaptatation = "лет";

            return adaptatation;
        }

        private static FinancialStatus GetCompanyFinancialStatus(Company company, bool isRevenue)
        {
            string dictionaryString = company.Finances.Pnl.Values.ToString();
            FinancialStatus financialStatus = new FinancialStatus();

            if (dictionaryString != "{}")
            {
                var financialDictionary = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, long>>>(dictionaryString, jsonSerializerSettings);

                financialStatus.Year = financialDictionary.First().Key;

                if (isRevenue)
                {
                    financialStatus.Value = financialDictionary.First().Value["2110"];
                    if(financialDictionary.Count > 1)
                        if (Convert.ToDouble(financialDictionary.ElementAt(1).Value["2110"]) != 0)
                            financialStatus.ComparisonPercent = ((Convert.ToDouble(financialDictionary.First().Value["2110"]) / Convert.ToDouble(financialDictionary.ElementAt(1).Value["2110"]) - 1) * 100).ToString();
                        else
                            financialStatus.ComparisonPercent = "0";
                }
                else
                {
                    financialStatus.Value = financialDictionary.First().Value["2500"];
                    if (financialDictionary.Count > 1)
                        if (Convert.ToDouble(financialDictionary.ElementAt(1).Value["2500"]) != 0)
                            financialStatus.ComparisonPercent = ((Convert.ToDouble(financialDictionary.First().Value["2500"]) / Convert.ToDouble(financialDictionary.ElementAt(1).Value["2500"]) - 1) * 100).ToString();
                        else
                            financialStatus.ComparisonPercent = "0";
                }

                if (Convert.ToDouble(financialStatus.ComparisonPercent) > 0)
                    financialStatus.ComparisonPercent = "▲" + Convert.ToDouble(financialStatus.ComparisonPercent).ToString("0.##"); 
                else if (Convert.ToDouble(financialStatus.ComparisonPercent) < 0)
                    financialStatus.ComparisonPercent = "▼" + Convert.ToDouble(financialStatus.ComparisonPercent).ToString("0.##").Replace("-", "");

                return financialStatus;
            }
            else
                return null;
        }

        private static async void Bot_OnCallbackQuery(object sender, CallbackQueryEventArgs e)
        {
            string url = e.CallbackQuery.Data;

            InputOnlineFile inputOnlineFile = new InputOnlineFile(url);

            //Отправить файл
            try
            {
                await bot.SendDocumentAsync(e.CallbackQuery.Message.Chat.Id, inputOnlineFile);
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return; }
        }
    }
}
