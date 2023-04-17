using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerRelaManag.Models
{
	public class Teams
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeamId { get; set; }
		public string TeamName { get; set; }
		public int BDEid { get; set; }
		public int PMId { get; set; }
		public int ProjectId { get; set; }
	}
}
