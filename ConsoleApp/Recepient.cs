using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Recepient
    {
        [Key]
        public int RecepientId { get; set; }
        private string phoneRecepient;
        public string PhoneRecepient
        {
            get
            {
                return phoneRecepient;
            }
            set
            {
                string pattern = @"^\+[0-9]{12}";
                if (Regex.IsMatch(value, pattern))
                {
                    phoneRecepient = value;
                }

            }
        }
        public string Name { get; set; }
        public string Address { get; set; }

        public ICollection<Messager> Messagers { get; set; }

        public Recepient()
        {
            Messagers = new List<Messager>();
        }
    }
}
