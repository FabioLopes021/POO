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

        //Nao implementar, os produtos sao adicionados automaticamente ao registar uma compra
        /*
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
        */

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











        #endregion

        #endregion

    }
}