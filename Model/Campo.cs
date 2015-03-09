namespace Model
{
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("Campo")]
	public class Campo
	{
		public int Id { get; set; }
		public int Ordem { get; set; }
		public string Descricao { get; set; }
		public TipoCampo Tipo { get; set; }
        public int SubCategoriaId { get; set; }
		public virtual List<OpcoesCampo> Opcoes { get; set; }
	}
}