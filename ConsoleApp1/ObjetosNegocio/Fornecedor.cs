/*
*	<copyright file="ObjetosNegocio.cs" company="IPCA">
*	Copyright (c) 2023 All Rights Reserved
*	</copyright>
* 	<author>Fábio Lopes & Ruben Costa</author>
*   <date>13/12/2023</date>
*	<description></description>
*/
using Dados;
using System;
using System.Collections.Generic;

namespace ObjetosNegocio
{
    /// <summary>
    /// Purpose: 
    /// Created by: Fábio Lopes & Ruben Costa
    /// Created on: 13/12/2023
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Fornecedor
    {
        #region Attributes

        string nome;
        string morada;
        int nif;
        int telemovel;
        int id;

        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public Fornecedor()
        {
            nome = "";
            morada = "";
            nif = 0;
            telemovel = 0;
            id = AtribuirId();
        }

        public Fornecedor(string nome, string morada, int nif, int telemovel)
        {
            this.nome = nome;
            this.morada = morada;
            this.nif = nif;
            this.telemovel = telemovel;
            id = AtribuirId();
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

        public int Id
        {
            get { return id; }
        }


        #endregion

        #region Operators
        #endregion

        #region Overrides
        #endregion

        #region Other_Methods

        
        public static int AtribuirId()
        {
            int maxid = 1;

            List<Fornecedor> lista = Fornecedores.ListaFornecedores;

            if (ReferenceEquals(lista, null) || lista.Count == 0)
                return maxid;

            foreach (Fornecedor aux in lista)
            {
                if (aux.id > maxid)
                    maxid = aux.id;
            }

            return ++maxid;
        }
        

        #endregion

        #endregion

    }
}