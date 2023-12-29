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
        /// Propriedade para Criar uma lista nova com os mesmos dados da lista de Fornecedores
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
        /// <param name="f"></param>
        /// <returns></returns>
        /// <exception cref="FornecedoresExcecoes"></exception>
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
        /// <param name="f"></param>
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

            if (ReferenceEquals(aux, null))
                return false;

            return true;
        }


        /// <summary>
        /// Metodo que retorna o fornecedor referente ao id recebido
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Fornecedor FornecedorPorId(int id)
        {
            if (ReferenceEquals(listaFornecedores, null))
                return null;

            if ((id < 0) || (listaFornecedores.Count < 1))
                return null;


            Fornecedor aux;

            aux = listaFornecedores.Find(e => e.Id == id);

            if (aux == null)
                return null;

            return aux;
        }


        /// <summary>
        /// Metodo para guardar os dados da lista fornecedores num ficheiro binario
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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
        /// <param name="file"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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


        /// <summary>
        /// Metodo para encontrar o Fornecedor a qual sera alterado o nome 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="valor"></param>
        /// <returns></returns>
        public bool AlterarNomeFornecedor(int id, string nome)
        {
            if (!VerificaFornecedorId(id))
                return false;

            Fornecedor f = FornecedorPorId(id);

            if (f == null)
                return false;

            bool aux = f.AlterarNome(nome);

            return aux;
        }


        /// <summary>
        /// Metodo para encontrar o Fornecedor a qual sera alterada a morada
        /// </summary>
        /// <param name="id"></param>
        /// <param name="morada"></param>
        /// <returns></returns>
        public bool AlterarMoradaFornecedor(int id, string morada)
        {
            if (!VerificaFornecedorId(id))
                return false;

            Fornecedor f = FornecedorPorId(id);

            if (f == null)
                return false;

            bool aux = f.AlterarMorada(morada);

            return aux;
        }


        /// <summary>
        /// Metodo para encontrar o Fornecedor ao qual sera alterado o NIF
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nif"></param>
        /// <returns></returns>
        public bool AlterarNIFFornecedor(int id, int nif)
        {
            if (!VerificaFornecedorId(id))
                return false;

            Fornecedor f = FornecedorPorId(id);

            if (f == null)
                return false;

            bool aux = f.AlterarNif(nif);

            return aux;
        }


        /// <summary>
        /// Metodo para encontrar o Fornecedor a qual sera alterado o telemovel
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tel"></param>
        /// <returns></returns>
        public bool AlterarTelemovelFornecedor(int id, int tel)
        {
            if (!VerificaFornecedorId(id))
                return false;

            Fornecedor f = FornecedorPorId(id);

            if (f == null)
                return false;

            bool aux = f.AlterarTelemovel(tel);

            return aux;
        }


        #endregion

        #endregion

    }
}