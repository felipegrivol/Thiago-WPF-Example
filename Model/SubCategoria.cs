namespace Model
{
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("SubCategoria")]
	public class SubCategoria
	{
		public int Id { get; set; }
		public string Descricao { get; set; }
		public int CategoriaId { get; set; }
		public virtual List<Campo> Campos { get; set; }
	}
}