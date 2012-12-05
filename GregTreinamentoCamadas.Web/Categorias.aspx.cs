using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GregTreinamentoCamadas.Business;
using GregTreinamentoCamadas.Entidade;

namespace GregTreinamentoCamadas.Web
{
    public partial class Categorias : System.Web.UI.Page
    {
        private void PopularCategorias()
        {
            var logica = new CategoriaLogica();
            var lista = logica.Listar();

            this.CategoriasGridView.DataSource = lista;
            this.CategoriasGridView.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.PopularCategorias();
            }
        }

        protected void SalvarButton_Click(object sender, EventArgs e)
        {
            try
            {
                var categoria = new Categoria();
                categoria.Nome = this.NomeTextBox.Text;

                var logica = new CategoriaLogica();

                if (!string.IsNullOrEmpty(this.IdTextBox.Text))
                { 
                    categoria.Id = int.Parse(this.IdTextBox.Text);
                }

                if (categoria.Id > 0)
                {
                    logica.Editar(categoria);
                }
                else
                {
                    logica.Incluir(categoria);
                }

                this.IdTextBox.Text = string.Empty;
                this.NomeTextBox.Text = string.Empty;

                this.PopularCategorias();
            }
            catch (Exception ex)
            {
                this.MensagemLabel.Text = ex.Message;
            }
        }

        protected void CategoriasGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var logica = new CategoriaLogica();
            var id = int.Parse(e.CommandArgument.ToString());

            if (e.CommandName == "Editar")
            {
                var categoria = logica.Selecionar(id);

                if (categoria != null)
                {
                    this.IdTextBox.Text = categoria.Id.ToString();
                    this.NomeTextBox.Text = categoria.Nome;
                }
            }
            else if (e.CommandName == "Excluir")
            {
                var categoria = new Categoria();
                categoria.Id = id;

                logica.Excluir(categoria);

                this.PopularCategorias();
            }
        }
    }
}