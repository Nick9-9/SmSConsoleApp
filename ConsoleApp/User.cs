using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{

    public class User
    {
        [Key]
        public int IdSender { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        ICollection<Mesasage> Mesasages { get; set; }
        public User()
        {
            Mesasages = new List<Mesasage>();
        }
        }
    
}
