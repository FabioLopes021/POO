/*
*	<copyright file="ClassLibrary1.cs" company="IPCA">
*	Copyright (c) 2023 All Rights Reserved
*	</copyright>
* 	<author>Fábio Lopes</author>
*   <date>13/11/2023</date>
*	<description></description>
*/

using System;
using static System.Net.Mime.MediaTypeNames;

namespace ClassLibrary1
{
    /// <summary>
    /// Purpose: Template de classe 
    /// Created by: Fábio Lopes
    /// Created on: 13/11/2023
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Cliente
    {
        #region Attributes
        private string nome, morada;
        private int nif, telemovel;

        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public Cliente()
        {
            nome = "";
            morada = "";
            nif = 0;
            telemovel = 0;
        }

        public Cliente(string nome, string morada, int nif, int telemovel)
        {
            this.nome = nome;
            this.morada = morada;
            this.nif = nif;
            this.telemovel = telemovel;
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

        public string Morada
        {
            set { morada = value; }
            get { return morada; }
        }

        public int Telemovel
        {
            set { telemovel = value; }
            get { return telemovel; }
        }

        public int NIF
        {
            set { nif = value; }
            get { return nif; }
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