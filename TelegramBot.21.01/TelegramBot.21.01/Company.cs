using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBotApp
{
    public class Company
    {
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string Ogrn { get; set; }
        public string Inn { get; set; }
        public string Kpp { get; set; }

        public string __typename { get; set; }
        public AuthorizedCapital AuthorizedCapital { get; set; }
        public List<Okveds> Okveds { get; set; }
        public HeadMain Head { get; set; }
        public Status Status { get; set; }
        public string TerminationDate { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Ogrnip { get; set; }

        public Address Address { get; set; }
        public Registration Registration { get; set; }
        public Extracts Extracts { get; set; }
        public List<FounderMain> Founders { get; set; }
        public Taxation Taxation { get; set; }
        public Compliance Compliance { get; set; }
        public Finances Finances { get; set; }
    }
}
