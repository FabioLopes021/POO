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
    public class Categorias
    {
        #region Attributes

        static List<Categoria> listaCategorias;

        #endregion

        #region Methods

        #region Constructors

        static Categorias()
        {
            listaCategorias = new List<Categoria>();
        }

        #endregion

        #region Properties

        public static List<Categoria> ListaCategorias
        {
            get { return new List<Categoria>(listaCategorias); }
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
        public static bool guardarCategoria(Categoria c)
        {

            if (ReferenceEquals(c, null) || ReferenceEquals(listaCategorias, null))
                return false;

            if (listaCategorias.Contains(c))
                return false;

            listaCategorias.Add(c);
            return true;
        }


        /// <summary>
        /// Funçao que retorma a Categoria relativa ao ID recebido 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Categoria CategoriaPorId(int id)
        {
            if (ReferenceEquals(listaCategorias, null))
                return null;

            if ((id < 0) || (listaCategorias.Count < 1))
                return null;


            Categoria aux;

            aux = listaCategorias.Find(e => e.Id == id);

            if (aux == null)
                return null;

            return aux;
        }


        public static bool VerificaCategoriaPorId(int id)
        {
            if (id <= 0)
                return false;

            Categoria aux = null;

            aux = listaCategorias.Find(e => e.Id == id);

            if (aux == null)
                return false;
            return true;

        }



        public static bool GuardarCategorias()
        {
            Stream s = File.Open("Categorias", FileMode.Create);

            BinaryFormatter b = new BinaryFormatter();

            b.Serialize(s, listaCategorias);
            s.Close();
            return true;
        }


        public static bool CarregaCategorias()
        {
            Stream s = File.Open("Categorias", FileMode.Open);


            BinaryFormatter b = new BinaryFormatter();

            listaCategorias = (List<Categoria>)b.Deserialize(s);
            s.Close();
            return true;
        }

        #endregion

        #endregion

    }
}