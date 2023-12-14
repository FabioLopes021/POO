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

namespace RegrasNegocio
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





        #endregion

        #endregion

    }
}