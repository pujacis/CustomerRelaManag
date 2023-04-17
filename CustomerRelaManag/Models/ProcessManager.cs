using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerRelaManag.Models
{
	public class ProcessManager
	{
		[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int PMId { get; set; }
		public string? PMName { get; set; }
		public int ProjectId { get; set; }
		public int ClientId { get; set; }		
		public int AssignByBd { get; set; }
		public int? AssignTo { get; set; }
		
	}
}
