using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class PostVM
    {
        public int PostId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime PostDate { get; set; }        
        public int UserId { get; set; }
        public virtual List<TagsVM> Tags { get; set; }
    }
}
