using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GregTreinamentoCamadas.Entidade
{
    public class Categoria
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public StatusCategoria Status { get; set; }

        public Categoria()
        {
        }
    }
}