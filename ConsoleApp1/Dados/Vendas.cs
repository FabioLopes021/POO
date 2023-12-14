/*
*	<copyright file="Dados.cs" company="IPCA">
*	Copyright (c) 2023 All Rights Reserved
*	</copyright>
* 	<author>Fábio Lopes & Ruben Costa</author>
*   <date>13/12/2023</date>
*	<description></description>
*/

using System;
using System.Collections.Generic;
using ObjetosNegocio;

namespace Dados
{
    /// <summary>
    /// Purpose: 
    /// Created by: Fábio Lopes & Ruben Costa
    /// Created on: 13/12/2023
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Vendas
    {
        #region Attributes

        static List<Venda> listaVendas;

        #endregion

        #region Methods

        #region Constructors

        static Vendas()
        {
            listaVendas = new List<Venda>();
        }

        #endregion

        #region Properties

        public static List<Venda> ListaVendas
        {
            get { return new List<Venda>(listaVendas); }
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
        public static bool AdicionarVenda(Venda v)
        {

            if (ReferenceEquals(v, null) || ReferenceEquals(listaVendas, null))
                return false;

            if (listaVendas.Contains(v))
                return false;

            listaVendas.Add(v);
            return true;
        }



        /// <summary>
        /// Funçao que retorma a marca relativa ao ID recebido
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Venda MarcaPorId(int id)
        {
            if (ReferenceEquals(listaVendas, null))
                return null;

            if ((id < 0) || (listaVendas.Count < 1))
                return null;


            Venda aux;

            aux = listaVendas.Find(e => e.Id == id);

            if (aux == null)
                return null;

            return aux;
        }


        public bool VerificaIntegridadeVenda()
        {
            Stock aux = null;


            //verificar nome de armazem e id CLiente
            //if ()
              //  return false;

            //Verificar a disponivilidade no stock do armazem indicado
            if (!Marcas.VerificaMarcaPorId(idMarca) || !Categorias.VerificaCategoriaPorId(idMarca))
                return false;

            return true;
        }


        #endregion

        #endregion

    }
}