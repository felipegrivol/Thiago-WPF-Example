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

    #endregion

    public class AdministrativoViewModel : ViewModelBase
    {
        #region Commands
        private IReactiveCommand<Unit> _adicionarCategoriaCommand;
        public IReactiveCommand<Unit> AdicionarCategoriaCommand
        {
            get
            {
                return this._adicionarCategoriaCommand;
            }
            private set
            {
                this.RaiseAndSetIfChanged(ref this._adicionarCategoriaCommand, value);
            }
        }
        private IReactiveCommand<Unit> _removerCategoriaCommand;
        public IReactiveCommand<Unit> RemoverCategoriaCommand
        {
            get
            {
                return this._removerCategoriaCommand;
            }
            private set
            {
                this.RaiseAndSetIfChanged(ref this._removerCategoriaCommand, value);
            }
        }

        private IReactiveCommand<Unit> _adicionarSubCategoriaCommand;
        public IReactiveCommand<Unit> AdicionarSubCategoriaCommand
        {
            get
            {
                return this._adicionarSubCategoriaCommand;
            }
            private set
            {
                this._adicionarSubCategoriaCommand = value;
                this.RaiseAndSetIfChanged(ref this._removerCategoriaCommand, value);
            }
        }
        private IReactiveCommand<Unit> _removerSubCategoriaCommand;
        public IReactiveCommand<Unit> RemoverSubCategoriaCommand
        {
            get
            {
                return this._removerSubCategoriaCommand;
            }
            private set
            {
                this.RaiseAndSetIfChanged(ref this._removerSubCategoriaCommand, value);
            }
        }

        private IReactiveCommand<Unit> _adicionarCampoCommand;
        public IReactiveCommand<Unit> AdicionarCampoCommand
        {
            get
            {
                return this._adicionarCampoCommand;
            }
            private set
            {
                this.RaiseAndSetIfChanged(ref this._adicionarCampoCommand, value);
            }
        }
        private IReactiveCommand<Unit> _removerCampoCommand;
        public IReactiveCommand<Unit> RemoverCampoCommand
        {
            get
            {
                return this._removerCampoCommand;
            }
            private set
            {
                this.RaiseAndSetIfChanged(ref this._removerCampoCommand, value);
            }
        }

        private IReactiveCommand<Unit> _adicionarOpcaoCommand;
        public IReactiveCommand<Unit> AdicionarOpcaoCommand
        {
            get
            {
                return this._adicionarOpcaoCommand;
            }
            private set
            {
                this.RaiseAndSetIfChanged(ref this._adicionarOpcaoCommand, value);
            }
        }
        private IReactiveCommand<Unit> _removerOpcaoCommand;
        public IReactiveCommand<Unit> RemoverOpcaoCommand
        {
            get
            {
                return this._removerOpcaoCommand;
            }
            private set
            {
                this.RaiseAndSetIfChanged(ref this._removerOpcaoCommand, value);
            }
        }
        #endregion

        #region Propriedades
        private string _descricaoCategoria;
        public string DescricaoCategoria
        {
            get
            {
                return this._descricaoCategoria;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref this._descricaoCategoria, value);
            }
        }
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

        private string _descricaoSubCategoria;
        public string DescricaoSubCategoria
        {
            get
            {
                return this._descricaoSubCategoria;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref this._descricaoSubCategoria, value);
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

        private string _descricaoCampo;
        public string DescricaoCampo
        {
            get
            {
                return this._descricaoCampo;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref this._descricaoCampo, value);
            }
        }
        private string _ordemCampo;
        public string OrdemCampo
        {
            get
            {
                return this._ordemCampo;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref this._ordemCampo, value);
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
        private IDictionary<string, TipoCampo> _tiposCampo;
        public IDictionary<string, TipoCampo> TiposCampo
        {
            get
            {
                return this._tiposCampo;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref this._tiposCampo, value);
            }
        }
        private TipoCampo _tipoCampo;
        public TipoCampo TipoCampo
        {
            get
            {
                return this._tipoCampo;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref this._tipoCampo, value);
            }
        }
        private Campo _campoSelecionado;
        public Campo CampoSelecionado
        {
            get
            {
                return this._campoSelecionado;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref this._campoSelecionado, value);
            }
        }

        private string _descricaoOpcao;
        public string DescricaoOpcao
        {
            get
            {
                return this._descricaoOpcao;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref this._descricaoOpcao, value);
            }
        }
        private List<OpcoesCampo> _opcoes;
        public List<OpcoesCampo> Opcoes
        {
            get
            {
                return this._opcoes;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref this._opcoes, value);
            }
        }
        private OpcoesCampo _opcaoSelecionada;
        public OpcoesCampo OpcaoSelecionada
        {
            get
            {
                return this._opcaoSelecionada;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref this._opcaoSelecionada, value);
            }
        }
        #endregion

        public AdministrativoViewModel()
        {
            this.ObterCategorias();
            
            this.TiposCampo = Helper.Enum.ToDictionary<TipoCampo>();

            this.AdicionarCategoriaCommand = this.CreateCommand(this.WhenAny(vm => vm.DescricaoCategoria, s => !string.IsNullOrWhiteSpace(s.Value)), this.AdicionarCategoria);
            this.AdicionarSubCategoriaCommand = this.CreateCommand(this.WhenAny(vm => vm.DescricaoSubCategoria, s => !string.IsNullOrWhiteSpace(s.Value)), this.AdicionarSubCategoria);
            this.AdicionarCampoCommand = this.CreateCommand(this.WhenAny(vm => vm.DescricaoCampo, s => !string.IsNullOrWhiteSpace(s.Value)), this.AdicionarCampo);
            this.AdicionarOpcaoCommand = this.CreateCommand(this.WhenAny(vm => vm.DescricaoOpcao, s => !string.IsNullOrWhiteSpace(s.Value)), this.AdicionarOpcao);
            
            this.RemoverCategoriaCommand = this.CreateCommand(this.WhenAny(vm => vm.CategoriaSelecionada, s => s.Value != null), this.RemoverCategoria);
            this.RemoverSubCategoriaCommand = this.CreateCommand(this.WhenAny(vm => vm.SubCategoriaSelecionada, s => s.Value != null), this.RemoverSubCategoria);
            this.RemoverCampoCommand = this.CreateCommand(this.WhenAny(vm => vm.CampoSelecionado, s => s.Value != null), this.RemoverCampo);
            this.RemoverOpcaoCommand = this.CreateCommand(this.WhenAny(vm => vm.OpcaoSelecionada, s => s.Value != null), this.RemoverOpcao);
        }

        #region Metodos
        private void AdicionarCategoria()
        {
            if (Categorias == null)
                Categorias = new List<Categoria>();

            var data = new CategoriaData();
            var categoriaAdd = new Categoria() { Descricao = DescricaoCategoria };
            data.Adicionar(categoriaAdd);
            DescricaoCategoria = string.Empty;
            Categorias = new List<Categoria>(data.Obter());
        }
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
        private void RemoverCategoria()
        {
            var data = new CategoriaData();
            data.Excluir(CategoriaSelecionada.Id);
            Categorias = new List<Categoria>(data.Obter());
        }

        private void AdicionarSubCategoria()
        {
            if (CategoriaSelecionada == null)
                return;

            if (SubCategorias == null)
                SubCategorias = new List<SubCategoria>();

            var data = new SubCategoriaData();
            var subCategoriaAdd = new SubCategoria(){ Descricao = DescricaoSubCategoria, CategoriaId = CategoriaSelecionada.Id};
            data.Adicionar(subCategoriaAdd);
            DescricaoSubCategoria = string.Empty;
            SubCategorias = new List<SubCategoria>(data.ObterPorCategoriaId(CategoriaSelecionada.Id));
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
        private void RemoverSubCategoria()
        {
            var data = new SubCategoriaData();
            data.Excluir(SubCategoriaSelecionada.Id);
            SubCategorias = new List<SubCategoria>(data.ObterPorCategoriaId(CategoriaSelecionada.Id));
        }

        private void AdicionarCampo()
        {
            if (SubCategoriaSelecionada == null || string.IsNullOrWhiteSpace(OrdemCampo))
                return;

            if (Campos == null)
                Campos = new List<Campo>();

            var data = new CampoData();
            var campoAdd = new Campo() { Descricao = DescricaoCampo, Ordem = Convert.ToInt32(OrdemCampo), Tipo = TipoCampo, SubCategoriaId = SubCategoriaSelecionada.Id, Opcoes = Opcoes };
            data.Adicionar(campoAdd);
            DescricaoCampo = string.Empty;
            OrdemCampo = string.Empty;
            Opcoes = null;
            Campos = new List<Campo>(data.ObterPorSubCategoriaId(SubCategoriaSelecionada.Id));
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
        private void RemoverCampo()
        {
            var data = new CampoData();
            data.Excluir(CampoSelecionado.Id);
            Campos = new List<Campo>(data.ObterPorSubCategoriaId(SubCategoriaSelecionada.Id));
        }

        private void AdicionarOpcao()
        {
            if (Opcoes == null)
                Opcoes = new List<OpcoesCampo>();

            Opcoes.Add(new OpcoesCampo() { Descricao = DescricaoOpcao });
            Opcoes = new List<OpcoesCampo>(Opcoes);
            DescricaoOpcao = string.Empty;
        }
        private void RemoverOpcao()
        {
            Opcoes.Remove(OpcaoSelecionada);
            Opcoes = new List<OpcoesCampo>(Opcoes);
        }
        #endregion    
    }
}