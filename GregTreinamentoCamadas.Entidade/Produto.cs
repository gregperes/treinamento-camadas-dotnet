using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GregTreinamentoCamadas.Entidade
{
    public class Produto
    {
        public int Id { get; set; }

        public int IdCategoria { get; set; }

        public string Nome { get; set; }

        public decimal Valor { get; set; }

        public string Descricao { get; set; }

        public Categoria Categoria { get; set; }
    }
}