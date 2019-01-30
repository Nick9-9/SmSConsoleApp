using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Recepient
    {   
        [Key]
        public int IdRecepeint { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public ICollection<Mesasage> Mesasages;
        public Recepient()
        {
            Mesasages = new List<Mesasage>();
        }
    }
}
