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
        /// Propriedade para Criar um clone da lista de Clientes.
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
        public static bool RemoverCliente(Cliente c)
        {
            if (c == null) return false;

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
            if(id < 0)
                return false;

            Cliente aux = null;

            aux = listaClientes.Find(e => e.Id == id);

            if(aux == null)
                return false;

            return true;
        }



        /// <summary>
        /// Funçao para guardar os dados da lista Clientes num ficheiro binario
        /// </summary>
        /// <returns></returns>
        public static bool GuardarClientes()
        {
            Stream s = File.Open("Clientes", FileMode.Create);

            BinaryFormatter b = new BinaryFormatter();

            b.Serialize(s, listaClientes);
            s.Close();
            return true;
        }


        /// <summary>
        /// Funçao para carregar dados de um ficheiro binario para a lista de Clientes
        /// </summary>
        /// <returns></returns>
        public static bool CarregaClientes()
        {
            Stream s = File.Open("Clientes", FileMode.Open);


            BinaryFormatter b = new BinaryFormatter();

            listaClientes = (List<Cliente>)b.Deserialize(s);
            s.Close();
            return true;
        }



        #endregion

        #endregion

    }
}