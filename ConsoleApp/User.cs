using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp
{

     class User
    {
        [Key]
        public int UserId { get; set; }
        private string phoneUser;
        public string PhoneUser
        {
            get
            {
                return phoneUser;
            }
            set
            {
                string pattern = @"^\+[0-9]{12}";
                if (Regex.IsMatch(value, pattern))
                {
                    phoneUser = value;
                }

            }
        }
        public string Password { get; set; }
        public string Name { get; set; }

        public ICollection<Messager> Messagers { get; set; }

        public User()
        {
            Messagers = new List<Messager>();
        }

    }}
