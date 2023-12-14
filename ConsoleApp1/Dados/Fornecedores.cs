/*
*	<copyright file="Dados.cs" company="IPCA">
*	Copyright (c) 2023 All Rights Reserved
*	</copyright>
* 	<author>Fábio Lopes & Ruben Costa</author>
*   <date>13/12/2023</date>
*	<description></description>
*/

using ObjetosNegocio;
using System;
using System.Collections.Generic;

namespace Dados
{
    /// <summary>
    /// Purpose: 
    /// Created by: Fábio Lopes & Ruben Costa
    /// Created on: 13/12/2023
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Fornecedores
    {
        #region Attributes

        static List<Fornecedor> listaFornecedores;

        #endregion

        #region Methods

        #region Constructors

        static Fornecedores()
        {
            listaFornecedores = new List<Fornecedor>();
        }


        #endregion

        #region Properties

        public static List<Fornecedor> ListaFornecedores
        {
            get { return new List<Fornecedor>(listaFornecedores); }
        }

        #endregion

        #region Operators
        #endregion

        #region Overrides
        #endregion

        #region Other_Methods

        /// <summary>
        /// Metodo para Adicionar um cliente a lista de Clientes (Registar Cliente)
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool RegistarFornecedor(Fornecedor f)
        {
            if (f == null)
                return false;

            if (ReferenceEquals(listaFornecedores, null))
                listaFornecedores = new List<Fornecedor>();

            if (listaFornecedores.Contains(f))
                return false;

            listaFornecedores.Add(f);
            return true;
        }


        /// <summary>
        /// Metodo para Remover um cliente da lista de Clientes( Remover Cliente)
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool RemoverFornecedor(Fornecedor f)
        {
            if (f == null) return false;

            if (ReferenceEquals(listaFornecedores, null) || listaFornecedores.Count == 0)
                return false;

            if (listaFornecedores.Contains(f))
            {
                listaFornecedores.Remove(f);
                return true;
            }


            return false;
        }

        #endregion

        #endregion

    }
}