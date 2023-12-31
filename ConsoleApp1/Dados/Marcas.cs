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
    public class Marcas
    {
        #region Attributes

        static List<Marca> listaMarcas;

        #endregion

        #region Methods

        #region Constructors


        /// <summary>
        /// Construtor estatico
        /// </summary>
        static Marcas()
        {
            listaMarcas = new List<Marca>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Propriedade para Criar uma lista nova com os mesmos dados da lista de marcas
        /// </summary>
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
        /// Metodo para adicionar uma marca a lista de marcas
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
        /// Metodo que retorma a marca relativa ao ID recebido
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Marca MarcaPorId(int id)
        {
            if (ReferenceEquals(listaMarcas, null))
                return null;

            if ((id < 0) || (listaMarcas.Count < 1))
                return null;


            Marca aux;

            aux = listaMarcas.Find(e => e.Id == id);

            if (ReferenceEquals(aux, null))
                return null;

            return aux;
        }



        /// <summary>
        /// Metodo que verifica se existe uma marca com o id indicado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool VerificaMarcaPorId(int id)
        {
            if (id <= 0)
                return false;

            Marca aux = null;

            aux = listaMarcas.Find(e => e.Id == id);

            if (ReferenceEquals(aux, null))
                return false;
            return true;

        }



        /// <summary>
        /// Metodo para guardar os dados da lista marcas num ficheiro binario
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool GuardarMarcas(string file)
        {
            Stream s;

            try
            {
                s = File.Open(file, FileMode.Create);
            }
            catch (Exception e)
            {
                throw new Exception("Passou na funcao (GuardaMarcas) " + "-" + e.Message);
            }

            BinaryFormatter b = new BinaryFormatter();

            b.Serialize(s, listaMarcas);
            s.Close();
            return true;
        }

        /// <summary>
        /// Metodo para carregar dados de um ficheiro binario para a lista de marcas
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool CarregaMarcas(string file)
        {
            Stream s;

            try
            {
                s = File.Open(file, FileMode.Open);
            }
            catch (Exception e)
            {
                throw new Exception("Passou na funcao (CarregaMarcas) " + "-" + e.Message);
            }


            BinaryFormatter b = new BinaryFormatter();

            listaMarcas = (List<Marca>)b.Deserialize(s);
            s.Close();
            return true;
        }

        
        /// <summary>
        /// Metodo para encontrar a marca a qual sera alterado o nome
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nome"></param>
        /// <returns></returns>
        public static bool AlterarNomeMarca(int id, string nome)
        {
            if (!VerificaMarcaPorId(id))
                return false;

            Marca m = MarcaPorId(id);

            if (m == null)
                return false;

            bool aux = m.AlterarNome(nome);

            return aux;
        }


        /// <summary>
        /// Metodo para encontrar a marca a qual sera alterada a morada
        /// </summary>
        /// <param name="id"></param>
        /// <param name="morada"></param>
        /// <returns></returns>
        public static bool AlterarMoradaMarca(int id, string morada)
        {
            if (!VerificaMarcaPorId(id))
                return false;

            Marca m = MarcaPorId(id);

            if (m == null)
                return false;

            bool aux = m.AlterarMorada(morada);

            return aux;
        }


        /// <summary>
        /// Metodo para limpar a lista de Marcas
        /// </summary>
        public static void LimparLista()
        {
            listaMarcas = new List<Marca>();
        }

        #endregion

        #endregion

    }
}