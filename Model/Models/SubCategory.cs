using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class SubCategory
    {
        [Key]
        public int SubCategory_Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Required { get; set; }
    }
}
