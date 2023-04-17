using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerRelaManag.Models
{
	public class BDE
	{
		[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int BDEId { get; set; }
		public string BDEName { get; set; }
		public int ProjectId { get; set; }
		public int AssignTo { get; set; }
		public DateTime CreatedDate { get; set; }

	}
}
