using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class MessageBlock
    {
        [Key]
        public int BlockId { get; set; }
        public int UserId { get; set; }
        public int BlockUserId { get; set; }
        public DateTime BlockDate { get; set; }
    }
}
