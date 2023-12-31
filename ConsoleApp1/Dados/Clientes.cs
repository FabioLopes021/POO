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
    public class Clientes
    {
        #region Attributes

        static List<Cliente> listaClientes;

        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// Construtor estatico
        /// </summary>
        static Clientes()
        {
            listaClientes = new List<Cliente>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Propriedade para Criar uma lista nova com os mesmos dados da lista de Clientes
        /// </summary>
        public static List<Cliente> ListaClientes
        {
            get { return new List<Cliente>(listaClientes); }
        }

        #endregion

        #region Operators
        #endregion

        #region Overrides
        #endregion

        #region Other_Methods


        /// <summary>
        /// Metodo para Adicionar um cliente a lista de Clientes (Registar Cliente)
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        /// <exception cref="ClientesExcecoes"></exception>
        public static bool RegistarCliente(Cliente c)
        {
            if (c == null)
                return false;

            if (ReferenceEquals(listaClientes, null))
                listaClientes = new List<Cliente>();

            if (listaClientes.Contains(c))
                throw new ClientesExcecoes("Falha de Cliente (Cliente ja registado)");

            listaClientes.Add(c);
            return true;
        }


        /// <summary>
        /// Metodo para Remover um cliente da lista de Clientes( Remover Cliente)
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool RemoverCliente(int id)
        {
            Cliente c = ClientePorId(id);

            if (ReferenceEquals(c,null)) 
                return false;

            if (ReferenceEquals(listaClientes, null) || listaClientes.Count == 0)
                return false;

            if (listaClientes.Contains(c))
            {
                listaClientes.Remove(c);
                return true;
            }


            return false;
        }


        /// <summary>
        /// Metodo que verifica se existe um Cliente com o id indicado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool VerificaClienteId(int id)
        {
            if (id < 0)
                return false;

            Cliente aux = null;

            aux = listaClientes.Find(e => e.Id == id);

            if (ReferenceEquals(aux, null))
                return false;

            return true;
        }



        /// <summary>
        /// Metodo que retorna o cliente referente ao id recebido
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Cliente ClientePorId(int id)
        {
            if (ReferenceEquals(listaClientes, null))
                return null;

            if ((id < 0) || (listaClientes.Count < 1))
                return null;


            Cliente aux;

            aux = listaClientes.Find(e => e.Id == id);

            if (ReferenceEquals(aux, null))
                return null;

            return aux;
        }


        /// <summary>
        /// Metodo para guardar os dados da lista Clientes num ficheiro binario
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool GuardarClientes(string file)
        {
            Stream s;

            try
            {
                s = File.Open(file, FileMode.Create);
            }
            catch (Exception e)
            {
                throw new Exception("Passou na funcao (GuardarClientes) " + "-" + e.Message);
            }

            BinaryFormatter b = new BinaryFormatter();

            b.Serialize(s, listaClientes);
            s.Close();
            return true;
        }


        /// <summary>
        /// Metodo para carregar dados de um ficheiro binario para a lista de Clientes
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool CarregaClientes(string file)
        {
            Stream s;

            try
            {
                s = File.Open(file, FileMode.Open);
            }
            catch (Exception e)
            {
                throw new Exception("Passou na funcao (CarregaClientes) " + "-" + e.Message);
            }

            BinaryFormatter b = new BinaryFormatter();

            listaClientes = (List<Cliente>)b.Deserialize(s);
            s.Close();
            return true;
        }


        /// <summary>
        /// Metodo para encontrar o Cliente a qual sera alterado o nome 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="valor"></param>
        /// <returns></returns>
        public static bool AlterarNomeCliente(int id, string nome)
        {
            if (!VerificaClienteId(id))
                return false;

            Cliente c = ClientePorId(id);

            if (c == null)
                return false;

            bool aux = c.AlterarNome(nome);

            return aux;
        }


        /// <summary>
        /// Metodo para encontrar o Cliente a qual sera alterada a morada
        /// </summary>
        /// <param name="id"></param>
        /// <param name="morada"></param>
        /// <returns></returns>
        public static bool AlterarMoradaCliente(int id, string morada)
        {
            if (!VerificaClienteId(id))
                return false;

            Cliente c = ClientePorId(id);

            if (c == null)
                return false;

            bool aux = c.AlterarMorada(morada);

            return aux;
        }


        /// <summary>
        /// Metodo para encontrar o Cliente a qual sera alterado o NIF
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nif"></param>
        /// <returns></returns>
        public static bool AlterarNIFCliente(int id, int nif)
        {
            if (!VerificaClienteId(id))
                return false;

            Cliente c = ClientePorId(id);

            if (c == null)
                return false;

            bool aux = c.AlterarNif(nif);

            return aux;
        }


        /// <summary>
        /// Metodo para encontrar o Cliente a qual sera alterado o telemovel
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tel"></param>
        /// <returns></returns>
        public static bool AlterarTelemovelCliente(int id, int tel)
        {
            if (!VerificaClienteId(id))
                return false;

            Cliente c = ClientePorId(id);

            if (c == null)
                return false;

            bool aux = c.AlterarTelemovel(tel);

            return aux;
        }


        /// <summary>
        /// Metodo para limpar a lista de Clientes
        /// </summary>
        public static void LimparLista()
        {
            listaClientes = new List<Cliente>();
        }

        #endregion

        #endregion

    }
}