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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ObjetosNegocio;
using Excecoes;

namespace Dados
{
    /// <summary>
    /// Purpose: 
    /// Created by: Fábio Lopes & Ruben Costa
    /// Created on: 13/12/2023
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Marcas
    {
        #region Attributes

        static List<Marca> listaMarcas;

        #endregion

        #region Methods

        #region Constructors

        static Marcas()
        {
            listaMarcas = new List<Marca>();
        }

        #endregion

        #region Properties


        public static List<Marca> ListaMarcas
        {
            get { return new List<Marca>(listaMarcas); }
        }

        #endregion

        #region Operators
        #endregion

        #region Overrides
        #endregion

        #region Other_Methods


        /// <summary>
        /// Funçao para adicionar uma marca a lista de marcas
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static bool GuardarMarca(Marca m)
        {

            if (ReferenceEquals(m, null) || ReferenceEquals(listaMarcas, null))
                return false;

            if (listaMarcas.Contains(m))
                throw new MarcasExcecoes("Falha de Marca (Marca ja resgistada)");

            listaMarcas.Add(m);
            return true;
        }



        /// <summary>
        /// Funçao que retorma a marca relativa ao ID recebido
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Marca MarcaPorId(int id)
        {
            if (ReferenceEquals(listaMarcas, null))
                return null;

            if ((id < 0) || (listaMarcas.Count < 1))
                return null;


            Marca aux;

            aux = listaMarcas.Find(e => e.Id == id);

            if (aux == null)
                return null;

            return aux;
        }


        public static bool VerificaMarcaPorId(int id)
        {
            if(id <= 0)
                return false;

            Marca aux = null;

            aux = listaMarcas.Find(e => e.Id == id);

            if(aux == null)
                return false;
            return true;

        }


        public static bool GuardarMarcas()
        {
            Stream s = File.Open("Marcas", FileMode.Create);

            BinaryFormatter b = new BinaryFormatter();

            b.Serialize(s, listaMarcas);
            s.Close();
            return true;
        }


        public static bool CarregaMarcas()
        {
            Stream s = File.Open("Marcas", FileMode.Open);


            BinaryFormatter b = new BinaryFormatter();

            listaMarcas = (List<Marca>)b.Deserialize(s);
            s.Close();
            return true;
        }


        #endregion

        #endregion

    }
}