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
    public class Produto
    {
        #region Attributes
        private string nome;
        private float valor;
        private float garantiaAnos;
        Categoria catg;
        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public Produto()
        {
            nome = "";
            valor = 0;
            garantiaAnos = 0;
            catg = new Categoria();
        }

        public Produto(string nome, float valor, Categoria catg, float garantia)
        {
            this.nome = nome;
            this.valor = valor;
            this.catg= catg;
            this.garantiaAnos = garantia;
        }

        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public string Nome
        {
            set { nome = value; }
            get { return nome; }
        }

        public float Valor
        {
            set { valor = value; }
            get { return valor; }
        }

        public Categoria Catg
        {
            set { catg = value; }
            get { return catg; }
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