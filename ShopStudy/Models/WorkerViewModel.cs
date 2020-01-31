using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ShopStudy.Data;
using ShopStudy.Infrastructure.Interfaces;

namespace ShopStudy.Models
{
    public class WorkerViewModel 
    {
        
        public int Id { get; set; }

        [StringLength(maximumLength:20, MinimumLength = 2, ErrorMessage = "Length must be between 2 and 20") ]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name must be specified")]
        public string FirstName { get; set; }

        [StringLength(maximumLength: 20, MinimumLength = 2, ErrorMessage = "Length must be between 2 and 20")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Second name must be specified")]
        public string SurName { get; set; }

        [StringLength(maximumLength: 20, MinimumLength = 2, ErrorMessage = "Length must be between 2 and 20")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Sex must be specified")]
        public string Sex { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
    }
}
