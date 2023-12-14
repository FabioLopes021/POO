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
    public class MarcasExcecoes: ApplicationException
    {
        #region Attributes
        #endregion

        #region Methods

        #region Constructors

        public MarcasExcecoes() : base("Erro em Marcas")
        {

        }

        public MarcasExcecoes(string s) : base(s) { }


        public MarcasExcecoes(string s, Exception e)
        {
            throw new MarcasExcecoes(s + "-" + e.Message);
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