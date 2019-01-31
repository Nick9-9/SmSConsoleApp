using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Messager
    {
        [Key]
        public int MessagerID { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public string TextMessage { get; set; }
        public int RecepientId { get; set; }
        public int UserId { get; set; }



        [ForeignKey("UserId")]
        public User Sender { get; set; }
        [ForeignKey("RecepientId")]
        public Recepient Recepient { get; set; }
    }
}
