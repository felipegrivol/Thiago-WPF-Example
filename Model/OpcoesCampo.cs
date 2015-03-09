namespace Model
{
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("OpcoesCampo")]
	public class OpcoesCampo
	{
		public int Id { get; set; }
		public int CampoId { get; set; }
		public string Descricao { get; set; }
	}
}