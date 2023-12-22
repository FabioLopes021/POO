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
    public class Categorias
    {
        #region Attributes

        static List<Categoria> listaCategorias;

        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// Construtor estatico
        /// </summary>
        static Categorias()
        {
            listaCategorias = new List<Categoria>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
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
        /// Metodo para adicionar uma Categoria a lista de categorias
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static bool guardarCategoria(Categoria c)
        {

            if (ReferenceEquals(c, null) || ReferenceEquals(listaCategorias, null))
                return false;

            if (listaCategorias.Contains(c))
                throw new CategoriasExcecoes("Falha de Categoria (Categoria ja registada)");

            listaCategorias.Add(c);
            return true;
        }


        /// <summary>
        /// Metodo que retorma a Categoria relativa ao ID recebido 
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


        /// <summary>
        /// Metodo que verifica se existe uma categoria com o id indicado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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


        /// <summary>
        /// Metodo para guardar os dados da lista categorias num ficheiro binario
        /// </summary>
        /// <returns></returns>
        public static bool GuardarCategorias(string file)
        {
            Stream s;

            try
            {
                s = File.Open(file, FileMode.Create);
            }
            catch (Exception e)
            {
                throw new Exception("Passou na funcao (GuardarCategorias) " + "-" + e.Message);
            }

            BinaryFormatter b = new BinaryFormatter();

            b.Serialize(s, listaCategorias);
            s.Close();
            return true;
        }


        /// <summary>
        /// Metodo para carregar dados de um ficheiro binario para a lista de categorias
        /// </summary>
        /// <returns></returns>
        public static bool CarregaCategorias(string file)
        {
            Stream s;

            try
            {
                s = File.Open(file, FileMode.Open);
            }
            catch (Exception e)
            {
                throw new Exception("Passou na funcao (CarregaCategorias) " + "-" + e.Message);
            }

            BinaryFormatter b = new BinaryFormatter();

            listaCategorias = (List<Categoria>)b.Deserialize(s);
            s.Close();
            return true;
        }


        /// <summary>
        /// Metodo para encontrar a categoria a qual sera alterado o nome 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="valor"></param>
        /// <returns></returns>
        public bool AlterarNomeCategoria(int id, string nome)
        {
            if (!VerificaCategoriaPorId(id))
                return false;

            Categoria c = CategoriaPorId(id);

            if (c == null)
                return false;

            bool aux = c.AlterarNome(nome);

            return aux;
        }

        #endregion

        #endregion

    }
}