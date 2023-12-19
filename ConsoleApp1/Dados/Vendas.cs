﻿/*
*	<copyright file="Dados.cs" company="IPCA">
*	Copyright (c) 2023 All Rights Reserved
*	</copyright>
* 	<author>Fábio Lopes & Ruben Costa</author>
*   <date>13/12/2023</date>
*	<description></description>
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Excecoes;
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


        /// <summary>
        /// Constutor estatico
        /// </summary>
        static Vendas()
        {
            listaVendas = new List<Venda>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Propriedade para Criar um clone da lista de vendas.
        /// </summary>
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

        /*
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
        */


        /// <summary>
        /// Funçao que retorma a marca relativa ao ID recebido
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Venda VendaPorId(int id)
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


        /// <summary>
        /// Funçao que regista uma venda e a adiciona a listaVendas
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        /// <exception cref="VendasExcecoes"></exception>
        public static bool RegistarVenda(Venda v)
        {
            if(ReferenceEquals(v,null) || listaVendas.Contains(v))
                return false;

            if(!v.VerificaIntegridadeVenda())
                throw new VendasExcecoes("Falha de Vendas (Dados invalidos na Venda)"); ;

            if (Stock.AtualizarStockVenda(v.ArtigosVendidos))
            {
                listaVendas.Add(v);
                return true;
            }

            return false;
        }



        /// <summary>
        /// Funçao para guardar os dados da lista vendas num ficheiro binario
        /// </summary>
        /// <returns></returns>
        public static bool GuardarVendas()
        {
            Stream s = File.Open("Vendas", FileMode.Create);

            BinaryFormatter b = new BinaryFormatter();

            b.Serialize(s, listaVendas);
            s.Close();
            return true;
        }


        /// <summary>
        /// Funçao para carregar dados de um ficheiro binario para a lista de vendas
        /// </summary>
        /// <returns></returns>
        public static bool CarregaVendas()
        {
            Stream s = File.Open("Vendas", FileMode.Open);


            BinaryFormatter b = new BinaryFormatter();

            listaVendas = (List<Venda>)b.Deserialize(s);
            s.Close();
            return true;
        }



        #endregion

        #endregion

    }
}