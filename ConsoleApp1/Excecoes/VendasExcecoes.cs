﻿/*
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
    public class VendasExcecoes: ApplicationException
    {
        #region Attributes
        #endregion

        #region Methods

        #region Constructors

        public VendasExcecoes() : base("Erro em Vendas")
        {

        }

        public VendasExcecoes(string s) : base(s) { }


        public VendasExcecoes(string s, Exception e)
        {
            throw new VendasExcecoes(s + "-" + e.Message);
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