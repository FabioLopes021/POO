/*
*	<copyright file="Dados.cs" company="IPCA">
*	Copyright (c) 2023 All Rights Reserved
*	</copyright>
* 	<author>Fábio Lopes & Ruben Costa</author>
*   <date>13/12/2023</date>
*	<description></description>
*/

using Excecoes;
using ObjetosNegocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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

        /// <summary>
        /// Construtor Estatico
        /// </summary>
        static Compras()
        {
            listaCompras = new List<Compra>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Propriedade para Criar uma lista nova com os mesmos dados da lista de Compras
        /// </summary>
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
        /// Metodo que retorma a Compra relativa ao ID recebido
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Compra CompraPorId(int id)
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


        /// <summary>
        /// Metodo que regista uma Compra e a adiciona a lista de Compras
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        /// <exception cref="ComprasExcecoes"></exception>
        public static bool RegistarCompra(Compra c)
        {
            if (ReferenceEquals(c, null) || listaCompras.Contains(c))
                return false;

            if (!c.VerificaIntegridadeCompra())
                throw new ComprasExcecoes("Falha de Compra (Dados invalidos na compra)");

            if (Stock.AtualizarStockCompra(c.ArtigosComprados))
            {
                listaCompras.Add(c);
                return true;
            }

            return false;
        }


        /// <summary>
        /// Metodo para guardar os dados da lista compras num ficheiro binario
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool GuardarCompras(string file)
        {
            Stream s;

            try
            {
                s = File.Open(file, FileMode.Create);
            }
            catch (Exception e)
            {
                throw new Exception("Passou na funcao (GuardarCompras) " + "-" + e.Message);
            }

            BinaryFormatter b = new BinaryFormatter();

            b.Serialize(s, listaCompras);
            s.Close();
            return true;
        }


        /// <summary>
        /// Metodo para carregar os dados da lista compras de um ficheiro binario
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool CarregaCompras(string file)
        {
            Stream s;

            try
            {
               s = File.Open(file, FileMode.Open);
            }
            catch (Exception e)
            {
                throw new Exception("Passou na funcao (CarregaCompras) " + "-" + e.Message);
            }

            BinaryFormatter b = new BinaryFormatter();


            listaCompras = (List<Compra>)b.Deserialize(s);
            s.Close();
            return true;
        }



        #endregion

        #endregion

    }
}