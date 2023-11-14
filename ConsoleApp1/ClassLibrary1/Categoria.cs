/*
*	<copyright file="ClassLibrary1.cs" company="IPCA">
*	Copyright (c) 2023 All Rights Reserved
*	</copyright>
* 	<author>Fábio Lopes</author>
*   <date>13/11/2023</date>
*	<description></description>
*/

using System;

namespace ClassLibrary1
{
    /// <summary>
    /// Purpose: Template de classe 
    /// Created by: Fábio Lopes
    /// Created on: 13/11/2023
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Categoria
    {
        #region Attributes
        private string cat;
        #endregion

        #region Methods

        #region Constructors
        /// <summary>
        /// The default Constructor.
        /// </summary>
        public Categoria()
        {
            cat = "";
        }

        public Categoria(string cat)
        {
            this.cat = cat;
        }
        #endregion

        #region Properties

        public string Cat
        {
            set { cat = value; }
            get { return cat; }
        }

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