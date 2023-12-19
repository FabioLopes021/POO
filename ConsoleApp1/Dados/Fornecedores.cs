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
    public class Fornecedores
    {
        #region Attributes

        static List<Fornecedor> listaFornecedores;

        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// Construtor estatico
        /// </summary>
        static Fornecedores()
        {
            listaFornecedores = new List<Fornecedor>();
        }


        #endregion

        #region Properties


        /// <summary>
        /// Propriedade para Criar um clone da lista de Fornecedores.
        /// </summary>
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
        /// Metodo para Adicionar um Fornecedor a lista de Fornecedores (Registar Fornecedor)
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
                throw new FornecedoresExcecoes("Falha de Fornecedor (Fornecedor ja registado)");

            listaFornecedores.Add(f);
            return true;
        }


        /// <summary>
        /// Metodo para Remover um Fornecedor da lista de Fornecedores (Remover Fornecedor)
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


        /// <summary>
        /// Metodo que verifica se existe um fornecedor com o id indicado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool VerificaFornecedorId(int id)
        {
            if (id < 0)
                return false;

            Fornecedor aux = null;

            aux = listaFornecedores.Find(e => e.Id == id);

            if (aux == null)
                return false;

            return true;
        }


        /// <summary>
        /// Metodo para guardar os dados da lista fornecedores num ficheiro binario
        /// </summary>
        /// <returns></returns>
        public static bool GuardarFornecedores(string file)
        {
            Stream s;

            try
            {
                s = File.Open(file, FileMode.Create);
            }
            catch (Exception e)
            {
                throw new Exception("Passou na funcao (GuardaFornecedores) " + "-" + e.Message);
            }

            BinaryFormatter b = new BinaryFormatter();

            b.Serialize(s, listaFornecedores);
            s.Close();
            return true;
        }

        /// <summary>
        /// Metodo para carregar dados de um ficheiro binario para a lista de fornecedores
        /// </summary>
        /// <returns></returns>
        public static bool CarregaFornecedores(string file)
        {
            Stream s;

            try
            {
                s = File.Open(file, FileMode.Open);
            }
            catch (Exception e)
            {
                throw new Exception("Passou na funcao (CarregaFornecedores) " + "-" + e.Message);
            }

            BinaryFormatter b = new BinaryFormatter();

            listaFornecedores = (List<Fornecedor>)b.Deserialize(s);
            s.Close();
            return true;
        }

        #endregion

        #endregion

    }
}