using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GregTreinamentoCamadas.Persistencia;

namespace GregTreinamentoCamadas.Business
{
    public class ProdutoLogica
    {
        public int VerificarTotal(int idCategoria)
        {
            var dao = new ProdutoDAO();

            return dao.VerificarTotal(idCategoria);
        }
    }
}