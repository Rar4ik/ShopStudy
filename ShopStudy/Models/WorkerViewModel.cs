using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopStudy.Data;
using ShopStudy.Infrastructure.Interfaces;

namespace ShopStudy.Models
{
    public class WorkerViewModel 
    {
        
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
    }
}
