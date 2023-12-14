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


        public static bool AdicionarProduto(Produto p, Stock s)
        {
            if (p == null)
                throw new StockExcecoes("Falha de Regras de Negocio (null data)");

            if (s == null)
                throw new StockExcecoes("Falha de Regras de Negocio (null data em stock)");

            try
            {
                s.AdicionarProduto(p);
            }
            catch (StockExcecoes e)
            {
                throw new StockExcecoes("Passou nas Regras de Negocio " + "-" + e.Message);
            }

            return true;
        }

        public static bool RemoverProduto(Produto p, Stock s)
        {
            if (p == null)
                throw new StockExcecoes("Falha de Regras de Negocio (null data em Produto)");

            if (s == null)
                throw new StockExcecoes("Falha de Regras de Negocio (null data em stock)");
            
            try
            {
                s.RemoverProduto(p);
            }
            catch (StockExcecoes e)
            {
                throw new StockExcecoes("Passou nas Regras de Negocio " + "-" + e.Message);
            }

            return true;
        }



        public static bool AumentarQuantidadeArmazem(Produto p, Stock s, float quantidade)
        {
            if (p == null)
                throw new StockExcecoes("Falha de Regras de Negocio (null data em Produto)");
            if (s == null)
                throw new StockExcecoes("Falha de Regras de Negocio (null data em stock)");

            try
            {
                s.AumentarQuantidade(p, quantidade);
            }
            catch (StockExcecoes e)
            {
                throw new StockExcecoes("Passou nas Regras de Negocio " + "-" + e.Message);
            }

            return true;
        }


        public static bool RetirarQuantidadeArmazem(Produto p, Stock s, float quantidade)
        {
            if (p == null)
                throw new StockExcecoes("Falha de Regras de Negocio (null data em Produto)");
            if (s == null)
                throw new StockExcecoes("Falha de Regras de Negocio (null data em stock)");

            try
            {
                s.RetirarQuantidade(p, quantidade);
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