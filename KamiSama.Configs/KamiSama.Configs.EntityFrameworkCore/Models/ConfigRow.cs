using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KamiSama.Configs.EntityFrameworkCore.Models
{
	public class ConfigRow
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }

		[MaxLength(400)]
		[Required]
		public string ProfileName { get; set; }

		[MaxLength(400)]
		[Required]
		public string ConfigContextKey { get; set; }
		
		public string Text { get; set; }
	}
}
