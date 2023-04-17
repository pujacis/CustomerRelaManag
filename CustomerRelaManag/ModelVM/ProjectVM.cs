using CustomerRelaManag.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CustomerRelaManag.ModelVM
{
    public class ProjectVM
    {
        [Key]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Status { get; set; }
        public string Details { get; set; }
        public string ClientName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string PMName { get; set; }
        public string TeamName { get; set; }
        public string BDName { get; set; }

    }


}

