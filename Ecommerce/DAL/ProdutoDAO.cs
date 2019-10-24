

using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.DAL
{
    public class ProdutoDAO
    {

        private readonly Context _context;

        public ProdutoDAO(Context context)
        {
            _context = context;        
        }

        public void CadastrarProduto(Produto p)
        {
            _context.Produtos.Add(p);
            _context.SaveChanges();
        }

        public List<Produto> Listar()
        {
            return _context.Produtos.ToList();
        }
        public Produto BuscarPorId(int? id)
        {
            /*foreach (Produto produto in Listar())
            {
                if (produto.Id == id)
                {
                    return produto;
                }
            }*/

            Produto p = _context.Produtos.Find(id);

            if (p != null)
            {
                return p;
            }
            else
            {
                return null;
            }
        }

        public void Remover(int? id)
        {
            _context.Produtos.Remove(BuscarPorId(id));
            _context.SaveChanges();
        }

        public void Alterar(Produto produto)
        {
            _context.Produtos.Update(produto);
            _context.SaveChanges();
        }

        internal Produto BuscarPorNome(string nome)
        {
            foreach (Produto produto in Listar())
            {
                if (produto.Nome == nome)
                {
                    return produto;
                }
            }

            return null;
        }
    }
}
