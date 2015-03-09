namespace UI.ViewModel
{
    #region References
    using System;
    using System.Collections.Generic;
    using System.Reactive;
    using ReactiveUI;
    using Model;
    using Data;
    using System.Collections.ObjectModel;
using System.Windows.Controls;
    #endregion

	public class PublicoViewModel : ViewModelBase
    {
        #region Commands
        private IReactiveCommand<Unit> _gerarFormCategoriaCommand;
        public IReactiveCommand<Unit> GerarFormCategoriaCommand
        {
            get
            {
                return this._gerarFormCategoriaCommand;
            }
            private set
            {
                this.RaiseAndSetIfChanged(ref this._gerarFormCategoriaCommand, value);
            }
        }
        #endregion

        #region Propriedades
        private List<Categoria> _categorias;
        public List<Categoria> Categorias
        {
            get 
            {
                return this._categorias;
            }
            set 
            {
                this.RaiseAndSetIfChanged(ref this._categorias, value);
            }
        }
        private Categoria _categoriaSelecionada;
        public Categoria CategoriaSelecionada
        {
            get
            {
                return this._categoriaSelecionada;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref this._categoriaSelecionada, value);

                if (value != null)
                    this.ObterSubCategorias();
                else
                    this.SubCategorias = null;
            }
        }

        private List<SubCategoria> _subCategorias;
        public List<SubCategoria> SubCategorias
        {
            get
            {
                return this._subCategorias;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref this._subCategorias, value);
            }
        }
        private SubCategoria _subCategoriaSelecionada;
        public SubCategoria SubCategoriaSelecionada
        {
            get
            {
                return this._subCategoriaSelecionada;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref this._subCategoriaSelecionada, value);

                if (value != null)
                    this.ObterCampos();
                else
                    this.Campos = null;
            }
        }

        private List<Campo> _campos;
        public List<Campo> Campos
        {
            get
            {
                return this._campos;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref this._campos, value);
            }
        }

        private ObservableCollection<ItemsControl> _controles;
        public ObservableCollection<ItemsControl> Controles
        {
            get
            {
                return this._controles;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref this._controles, value);
            }
        }
        #endregion

        public PublicoViewModel ()
        {
            ObterCategorias();
            GerarFormCategoriaCommand = this.CreateCommand(this.WhenAny(vm => vm.SubCategoriaSelecionada, s => s.Value != null), this.GerarFormulario);
        }

        #region Metodos
        private void ObterCategorias()
        {
            try
            {
                IsBusy = true;
                Categorias = new List<Categoria>(new CategoriaData().Obter());
            }
            finally
            {
                IsBusy = false;
            }
        }
        private void ObterSubCategorias()
        {
            try
            {
                IsBusy = true;
                SubCategorias = new List<SubCategoria>(new SubCategoriaData().ObterPorCategoriaId(CategoriaSelecionada.Id));
            }
            finally
            {
                IsBusy = false;
            }
        }
        private void ObterCampos()
        {
            try
            {
                IsBusy = true;
                Campos = new List<Campo>(new CampoData().ObterPorSubCategoriaId(SubCategoriaSelecionada.Id));
            }
            finally
            {
                IsBusy = false;
            }
        }
        private void GerarFormulario()
        { 

        }
        #endregion
    }
}