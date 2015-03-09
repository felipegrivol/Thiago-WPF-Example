namespace Data
{
	#region References

	using System.Data.Entity;
	using System.Data.Entity.ModelConfiguration.Conventions;

	using Model;

	#endregion

	public class CategoriasContext : DbContext
	{
		public CategoriasContext()
			: base("name=CategoriasContext")
		{
			
		}

		// Add a DbSet for each entity type that you want to include in your model. For more information 
		// on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

		// public virtual DbSet<MyEntity> MyEntities { get; set; }

		public virtual DbSet<Categoria> Categorias { get; set; }
		public virtual DbSet<SubCategoria> SubCategorias { get; set; }
		public virtual DbSet<Campo> Campos { get; set; }
        public virtual DbSet<OpcoesCampo> OpcoesCampos { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}
}