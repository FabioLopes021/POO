using Dados;
using ObjetosNegocio;
using System;

namespace Helpteste
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Arrange
            Categoria cat = new Categoria("Geral");
            Marca mar = new Marca("Barcelos","Nike");

            //Act
            Marcas.GuardarMarca(mar);
            Categorias.guardarCategoria(cat);

            //Arrange

            Produto p = new Produto("Teste1", (float)10.1, 2, 1, 1);
            Stock.AdicionarProduto(p);


            //Act
            Stock.AumentarQuantidade(1, 10);

            Console.WriteLine("{0}", p.Quantidade);
        }
    }
}
