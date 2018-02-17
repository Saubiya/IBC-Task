using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCDemoApp.Models
{
    public class Test
    {
        public int AccountId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string EmailId { get; set; }
        [Required]
        public string CompanyName { get; set; }
    }

    
}
