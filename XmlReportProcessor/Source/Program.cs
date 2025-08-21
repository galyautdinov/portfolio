using System;
using System.Globalization;
using System.IO;
using System.Xml;
using System.Xml.Xsl;

namespace XmlReportProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Определяем какой файл обрабатывать
                string dataFileName = "Data1.xml";
                if (args.Length > 0 && !string.IsNullOrEmpty(args[0]))
                {
                    dataFileName = args[0];
                }

                Console.WriteLine($"Starting XML processing for {dataFileName}...");
                
                // Получаем базовую директорию проекта
                string baseDirectory = AppContext.BaseDirectory;
                
                // Поднимаемся на 4 уровня вверх от bin/Debug/net8.0/
                string projectRoot = Path.GetFullPath(Path.Combine(baseDirectory, "..", "..", "..", ".."));
                
                // Определяем правильные пути к файлам
                string dataPath = Path.Combine(projectRoot, "Data", dataFileName);
                string xsltPath = Path.Combine(projectRoot, "Resources", "TransformToEmployees.xslt");
                string employeesPath = Path.Combine(projectRoot, "Data", "Employees.xml");
                
                Console.WriteLine($"Data path: {dataPath}");
                Console.WriteLine($"XSLT path: {xsltPath}");
                Console.WriteLine($"Output path: {employeesPath}");
                
                // Проверяем существование файлов
                if (!File.Exists(dataPath))
                {
                    throw new FileNotFoundException($"Data file not found: {dataPath}");
                }
                if (!File.Exists(xsltPath))
                {
                    throw new FileNotFoundException($"XSLT file not found: {xsltPath}");
                }

                // 1. Запускаем XSLT-преобразование
                Console.WriteLine("Running XSLT transformation...");
                RunXsltTransformation(dataPath, xsltPath, employeesPath);
                
                // 2. Добавляем атрибут с суммой salary для каждого Employee
                Console.WriteLine("Adding salary sum attribute...");
                AddSalarySumAttribute(employeesPath);
                
                // 3. Добавляем атрибут с общей суммой
                if (dataFileName == "Data1.xml")
                {
                    Console.WriteLine("Adding total sum attribute to Data1.xml...");
                    AddTotalSumAttribute(dataPath);
                }
                else
                {
                    Console.WriteLine($"Skipping total sum attribute for {dataFileName} (only for Data1.xml)");
                }
                
                Console.WriteLine("Processing completed successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
            }
        }

        static void RunXsltTransformation(string xmlPath, string xsltPath, string outputPath)
        {
            try
            {
                var xslt = new XslCompiledTransform();
                xslt.Load(xsltPath);
                xslt.Transform(xmlPath, outputPath);
                Console.WriteLine($"Transformation completed. Output: {outputPath}");
            }
            catch (Exception ex)
            {
                throw new Exception($"XSLT transformation failed: {ex.Message}", ex);
            }
        }

        static void AddSalarySumAttribute(string xmlPath)
        {
            try
            {
                var doc = new XmlDocument();
                doc.Load(xmlPath);

                var employees = doc.SelectNodes("/Employees/Employee");
                foreach (XmlElement employee in employees)
                {
                    decimal totalSalary = 0;
                    var salaries = employee.SelectNodes("salary");
                    
                    foreach (XmlElement salary in salaries)
                    {
                        string amountValue = salary.GetAttribute("amount");
                        if (decimal.TryParse(amountValue.Replace(',', '.'), 
                                            NumberStyles.Any, 
                                            CultureInfo.InvariantCulture, 
                                            out decimal amount))
                        {
                            totalSalary += amount;
                        }
                    }
                    
                    employee.SetAttribute("total-salary", totalSalary.ToString("F2", CultureInfo.InvariantCulture));
                    Console.WriteLine($"Employee {employee.GetAttribute("name")} {employee.GetAttribute("surname")} total salary: {totalSalary:F2}");
                }

                doc.Save(xmlPath);
                Console.WriteLine("Salary sum attributes added successfully");
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to add salary sum attribute: {ex.Message}", ex);
            }
        }

        static void AddTotalSumAttribute(string xmlPath)
        {
            try
            {
                var doc = new XmlDocument();
                doc.Load(xmlPath);

                decimal totalAmount = 0;
                // Используем XPath, который найдет все элементы item в любом месте документа
                var items = doc.SelectNodes("//item");
                
                foreach (XmlElement item in items)
                {
                    string amountValue = item.GetAttribute("amount");
                    if (decimal.TryParse(amountValue.Replace(',', '.'), 
                                        NumberStyles.Any, 
                                        CultureInfo.InvariantCulture, 
                                        out decimal amount))
                    {
                        totalAmount += amount;
                        Console.WriteLine($"Item amount: {amountValue} -> parsed: {amount}");
                    }
                    else
                    {
                        Console.WriteLine($"Failed to parse amount: {amountValue}");
                    }
                }

                var payElement = doc.DocumentElement;
                payElement.SetAttribute("total", totalAmount.ToString("F2", CultureInfo.InvariantCulture));
                
                doc.Save(xmlPath);
                Console.WriteLine($"Total amount: {totalAmount:F2}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to add total sum attribute: {ex.Message}", ex);
            }
        }
    }
}