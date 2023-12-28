/*
*	<copyright file="RegrasNegocio.cs" company="IPCA">
*	Copyright (c) 2023 All Rights Reserved
*	</copyright>
* 	<author>Fábio Lopes & Ruben Costa</author>
*   <date>13/12/2023</date>
*	<description></description>
*/

using Dados;
using Excecoes;
using ObjetosNegocio;
using System;
using System.Collections.Generic;

namespace RN
{
    /// <summary>
    /// Purpose: 
    /// Created by: Fábio Lopes & Ruben Costa
    /// Created on: 13/12/2023
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class RegrasNegocio
    {
        #region Attributes
        #endregion

        #region Methods

        #region Constructors
        #endregion

        #region Properties
        #endregion

        #region Operators
        #endregion

        #region Overrides
        #endregion

        #region Other_Methods


        //Não implementar
        /// <summary>
        /// Metodo para remover um produto do Stock
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        /// <exception cref="StockExcecoes"></exception>
        public static bool RemoverProduto(int id)
        {
            if (id < 0)
                throw new StockExcecoes("Falha de Regras de Negocio (null data em Produto)");
            
            try
            {
                Stock.RemoverProduto(id);
            }
            catch (StockExcecoes e)
            {
                throw new StockExcecoes("Passou nas Regras de Negocio " + "-" + e.Message);
            }

            return true;
        }



        /// <summary>
        /// Metodo para adicionar uma marca a lista de marcas
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        /// <exception cref="MarcasExcecoes"></exception>
        public static bool AdicionarMarca(Marca m)
        {
            if (ReferenceEquals(m, null))
                throw new MarcasExcecoes("Falha de Regras de Negocio (null data em Marca)");

            bool aux = false;
            try
            {
                aux = Marcas.GuardarMarca(m);
            }
            catch (MarcasExcecoes e)
            {
                throw new MarcasExcecoes("Passou nas Regras de Negocio " + "-" + e.Message);
            }

            return aux;
        }


        /// <summary>
        /// Metodo para adicionar uma Categoria a lista de Categorias
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        /// <exception cref="CategoriasExcecoes"></exception>
        public static bool AdicionarCategoria(Categoria c)
        {
            if (ReferenceEquals(c,null))
                throw new CategoriasExcecoes("Falha de Regras de Negocio (null data em Categoria)");

            bool aux = false;
            try
            {
                aux = Categorias.guardarCategoria(c);
            }
            catch (CategoriasExcecoes e)
            {
                throw new CategoriasExcecoes("Passou nas Regras de Negocio " + "-" + e.Message);
            }

            return aux;
        }


        /// <summary>
        /// Metodo para adicionar um Fornecedor a lista de Fornecedores
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        /// <exception cref="FornecedoresExcecoes"></exception>
        public static bool AdicionarFornecedor(Fornecedor f)
        {
            if (ReferenceEquals(f, null))
                throw new FornecedoresExcecoes("Falha de Regras de Negocio (null data em Fornecedor)");

            bool aux = false;
            try
            {
                aux = Fornecedores.RegistarFornecedor(f);
            }
            catch (FornecedoresExcecoes e)
            {
                throw new FornecedoresExcecoes("Passou nas Regras de Negocio " + "-" + e.Message);
            }

            return aux;
        }



        /// <summary>
        /// Metodo para adicionar um Produto a lista de Produtos
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        /// <exception cref="StockExcecoes"></exception>
        public static bool AdicionarProduto(Produto p)
        {
            if (ReferenceEquals(p, null))
                throw new StockExcecoes("Falha de Regras de Negocio (null data)");

            try
            {
                Stock.AdicionarProduto(p);
            }
            catch (StockExcecoes e)
            {
                throw new StockExcecoes("Passou nas Regras de Negocio " + "-" + e.Message);
            }

            return true;
        }


        /// <summary>
        /// Metodo para adicionar um Cliente a lista de Clientes
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        /// <exception cref="ClientesExcecoes"></exception>
        public static bool AdicionarCliente(Cliente c)
        {
            if (ReferenceEquals(c, null))
                throw new ClientesExcecoes("Falha de Regras de Negocio (null data em Cliente)");

            bool aux = false;
            try
            {
                aux = Clientes.RegistarCliente(c);
            }
            catch (ClientesExcecoes e)
            {
                throw new ClientesExcecoes("Passou nas Regras de Negocio " + "-" + e.Message);
            }
 
            return aux;
        }



        /// <summary>
        /// Metodo para adicionar uma compra a lista de compras
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        /// <exception cref="ComprasExcecoes"></exception>
        public static bool AdicionarCompra(Compra c)
        {
            if (ReferenceEquals(c, null))
                throw new ComprasExcecoes("Falha de Regras de Negocio (null data em Compra)");

            
            bool aux = false;
            try
            {
                aux = Compras.RegistarCompra(c);
            }
            catch (ComprasExcecoes e)
            {
                throw new ComprasExcecoes("Passou nas Regras de Negocio " + "-" + e.Message);
            }

            return aux;
        }



        /// <summary>
        /// Metodo para adicionar uma venda a lista de vendas
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        /// <exception cref="VendasExcecoes"></exception>
        public static bool AdicionarVenda(Venda v)
        {
            if (ReferenceEquals(v, null))
                throw new VendasExcecoes("Falha de Regras de Negocio (null data em Venda)");


            bool aux = false;
            try
            {
                aux = Vendas.RegistarVenda(v);
            }
            catch (VendasExcecoes e)
            {
                throw new VendasExcecoes("Passou nas Regras de Negocio " + "-" + e.Message);
            }

            return aux;
        }



        /// <summary>
        /// Metodo para Guardar os  dados da classe stock
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool GuardarStock(string file)
        {
            bool aux = false;

            try
            {
                aux = Stock.GuardarStock(file);
            }
            catch (Exception e)
            {
                throw new Exception("Passou nas Regras de Negocio " + "-" + e.Message);
            }

            return aux;
        }


        /// <summary>
        /// Metodo Para carregar os dados da classe stock
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool CarregarStock(string file)
        {
            bool aux = false;

            try
            {
                aux = Stock.CarregaStock(file);
            }
            catch (Exception e)
            {
                throw new Exception("Passou nas Regras de Negocio " + "-" + e.Message);
            }

            

            return aux;
        }


        /// <summary>
        /// Metodo para Guardar os  dados da classe Vendas
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool GuardarVendas(string file)
        {
            bool aux = false;

            try
            {
                aux = Vendas.GuardarVendas(file);
            }
            catch (Exception e)
            {
                throw new Exception("Passou nas Regras de Negocio " + "-" + e.Message);
            }

            

            return aux;
        }


        /// <summary>
        /// Metodo Para carregar os dados da classe Vendas
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool CarregarVendas(string file)
        {
            bool aux = false;

            try
            {
                aux = Vendas.CarregaVendas(file);
            }
            catch (Exception e)
            {
                throw new Exception("Passou nas Regras de Negocio " + "-" + e.Message);
            }

            

            return aux;
        }


        /// <summary>
        /// Metodo para Guardar os  dados da classe Marcas
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool GuardarMarcas(string file)
        {
            bool aux = false;

            try
            {
                aux = Marcas.GuardarMarcas(file);
            }
            catch (Exception e)
            {
                throw new Exception("Passou nas Regras de Negocio " + "-" + e.Message);
            }

            

            return aux;
        }


        /// <summary>
        /// Metodo Para carregar os dados da classe Marcas
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool CarregarMarcas(string file)
        {
            bool aux = false;

            try
            {
                aux = Marcas.CarregaMarcas(file);
            }
            catch (Exception e)
            {
                throw new Exception("Passou nas Regras de Negocio " + "-" + e.Message);
            }

            

            return aux;
        }


        /// <summary>
        /// Metodo para Guardar os  dados da classe Fornecedores
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool GuardarFornecedores(string file)
        {
            bool aux = false;

            try
            {
                aux = Fornecedores.GuardarFornecedores(file);
            }
            catch (Exception e)
            {
                throw new Exception("Passou nas Regras de Negocio " + "-" + e.Message);
            }

            

            return aux;
        }


        /// <summary>
        /// Metodo Para carregar os dados da classe Fornecedores
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool CarregarFornecedores(string file)
        {
            bool aux = false;

            try
            {
                aux = Fornecedores.CarregaFornecedores(file);
            }
            catch (Exception e)
            {
                throw new Exception("Passou nas Regras de Negocio " + "-" + e.Message);
            }

            

            return aux;
        }



        /// <summary>
        /// Metodo para Guardar os  dados da classe Compras
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool GuardarCompras(string file)
        {
            bool aux = false;

            try
            {
                aux = Compras.GuardarCompras(file);
            }
            catch (Exception e)
            {
                throw new Exception("Passou nas Regras de Negocio " + "-" + e.Message);
            }

            

            return aux;
        }

        /// <summary>
        /// Metodo Para carregar os dados da classe Compras
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool CarregarCompras(string file)
        {
            bool aux = false;

            try
            {
                aux = Compras.CarregaCompras(file);
            }
            catch (Exception e)
            {
                throw new Exception("Passou nas Regras de Negocio " + "-" + e.Message);
            }

            

            return aux;
        }

        /// <summary>
        /// Metodo para Guardar os  dados da classe Clientes
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool GuardarClientes(string file)
        {
            bool aux = false;

            try
            {
                aux = Clientes.GuardarClientes(file);
            }
            catch (Exception e)
            {
                throw new Exception("Passou nas Regras de Negocio " + "-" + e.Message);
            }

            

            return aux;
        }


        /// <summary>
        /// Metodo Para carregar os dados da classe Clientes
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool CarregarClientes(string file)
        {
            bool aux = false;

            try
            {
                aux = Clientes.CarregaClientes(file);
            }
            catch (Exception e)
            {
                throw new Exception("Passou nas Regras de Negocio " + "-" + e.Message);
            }

            

            return aux;
        }

        /// <summary>
        /// Metodo para Guardar os  dados da classe Categorias
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool GuardarCategorias(string file)
        {
            bool aux = false;

            try
            {
                aux = Categorias.GuardarCategorias(file);
            }
            catch (Exception e)
            {
                throw new Exception("Passou nas Regras de Negocio " + "-" + e.Message);
            }

            

            return aux;
        }

        /// <summary>
        /// Metodo Para carregar os dados da classe Categorias
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool CarregarCategorias(string file)
        {
            bool aux = false;

            try
            {
                aux = Categorias.CarregaCategorias(file);
            }
            catch (Exception e)
            {
                throw new Exception("Passou nas Regras de Negocio " + "-" + e.Message);
            }

            

            return aux;
        }


        /// <summary>
        /// Metodo que retorna uma copia da lista de categorias
        /// </summary>
        /// <returns></returns>
        public static List<Categoria> ListaCategorias()
        {
            return Categorias.ListaCategorias;
        }

        /// <summary>
        /// Metodo que retorna uma copia da lista de Marcas
        /// </summary>
        /// <returns></returns>
        public static List<Marca> ListaMarcas()
        {
            return Marcas.ListaMarcas;
        }


        /// <summary>
        /// Metodo que retorna uma copia da lista de Fornecedores
        /// </summary>
        /// <returns></returns>
        public static List<Fornecedor> ListaFornecedores()
        {
            return Fornecedores.ListaFornecedores;
        }


        /// <summary>
        /// Metodo que retorna uma copia da lista de Clientes
        /// </summary>
        /// <returns></returns>
        public static List<Cliente> ListaClientes()
        {
            return Clientes.ListaClientes;
        }


        /// <summary>
        /// Metodo que retorna uma copia da lista de Produtos
        /// </summary>
        /// <returns></returns>
        public static List<Produto> ListaProdutos()
        {
            return Stock.ListaProdutos;
        }

        /// <summary>
        /// Metodo que retorna uma copia da lista de Vendas
        /// </summary>
        /// <returns></returns>
        public static List<Venda> ListaVendas()
        {
            return Vendas.ListaVendas;
        }

        /// <summary>
        /// Metodo que retorna uma copia da lista de Compras
        /// </summary>
        /// <returns></returns>
        public static List<Compra> ListaCompras()
        {
            return Compras.ListaCompras;
        }



        /// <summary>
        /// Metodo que retorna uma copia da lista de categorias
        /// </summary>
        /// <returns></returns>
        public static int NumCategorias()
        {
            return Categorias.ListaCategorias.Count;
        }

        /// <summary>
        /// Metodo que retorna uma copia da lista de Marcas
        /// </summary>
        /// <returns></returns>
        public static int NumMarcas()
        {
            return Marcas.ListaMarcas.Count;
        }


        /// <summary>
        /// Metodo que retorna uma copia da lista de Fornecedores
        /// </summary>
        /// <returns></returns>
        public static int NumFornecedores()
        {
            return Fornecedores.ListaFornecedores.Count;
        }


        /// <summary>
        /// Metodo que retorna uma copia da lista de Clientes
        /// </summary>
        /// <returns></returns>
        public static int NumClientes()
        {
            return Clientes.ListaClientes.Count;
        }


        /// <summary>
        /// Metodo que retorna uma copia da lista de Produtos
        /// </summary>
        /// <returns></returns>
        public static int NumProdutos()
        {
            return Stock.ListaProdutos.Count;
        }

        /// <summary>
        /// Metodo que retorna uma copia da lista de Vendas
        /// </summary>
        /// <returns></returns>
        public static int NumVendas()
        {
            return Vendas.ListaVendas.Count;
        }

        /// <summary>
        /// Metodo que retorna uma copia da lista de Compras
        /// </summary>
        /// <returns></returns>
        public static int NumCompras()
        {
            return Compras.ListaCompras.Count;
        }



        /// <summary>
        /// Metodo que retorna o Produto correspondente a um determinado id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Produto ProdutoPorId(int id)
        {
            if(id < 0)
            {
                return null;
            }

            return Stock.ProdutoPorId(id);

        }

        
        public static bool ExisteProdutoPorId(int id)
        {
            return Stock.ExisteProdutoPorId(id);
        }


        public static Venda VendaPorId(int id)
        {
            if (id < 0)
            {
                return null;
            }

            return Vendas.VendaPorId(id);

        }


        public static Marca MarcaPorId(int id)
        {
            if (id < 0)
            {
                return null;
            }

            return Marcas.MarcaPorId(id);

        }


        public static bool ExisteMarcaPorId(int id)
        {
            return Marcas.VerificaMarcaPorId(id);
        }

        public static Fornecedor FornecedorPorId(int id)
        {
            if (id < 0)
            {
                return null;
            }

            return Fornecedores.FornecedorPorId(id);
        }


        public static bool ExisteFornecedorPorId(int id)
        {
            return Fornecedores.VerificaFornecedorId(id);
        }

        public static Cliente ClientePorId(int id)
        {
            if (id < 0)
            {
                return null;
            }

            return Clientes.ClientePorId(id);

        }


        public static bool ExisteClientePorId(int id)
        {
            return Clientes.VerificaClienteId(id);
        }


        public static Categoria CategoriaPorId(int id)
        {
            if (id < 0)
            {
                return null;
            }

            return Categorias.CategoriaPorId(id);

        }


        public static bool ExisteCategoriaPorId(int id)
        {
            return Categorias.VerificaCategoriaPorId(id);
        }


        public static Compra CompraPorId(int id)
        {
            if (id < 0)
            {
                return null;
            }

            return Compras.CompraPorId(id);

        }





        public static bool AlterarNomeFornecedor(int id, string nome)
        {
            if (id < 0 || nome == "")
                return false;

            bool aux = false;

            Fornecedor f = Fornecedores.FornecedorPorId(id);

            if(!ReferenceEquals(f,null))
                aux = f.AlterarNome(nome);


            return aux;

        }

        public static bool AlterarMoradaFornecedor(int id, string morada)
        {
            if (id < 0 || morada == "")
                return false;

            bool aux = false;

            Fornecedor f = Fornecedores.FornecedorPorId(id);

            if (!ReferenceEquals(f, null))
                aux = f.AlterarMorada(morada);


            return aux;

        }


        public static bool AlterarNIFFornecedor(int id, int nif)
        {
            if (id < 0 || nif < 0)
                return false;

            bool aux = false;

            Fornecedor f = Fornecedores.FornecedorPorId(id);

            if (!ReferenceEquals(f, null))
                aux = f.AlterarNif(nif);


            return aux;

        }


        public static bool AlterarTelemovelFornecedor(int id, int tel)
        {
            if (id < 0 || tel < 0)
                return false;

            bool aux = false;

            Fornecedor f = Fornecedores.FornecedorPorId(id);

            if (!ReferenceEquals(f, null))
                aux = f.AlterarTelemovel(tel);


            return aux;

        }


        public static bool AlterarNomeCliente(int id, string nome)
        {
            if (id < 0 || nome == "")
                return false;

            bool aux = false;

            Cliente c = Clientes.ClientePorId(id);

            if (!ReferenceEquals(c, null))
                aux = c.AlterarNome(nome);


            return aux;

        }

        public static bool AlterarMoradaCliente(int id, string morada)
        {
            if (id < 0 || morada == "")
                return false;

            bool aux = false;

            Cliente c = Clientes.ClientePorId(id);

            if (!ReferenceEquals(c, null))
                aux = c.AlterarMorada(morada);


            return aux;

        }


        public static bool AlterarNIFCliente(int id, int nif)
        {
            if (id < 0 || nif < 0)
                return false;

            bool aux = false;

            Cliente c = Clientes.ClientePorId(id);

            if (!ReferenceEquals(c, null))
                aux = c.AlterarNif(nif);


            return aux;

        }


        public static bool AlterarTelemovelCliente(int id, int tel)
        {
            if (id < 0 || tel < 0)
                return false;

            bool aux = false;

            Cliente c = Clientes.ClientePorId(id);

            if (!ReferenceEquals(c, null))
                aux = c.AlterarTelemovel(tel);


            return aux;

        }



        public static bool AlterarNomeMarca(int id, string nome)
        {
            if (id < 0 || nome == "")
                return false;

            bool aux = false;

            Marca m = Marcas.MarcaPorId(id);

            if (!ReferenceEquals(m, null))
                aux = m.AlterarNome(nome);


            return aux;

        }

        public static bool AlterarMoradaMarca(int id, string morada)
        {
            if (id < 0 || morada == "")
                return false;

            bool aux = false;

            Marca m = Marcas.MarcaPorId(id);

            if (!ReferenceEquals(m, null))
                aux = m.AlterarMorada(morada);


            return aux;

        }


        public static bool AlterarNomeProduto(int id, string nome)
        {
            if (id < 0 || nome == "")
                return false;

            bool aux = false;

            Produto p = Stock.ProdutoPorId(id);

            if (!ReferenceEquals(p, null))
                aux = p.AlterarNome(nome);


            return aux;

        }


        public static bool AlterarValorProduto(int id, float valor)
        {
            if (id < 0 || valor <= 0.0)
                return false;

            bool aux = false;

            Produto p = Stock.ProdutoPorId(id);

            if (!ReferenceEquals(p, null))
                aux = p.AlterarValor(valor);


            return aux;
        }


        public static bool AlterarGarantiaProduto(int id, float garantia)
        {
            if (id < 0 || garantia <= 0.0)
                return false;

            bool aux = false;

            Produto p = Stock.ProdutoPorId(id);

            if (!ReferenceEquals(p, null))
                aux = p.AlterarGarantia(garantia);


            return aux;

        }

        public static bool AlterarCategoriaProduto(int id, int idCat)
        {
            if (id < 0 || idCat < 0.0)
                return false;

            bool aux = false;

            Produto p = Stock.ProdutoPorId(id);

            if (!ReferenceEquals(p, null))
                aux = p.AlterarCategoria(idCat);


            return aux;

        }


        public static bool AlterarMarcaProduto(int id, int idMarca)
        {
            if (id < 0 || idMarca < 0.0)
                return false;

            bool aux = false;

            Produto p = Stock.ProdutoPorId(id);

            if (!ReferenceEquals(p, null))
                aux = p.AlterarMarca(idMarca);


            return aux;

        }


        #endregion

        #endregion

    }
}