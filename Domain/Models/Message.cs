using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }

        public string MessageBody { get; set; }

        [ForeignKey("UserId")]
        public int SenderId { get; set; }
        public virtual User Sender { get; set; }

        [ForeignKey("UserId")]
        public int ReceiverId { get; set; }
        public virtual User Receiver { get; set; }


        [ForeignKey("PostId")]
        public int PostId { get; set; }
        public virtual Post Post { get; set; }


        public DateTime MessageDate { get; set; }
    }
}
