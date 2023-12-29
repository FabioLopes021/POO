/*
*	<copyright file="ClassLibrary1.cs" company="IPCA">
*	Copyright (c) 2023 All Rights Reserved
*	</copyright>
* 	<author>Fábio Lopes & Ruben Costa</author>
*   <date>13/11/2023</date>
*	<description></description>
*/

using Dados;
using System;
using System.Collections.Generic;

namespace ObjetosNegocio
{
    [Serializable]
    /// <summary>
    /// Purpose: Garantia de classe 
    /// Created by: Fábio Lopes & Ruben Costa
    /// Created on: 13/11/2023
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Cliente: ICliente
    {

        #region Attributes

        string nome;
        string morada;
        int nif;
        int telemovel;
        int id;

        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// Construtor default
        /// </summary>
        public Cliente()
        {
            nome = "";
            morada = "";
            nif = 0;
            telemovel = 0;
            id = AtribuirId();
        }


        /// <summary>
        /// Constutor com dados
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="morada"></param>
        /// <param name="nif"></param>
        /// <param name="telemovel"></param>
        public Cliente(string nome, string morada, int nif, int telemovel)
        {
            this.nome = nome;
            this.morada = morada;
            this.nif = nif;
            this.telemovel = telemovel;
            id = AtribuirId();
        }


        #endregion

        #region Properties


        /// <summary>
        /// Propriedade para aceder a variavel nome
        /// </summary>
        public string Nome
        {
            set { nome = value; }
            get { return nome; }
        }


        /// <summary>
        /// Propriedade para aceder a variavel morada
        /// </summary>
        public string Morada
        {
            set { morada = value; }
            get { return morada; }
        }


        /// <summary>
        /// Propriedade para aceder a variavel telemovel
        /// </summary>
        public int Telemovel
        {
            set { telemovel = value; }
            get { return telemovel; }
        }

        /// <summary>
        /// Propriedade para aceder a variavel nif
        /// </summary>
        public int NIF
        {
            set { nif = value; }
            get { return nif; }
        }


        /// <summary>
        /// Propriedade para aceder a variavel id
        /// </summary>
        public int Id
        {
            get { return id; }
        }

        #endregion

        #region Operators

        /// <summary>
        /// Operador que verifica se dois objetos desta classe sao iguais
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
        public static bool operator ==(Cliente c1, Cliente c2)
        {

            if (ReferenceEquals(c1, null) || ReferenceEquals(c2, null))
                return false;

            if (c1.Id == c2.Id)
                return true;

            return false;
        }


        /// <summary>
        /// Operador que verifica se dois objetos desta classe sao diferentes
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
        public static bool operator !=(Cliente c1, Cliente c2)
        {
            if (c1 == c2)
                return false;

            return true;
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Metodo que verifica se dois objetos desta classe sao iguais
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Cliente)
            {
                Cliente a = obj as Cliente;

                if ((a.Id == this.Id))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Implementaçao do Metodo ToString() para esta classe
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {

            return string.Format("Id: {0}, Nome: {1}, Morada: {2}, NIF: {3}, Telemovel: {4}", this.Id, this.Nome, this.Morada, this.NIF, this.Telemovel);
        }



        #endregion

        #region Other_Methods


        /// <summary>
        /// Metodo para calcular id a ser atribuido a cada Cliente a ser criado
        /// </summary>
        /// <returns></returns>
        public static int AtribuirId()
        {
            int maxid = 1;

            List<Cliente> lista = Clientes.ListaClientes;

            if (ReferenceEquals(lista, null) || lista.Count == 0)
                return maxid;

            foreach (Cliente aux in lista)
            {
                if (aux.id > maxid)
                    maxid = aux.id;
            }

            return ++maxid;
        }


        /// <summary>
        /// Metodo para alterar o nome de um Cliente
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public bool AlterarNome(string nome)
        {
            if (ReferenceEquals(this, null) || nome == "")
                return false;

            this.Nome = nome;

            return true;
        }


        /// <summary>
        /// Metodo para alterar a morada de um Cliente
        /// </summary>
        /// <param name="morada"></param>
        /// <returns></returns>
        public bool AlterarMorada(string morada)
        {
            if (ReferenceEquals(this, null) || morada == "")
                return false;

            this.Morada = morada;

            return true;
        }


        /// <summary>
        /// Metodo para alterar o NIF de um Cliente
        /// </summary>
        /// <param name="nif"></param>
        /// <returns></returns>
        public bool AlterarNif(int nif)
        {
            if (ReferenceEquals(this, null) || nif < 0)
                return false;

            this.NIF = nif;

            return true;
        }


        /// <summary>
        /// Metodo para alterar o telemovel de um Cliente
        /// </summary>
        /// <param name="tel"></param>
        /// <returns></returns>
        public bool AlterarTelemovel(int tel)
        {
            if (ReferenceEquals(this, null) || tel < 0)
                return false;

            this.Telemovel = tel;

            return true;
        }



     


        #endregion

        #endregion

    }
}