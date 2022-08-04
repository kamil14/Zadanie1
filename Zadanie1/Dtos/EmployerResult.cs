using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zadanie1.Models
{

    public class EmployerResult
    {
        public Result result { get; set; }
    }

    public class Result
    {
        public Subject subject { get; set; }
        public string requestId { get; set; }
        public string requestDateTime { get; set; }
    }

    public class Subject
    {
        public string name { get; set; }
        public string nip { get; set; }
        public string statusVat { get; set; }
        public string regon { get; set; }
        public object pesel { get; set; }
        public object krs { get; set; }
        public string residenceAddress { get; set; }
        public object workingAddress { get; set; }
        public object[] representatives { get; set; }
        public object[] authorizedClerks { get; set; }
        public object[] partners { get; set; }
        public string registrationLegalDate { get; set; }
        public object registrationDenialBasis { get; set; }
        public object registrationDenialDate { get; set; }
        public object restorationBasis { get; set; }
        public object restorationDate { get; set; }
        public object removalBasis { get; set; }
        public object removalDate { get; set; }
        public object[] accountNumbers { get; set; }
        public bool hasVirtualAccounts { get; set; }
    }

}
