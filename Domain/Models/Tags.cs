using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Tags
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("PostId")]
        public int PostId { get; set; }
        public virtual Post Post { get; set; }

    }
}
