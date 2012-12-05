using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using GregTreinamentoCamadas.Entidade;

namespace GregTreinamentoCamadas.Persistencia
{
    public class CategoriaDAO : BaseDAO
    {
        public IList<Categoria> Listar()
        {
            var query = "SELECT * FROM Categoria";
            var command = new SqlCommand(query);

            var dt = this.ExecuteDataTable(command);
            var lista = new List<Categoria>();

            foreach (DataRow row in dt.Rows)
            {
                var categoria = new Categoria();
                categoria.Id = int.Parse(row["Id"].ToString());
                categoria.Nome = row["Nome"].ToString();
                categoria.Status = (StatusCategoria)int.Parse(dt.Rows[0]["Status"].ToString());

                lista.Add(categoria);
            }

            return lista;
        }

        public Categoria Selecionar(int id)
        {
            var query = "SELECT * FROM Categoria WHERE Id = @Id";
            var command = new SqlCommand(query);

            command.Parameters.Add(new SqlParameter("@Id", id));

            var dt = this.ExecuteDataTable(command);

            if (dt.Rows.Count == 0)
            {
                return null;
            }

            var categoria = new Categoria();
            categoria.Id = int.Parse(dt.Rows[0]["Id"].ToString());
            categoria.Nome = dt.Rows[0]["Nome"].ToString();
            categoria.Status = (StatusCategoria)int.Parse(dt.Rows[0]["Status"].ToString());

            return categoria;
        }

        public Categoria Selecionar(string nome)
        {
            var query = "SELECT * FROM Categoria WHERE Nome = @Nome";
            var command = new SqlCommand(query);

            command.Parameters.Add(new SqlParameter("@Nome", nome));

            var dt = this.ExecuteDataTable(command);

            if (dt.Rows.Count == 0)
            {
                return null;
            }

            var categoria = new Categoria();
            categoria.Id = int.Parse(dt.Rows[0]["Id"].ToString());
            categoria.Nome = dt.Rows[0]["Nome"].ToString();
            categoria.Status = (StatusCategoria)int.Parse(dt.Rows[0]["Status"].ToString());

            return categoria;
        }
            
        public void Incluir(Categoria categoria)
        {
            var query = "INSERT INTO Categoria (Nome, Status) VALUES (@Nome, @Status)";
            var command = new SqlCommand(query);

            command.Parameters.Add(new SqlParameter("@Nome", categoria.Nome));
            command.Parameters.Add(new SqlParameter("@Status", categoria.Status));

            this.ExecuteNonQuery(command);
        }

        public void Editar(Categoria categoria)
        {
            var query = "UPDATE Categoria SET Nome = @Nome WHERE Id = @Id";
            var command = new SqlCommand(query);

            command.Parameters.Add(new SqlParameter("@Nome", categoria.Nome));
            command.Parameters.Add(new SqlParameter("@Id", categoria.Id));

            this.ExecuteNonQuery(command);
        }

        public void Excluir(Categoria categoria)
        {
            var query = "DELETE FROM Categoria WHERE Id = @Id";
            var command = new SqlCommand(query);

            command.Parameters.Add(new SqlParameter("@Id", categoria.Id));

            this.ExecuteNonQuery(command);
        }
    }
}