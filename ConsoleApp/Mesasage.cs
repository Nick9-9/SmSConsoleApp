using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Mesasage
    {
        [Key]
        public int Id { get; set; }
        public int IdSender { get; set; }
        public int RecepientPhone { get; set; }
        public DateTime Data { get; set; }
        public string TextMessage { get; set; }
        public DateTime Time { get; set; }

        [ForeignKey("IdSender")]
        public User Sender { get; set; }
        [ForeignKey("RecepientPhone")]
        public Recepient Recepient { get; set; }
    }
}
