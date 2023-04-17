using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerRelaManag.Models
{
	public class Clients
	{
		[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ClientId { get; set; }
		public string ClientName { get; set; }

	}
}
