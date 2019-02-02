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
        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                
                //password = value;
                password = string.Empty;
                ConsoleKeyInfo key;
                do
                {
                    key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Enter) break;
                    if (key.Key == ConsoleKey.Backspace)
                    {
                        if (password.Length != 0)
                        {
                            password = password.Remove(password.Length - 1);
                            Console.Write("\b \b");
                        }
                    }
                    else
                    {
                        password += key.KeyChar;
                        Console.Write("*");
                    }
                } while (key.Key != ConsoleKey.Enter);
            }
        }
        public string Name { get; set; }

        public ICollection<Messager> Messagers { get; set; }

        public User()
        {
            Messagers = new List<Messager>();
        }

    }}
