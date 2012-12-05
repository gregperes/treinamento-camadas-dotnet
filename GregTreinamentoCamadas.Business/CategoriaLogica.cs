using System;
using System.Collections.Generic;
using GregTreinamentoCamadas.Entidade;
using GregTreinamentoCamadas.Persistencia;

namespace GregTreinamentoCamadas.Business
{
    public class CategoriaLogica
    {
        public IList<Categoria> Listar()
        {
            var dao = new CategoriaDAO();

            return dao.Listar();
        }

        public Categoria Selecionar(int id)
        {
            var dao = new CategoriaDAO();

            return dao.Selecionar(id);
        }
            
        public void Incluir(Categoria categoria)
        {
            // TODO: Validar se a categoria não está nula
            // Verificar tamanho dos campos antes de fazer a inclusao/edicao

            if (string.IsNullOrEmpty(categoria.Nome))
            {
                throw new Exception("O nome da categoria nao pode ser nulo ou vazio!");
            }

            if (categoria.Nome.Length > 50)
            {
                throw new Exception("O nome da categoria deve ser menor que 50 chars!");
            }

            categoria.Status = StatusCategoria.Pendente;

            var dao = new CategoriaDAO();
            var existente = dao.Selecionar(categoria.Nome);

            if (existente != null)
            {
                throw new Exception("Categoria ja existente!");
            }

            dao.Incluir(categoria);
        }

        public void Editar(Categoria categoria)
        {
             //TODO: Colocar validacoes de negocio
            
            var dao = new CategoriaDAO();
            
            dao.Editar(categoria);
        }

        public void Excluir(Categoria categoria)
        {
            //TODO: Colocar validacoes de negocio
            // Verificar se a categoria existe no banco
            // Verificar se a categoria possui algum registro de produto relacionado

            var dao = new CategoriaDAO();
            
            dao.Excluir(categoria);
        }
    }
}