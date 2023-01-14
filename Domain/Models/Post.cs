using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }

        public DateTime PostDate { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set;}
        public virtual User PostUser { get; set; }

        public virtual IEnumerable<Tags> Tags { get; set; }


    }
}
