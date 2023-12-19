using ObjetosNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RN;
using Dados;
using System.ComponentModel;
using System.Collections;

namespace Programa
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Carregadados


            RegrasNegocio.CarregarCategorias();
            RegrasNegocio.CarregarClientes();
            RegrasNegocio.CarregarCompras();
            RegrasNegocio.CarregarFornecedores();
            RegrasNegocio.CarregarMarcas();
            RegrasNegocio.CarregarStock();
            RegrasNegocio.CarregarVendas();


            #endregion


            #region Criar dados Teste Iniciais
            /*
            // Adicionar Categoria
            Categoria categoria = new Categoria("Geral");
            RegrasNegocio.AdicionarCategoria(categoria);

            //Adicionar Marcas
            Marca marca = new Marca("Nike", "Barcelos");
            RegrasNegocio.AdicionarMarca(marca);
            Marca marca1 = new Marca("Adidas", "Barcelos");
            RegrasNegocio.AdicionarMarca(marca1);
            Marca marca2 = new Marca("versace", "Barcelos");
            RegrasNegocio.AdicionarMarca(marca2);

            //Adicionar Fornecedores
            Fornecedor fornecedor = new Fornecedor("IPCA", "Barcelos", 509200300, 932821001);
            RegrasNegocio.AdicionarFornecedor(fornecedor);
            Fornecedor fornecedor1 = new Fornecedor("Teste", "Barcelos", 509300200, 932821002);
            RegrasNegocio.AdicionarFornecedor(fornecedor1);


            //Adicionar Clientes
            Cliente cliente = new Cliente("Ruben Costa", "Barcelos", 123456789, 912345678);
            RegrasNegocio.AdicionarCliente(cliente);
            Cliente cliente1 = new Cliente("Fabio Lopes", "Barcelos", 123456788, 912345672);
            RegrasNegocio.AdicionarCliente(cliente1);

            #endregion

            #region Crias dados teste compras e vendas
            Produto pr = new Produto("Jantes",(float)999.99, 3, 1, 1);
            Produto pr1 = new Produto("Pneus", (float)149.99, 2, 1, 2);

            RegrasNegocio.AdicionarProduto(pr);
            RegrasNegocio.AdicionarProduto(pr1);


            //teste de compra
            Compra comp = new Compra("Teste", DateTime.Now, 1);
            comp.AdicionarProdutoCompra(1, 4);
            comp.AdicionarProdutoCompra(2, 4);
            RegrasNegocio.AdicionarCompra(comp);
            
            
            //teste de venda
            Venda vend = new Venda("Teste", DateTime.Now, 1);
            vend.AdicionarProdutoVenda(1, 2);
            vend.AdicionarProdutoVenda(2, 1);
            RegrasNegocio.AdicionarVenda(vend);
            */


            #endregion



            MenuTestes.MenuRunner();




            #region Verificar valores 
            
            /*
            List<Marca> marcas = new List<Marca>();
            List<Categoria> categorias = new List<Categoria>();
            List<Fornecedor> fornecedores = new List<Fornecedor>();
            List<Cliente> clientes = new List<Cliente>();
            List<Produto> stock = new List<Produto>();
            


            List<Compra> compras = new List<Compra>();
            List<Venda> vendas = new List<Venda>();
            
            /*
            marcas = Marcas.ListaMarcas;
            categorias = Categorias.ListaCategorias;
            fornecedores = Fornecedores.ListaFornecedores;
            clientes = Clientes.ListaClientes;
            stock = Stock.ListaProdutos;
            

            compras = Compras.ListaCompras;
            vendas = Vendas.ListaVendas;
            */

            #endregion


            #region guardarDados
            /*
            RegrasNegocio.GuardarCategorias();
            RegrasNegocio.GuardarClientes();
            RegrasNegocio.GuardarCompras();
            RegrasNegocio.GuardarFornecedores();
            RegrasNegocio.GuardarMarcas();
            RegrasNegocio.GuardarStock();
            RegrasNegocio.GuardarVendas();
            */

            #endregion


        }
    }
}
