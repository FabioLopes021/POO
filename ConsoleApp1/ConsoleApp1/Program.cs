using ObjetosNegocio;
using RegrasNegocio;
using System;

namespace FrontEnd
{
    class Program
    {
        static void Main(string[] args)
        {
            Categoria categoria = new Categoria("Geral");
            Marca marca = new Marca("Nike","Barcelos");
            Marca marca1 = new Marca("Adidas","Barcelos");
            Marca marca2 = new Marca("versace","Barcelos");
            Fornecedor fornecedor = new Fornecedor("IPCA","Barcelos", 509200300, 932821001);
            Fornecedor fornecedor1 = new Fornecedor("Teste","Barcelos", 509300200, 932821002);
            Cliente cliente = new Cliente("Ruben Costa", "Barcelos", 123456789, 912345678);
            Cliente cliente1 = new Cliente("Fabio Lopes", "Barcelos", 123456788, 912345672);

           
            

        }
    }
}
