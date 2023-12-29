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
            Produto prod = new Produto("Teste", (float)14.60, 2, 1, 1);

            //Act
            bool resultado = Stock.AdicionarProduto(prod);

            Console.WriteLine("{0}", resultado.ToString());

        }
    }
}
