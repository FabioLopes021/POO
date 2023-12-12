using ClassLibrary1;
using System;

namespace Aula_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            Produto p = new Produto(1, "teste", 0, 2);
            i = p.InserirProduto();
            Produto q = new Produto(2, "teste1", 0, 2);
            i = q.InserirProduto();

            Produto.showProdutos();



            Console.WriteLine("Separaçao teste dos objetos:");
            p.showProduto();
            q.showProduto();

        }
    }
}
