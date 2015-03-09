namespace Model
{
	#region References

	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations.Schema;

	#endregion

	[Table("Categoria")]
	public class Categoria
	{
		public int Id { get; set; }
		public string Descricao { get; set; }
		public virtual List<SubCategoria> SubCategorias { get; set; }
	}
}