using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Informational_system_Lib.Models
{
    public class Customer
    {
        [Key] // обявява се че id ще бъде първичен ключ за базата данни.
        // декларират се променливи които ще бъдат полетата на нашата база данни.
        public int id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string Addres { get; set; }
        public string PhoneNumber { get; set; }
        public string EGN { get; set; }
        public string NameOfBook { get; set; }
        public DateTime DateOfRecord { get; set; }
        public DateTime DateOfDeregistration { get; set; }
    }
}

