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



        public static bool AdicionarMarca(Marca m)
        {
            if (m == null)
                throw new StockExcecoes("Falha de Regras de Negocio (null data em Marca)");

            bool aux = false;
            try
            {
                aux = Marcas.GuardarMarca(m);
            }
            catch (StockExcecoes e)
            {
                throw new StockExcecoes("Passou nas Regras de Negocio " + "-" + e.Message);
            }

            return aux;
        }



        public static bool AdicionarCategoria(Categoria c)
        {
            if (c == null)
                throw new StockExcecoes("Falha de Regras de Negocio (null data em Categoria)");

            bool aux = false;
            try
            {
                aux = Categorias.guardarCategoria(c);
            }
            catch (StockExcecoes e)
            {
                throw new StockExcecoes("Passou nas Regras de Negocio " + "-" + e.Message);
            }

            return aux;
        }



        public static bool AdicionarFornecedor(Fornecedor f)
        {
            if (f == null)
                throw new StockExcecoes("Falha de Regras de Negocio (null data em Fornecedor)");

            bool aux = false;
            try
            {
                aux = Fornecedores.RegistarFornecedor(f);
            }
            catch (StockExcecoes e)
            {
                throw new StockExcecoes("Passou nas Regras de Negocio " + "-" + e.Message);
            }

            return aux;
        }


        public static bool AdicionarProduto(Produto p)
        {
            if (p == null)
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


        public static bool AdicionarCliente(Cliente c)
        {
            if (c == null)
                throw new StockExcecoes("Falha de Regras de Negocio (null data em Cliente)");

            bool aux = false;
            try
            {
                aux = Clientes.RegistarCliente(c);
            }
            catch (StockExcecoes e)
            {
                throw new StockExcecoes("Passou nas Regras de Negocio " + "-" + e.Message);
            }
 
            return aux;
        }

        
        public static bool AdicionarCompra(Compra c)
        {
            if (c == null)
                throw new StockExcecoes("Falha de Regras de Negocio (null data em Compra)");

            
            bool aux = false;
            try
            {
                aux = Compras.RegistarCompra(c);
            }
            catch (StockExcecoes e)
            {
                throw new StockExcecoes("Passou nas Regras de Negocio " + "-" + e.Message);
            }

            return aux;
        }


        public static bool AdicionarVenda(Venda v)
        {
            if (v == null)
                throw new StockExcecoes("Falha de Regras de Negocio (null data em Compra)");


            bool aux = false;
            try
            {
                aux = Vendas.RegistarVenda(v);
            }
            catch (StockExcecoes e)
            {
                throw new StockExcecoes("Passou nas Regras de Negocio " + "-" + e.Message);
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