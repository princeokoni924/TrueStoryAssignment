using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALCore.Model.Dtos
{
    public class AddProductDto
    {
        [Required]
        public string? Name { get; set; } 

        [Required]
        public string? Data { get; set; }
    }
}
