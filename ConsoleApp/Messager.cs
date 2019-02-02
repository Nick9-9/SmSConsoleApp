using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ConsoleApp
{
    [DataContract]
    class Messager
    {
        [Key] [DataMember]
        public int MessagerID { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public TimeSpan Time { get; set; }
        [DataMember]
        public string TextMessage { get; set; }      
        public int RecepientId { get; set; }      
        public int UserId { get; set; }


        [ForeignKey("UserId")]
        public User Sender { get; set; }
        [ForeignKey("RecepientId")]
        public Recepient Recepient { get; set; }
        public Messager()
        {
            Date = DateTime.Now.Date;
            Time = DateTime.Now.TimeOfDay;
        }
    }
}
