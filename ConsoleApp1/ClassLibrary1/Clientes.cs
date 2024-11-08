﻿/*
*	<copyright file="ClassLibrary1.cs" company="IPCA">
*	Copyright (c) 2023 All Rights Reserved
*	</copyright>
* 	<author>Fábio Lopes</author>
*   <date>13/12/2023</date>
*	<description></description>
*/

using System;
using System.Collections.Generic;

namespace ObjetosNegocio
{
    /// <summary>
    /// Purpose: 
    /// Created by: Fábio Lopes
    /// Created on: 13/12/2023
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Clientes
    {
        #region Attributes

        static List<Cliente> listaClientes;

        #endregion

        #region Methods

        #region Constructors

        static Clientes()
        {
            listaClientes = new List<Cliente>();
        }

        #endregion

        #region Properties

        public List<Cliente> ListaClientes
        {
            get { return new List<Cliente>(listaClientes); }
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
        public static bool RegistarCliente(Cliente c)
        {
            if (c == null) 
                return false;

            if (ReferenceEquals(listaClientes, null))
                listaClientes = new List<Cliente>();

            if (listaClientes.Contains(c)) 
                return false;

            listaClientes.Add(c);
            return true;
        }


        /// <summary>
        /// Metodo para Remover um cliente da lista de Clientes( Remover Cliente)
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool RemoverCliente(Cliente c)
        {
            if (c == null) return false;

            if (ReferenceEquals(listaClientes, null) || listaClientes.Count == 0)
                return false;

            if (listaClientes.Contains(c))
            {
                listaClientes.Remove(c);
                return true;
            }


            return false;
        }





        #endregion

        #endregion

    }
}