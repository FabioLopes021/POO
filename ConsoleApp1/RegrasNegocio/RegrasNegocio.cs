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


        public static bool GuardarStock()
        {
            bool aux = false;

            aux = Stock.GuardarStock();

            return aux;
        }

        public static bool CarregarStock()
        {
            bool aux = false;

            aux = Stock.CarregaStock();

            return aux;
        }



        public static bool GuardarVendas()
        {
            bool aux = false;

            aux = Vendas.GuardarVendas();

            return aux;
        }

        public static bool CarregarVendas()
        {
            bool aux = false;

            aux = Vendas.CarregaVendas();

            return aux;
        }



        public static bool GuardarMarcas()
        {
            bool aux = false;

            aux = Marcas.GuardarMarcas();

            return aux;
        }

        public static bool CarregarMarcas()
        {
            bool aux = false;

            aux = Marcas.CarregaMarcas();

            return aux;
        }



        public static bool GuardarFornecedores()
        {
            bool aux = false;

            aux = Fornecedores.GuardarFornecedores();

            return aux;
        }

        public static bool CarregarFornecedores()
        {
            bool aux = false;

            aux = Fornecedores.CarregaFornecedores();

            return aux;
        }


        public static bool GuardarCompras()
        {
            bool aux = false;

            aux = Compras.GuardarCompras();

            return aux;
        }

        public static bool CarregarCompras()
        {
            bool aux = false;

            aux = Compras.CarregaCompras();

            return aux;
        }


        public static bool GuardarClientes()
        {
            bool aux = false;

            aux = Clientes.GuardarClientes();

            return aux;
        }

        public static bool CarregarClientes()
        {
            bool aux = false;

            aux = Clientes.CarregaClientes();

            return aux;
        }


        public static bool GuardarCategorias()
        {
            bool aux = false;

            aux = Categorias.GuardarCategorias();

            return aux;
        }


        public static bool CarregarCategorias()
        {
            bool aux = false;

            aux = Categorias.CarregaCategorias();

            return aux;
        }

        #endregion

        #endregion

    }
}