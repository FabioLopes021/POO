/*
*	<copyright file="ObjetosNegocio.cs" company="IPCA">
*	Copyright (c) 2023 All Rights Reserved
*	</copyright>
* 	<author>Fábio Lopes & Ruben Costa</author>
*   <date>13/12/2023</date>
*	<description></description>
*/
using Dados;
using System;
using System.Collections.Generic;

namespace ObjetosNegocio
{
    [Serializable]
    /// <summary>
    /// Purpose: 
    /// Created by: Fábio Lopes & Ruben Costa
    /// Created on: 13/12/2023
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Fornecedor
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
        /// Constutor default
        /// </summary>
        public Fornecedor()
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
        public Fornecedor(string nome, string morada, int nif, int telemovel)
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
        /// <param name="f1"></param>
        /// <param name="f2"></param>
        /// <returns></returns>
        public static bool operator ==(Fornecedor f1, Fornecedor f2)
        {

            // Se apenas um dos objetos é nulo, são diferentes
            if (ReferenceEquals(f1, null) || ReferenceEquals(f2, null))
                return false;

            if (f1.Id == f2.Id)
                return true;

            return false;
        }


        /// <summary>
        /// Operador que verifica se dois objetos desta classe sao diferentes
        /// </summary>
        /// <param name="f1"></param>
        /// <param name="f2"></param>
        /// <returns></returns>
        public static bool operator !=(Fornecedor f1, Fornecedor f2)
        {
            if (f1 == f2)
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
            if (obj is Fornecedor)
            {
                Fornecedor a = obj as Fornecedor;

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
        /// Funçao para calcular id a ser atribuido a cada Fornecedor a ser criado
        /// </summary>
        /// <returns></returns>
        public static int AtribuirId()
        {
            int maxid = 1;

            List<Fornecedor> lista = Fornecedores.ListaFornecedores;

            if (ReferenceEquals(lista, null) || lista.Count == 0)
                return maxid;

            foreach (Fornecedor aux in lista)
            {
                if (aux.id > maxid)
                    maxid = aux.id;
            }

            return ++maxid;
        }
        

        #endregion

        #endregion

    }
}