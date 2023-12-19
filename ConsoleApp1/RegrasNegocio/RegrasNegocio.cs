/*
*	<copyright file="RegrasNegocio.cs" company="IPCA">
*	Copyright (c) 2023 All Rights Reserved
*	</copyright>
* 	<author>Fábio Lopes & Ruben Costa</author>
*   <date>13/12/2023</date>
*	<description></description>
*/

using System;
using Dados;
using ObjetosNegocio;
using Excecoes;
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
        /*
        public static bool RemoverProduto(Produto p)
        {
            if (p == null)
                throw new StockExcecoes("Falha de Regras de Negocio (null data em Produto)");
            
            try
            {
                Stock.RemoverProduto(p);
            }
            catch (StockExcecoes e)
            {
                throw new StockExcecoes("Passou nas Regras de Negocio " + "-" + e.Message);
            }

            return true;
        }
        


        public static bool AumentarQuantidadeArmazem(Produto p, float quantidade)
        {
            if (p == null)
                throw new StockExcecoes("Falha de Regras de Negocio (null data em Produto)");

            try
            {
                Stock.AumentarQuantidade(p, quantidade);
            }
            catch (StockExcecoes e)
            {
                throw new StockExcecoes("Passou nas Regras de Negocio " + "-" + e.Message);
            }

            return true;
        }


        public static bool RetirarQuantidadeArmazem(Produto p, float quantidade)
        {
            if (p == null)
                throw new StockExcecoes("Falha de Regras de Negocio (null data em Produto)");

            try
            {
                Stock.RetirarQuantidade(p, quantidade);
            }
            catch (StockExcecoes e)
            {
                throw new StockExcecoes("Passou nas Regras de Negocio " + "-" + e.Message);
            }

            return true;
        }
        */


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

        public static List<Categoria> ListaCategorias()
        {
            return Categorias.ListaCategorias;
        }

        public static List<Marca> ListaMarcas()
        {
            return Marcas.ListaMarcas;
        }

        public static List<Fornecedor> ListaFornecedores()
        {
            return Fornecedores.ListaFornecedores;
        }

        public static List<Cliente> ListaClientes()
        {
            return Clientes.ListaClientes;
        }

        public static List<Produto> ListaProdutos()
        {
            return Stock.ListaProdutos;
        }

        #endregion

        #endregion

    }
}