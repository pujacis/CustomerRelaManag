using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerRelaManag.Models
{
	public class Projects
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ProjectId { get; set; }
		public string ProjectName { get; set; }
		public int StatusId { get; set; }
		public string Details { get; set; }
		public int Clientid { get; set; }
		public DateTime CreatedDate { get; set; }
		public int? PMID { get; set; }
		public int? TeamId { get; set; }
		public int BdId { get; set; }
		
	}
}
