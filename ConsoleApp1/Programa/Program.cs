using ObjetosNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RN;
using Dados;

namespace Programa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Categoria categoria = new Categoria("Geral");
            Marca marca = new Marca("Nike", "Barcelos");
            Marca marca1 = new Marca("Adidas", "Barcelos");
            Marca marca2 = new Marca("versace", "Barcelos");
            Fornecedor fornecedor = new Fornecedor("IPCA", "Barcelos", 509200300, 932821001);
            Fornecedor fornecedor1 = new Fornecedor("Teste", "Barcelos", 509300200, 932821002);
            Cliente cliente = new Cliente("Ruben Costa", "Barcelos", 123456789, 912345678);
            Cliente cliente1 = new Cliente("Fabio Lopes", "Barcelos", 123456788, 912345672);

            RegrasNegocio.AdicionarCategoria(categoria);
            RegrasNegocio.AdicionarMarca(marca);
            RegrasNegocio.AdicionarMarca(marca1);
            RegrasNegocio.AdicionarMarca(marca2);
            RegrasNegocio.AdicionarFornecedor(fornecedor);
            RegrasNegocio.AdicionarFornecedor(fornecedor1);
            RegrasNegocio.AdicionarCliente(cliente);
            RegrasNegocio.AdicionarCliente(cliente1);

            List<Marca> marcas = new List<Marca>();
            List<Categoria> categorias = new List<Categoria>();
            List<Fornecedor> fornecedores = new List<Fornecedor>();
            List<Cliente> clientes = new List<Cliente>();


            marcas = Marcas.ListaMarcas;
            categorias = Categorias.ListaCategorias;
            fornecedores = Fornecedores.ListaFornecedores;
            clientes = Clientes.ListaClientes;

                 
        }
    }
}
