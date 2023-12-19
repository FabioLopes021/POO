/*
*	<copyright file="Excecoes.cs" company="IPCA">
*	Copyright (c) 2023 All Rights Reserved
*	</copyright>
* 	<author>Fábio Lopes & Ruben Costa</author>
*   <date>13/12/2023</date>
*	<description></description>
*/

using System;

namespace Excecoes
{
    /// <summary>
    /// Purpose: 
    /// Created by: Fábio Lopes & Ruben Costa
    /// Created on: 13/12/2023
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class ComprasExcecoes: ApplicationException
    {
        #region Attributes
        #endregion

        #region Methods

        #region Constructors


        /// <summary>
        /// Construtor default
        /// </summary>
        public ComprasExcecoes() : base("Erro em Compras")
        {

        }


        /// <summary>
        /// Construtor com dados
        /// </summary>
        /// <param name="s"></param>
        public ComprasExcecoes(string s) : base(s) { }


        /// <summary>
        /// Construtor com dados
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        /// <exception cref="ComprasExcecoes"></exception>
        public ComprasExcecoes(string s, Exception e)
        {
            throw new ComprasExcecoes(s + "-" + e.Message);
        }


        #endregion

        #region Properties
        #endregion

        #region Operators
        #endregion

        #region Overrides
        #endregion

        #region Other_Methods
        #endregion

        #endregion

    }
}