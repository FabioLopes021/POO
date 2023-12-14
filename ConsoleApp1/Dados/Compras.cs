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
    public class Compras
    {
        #region Attributes

        static List<Compra> listaCompras;

        #endregion

        #region Methods

        #region Constructors

        static Compras()
        {
            listaCompras = new List<Compra>();
        }

        #endregion

        #region Properties

        public static List<Compra> ListaCompras
        {
            get { return new List<Compra>(listaCompras); }
        }

        #endregion

        #region Operators
        #endregion

        #region Overrides
        #endregion

        #region Other_Methods


        /// <summary>
        /// Funçao para adicionar uma Venda a lista de Vendas
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static bool AdicionarCompra(Compra c)
        {

            if (ReferenceEquals(c, null) || ReferenceEquals(listaCompras, null))
                return false;

            if (listaCompras.Contains(c))
                return false;

            listaCompras.Add(c);
            return true;
        }



        /// <summary>
        /// Funçao que retorma a marca relativa ao ID recebido
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Compra MarcaPorId(int id)
        {
            if (ReferenceEquals(listaCompras, null))
                return null;

            if ((id < 0) || (listaCompras.Count < 1))
                return null;


            Compra aux;

            aux = listaCompras.Find(e => e.Id == id);

            if (aux == null)
                return null;

            return aux;
        }


        public static bool RegistarCompra(Compra c)
        {
            if (ReferenceEquals(c, null))
                return false;

            if (!c.VerificaIntegridadeCompra())
                return false;

            if (Stock.AtualizarStockCompra(c.ArtigosComprados))
            {
                listaCompras.Add(c);
                return true;
            }

            return false;
        }


        #endregion

        #endregion

    }
}