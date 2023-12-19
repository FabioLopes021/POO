/*
*	<copyright file="ClassLibrary1.cs" company="IPCA">
*	Copyright (c) 2023 All Rights Reserved
*	</copyright>
* 	<author>Fábio Lopes</author>
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
    /// Created by: Fábio Lopes
    /// Created on: 13/11/2023
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Cliente
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
        /// The default Constructor.
        /// </summary>
        public Cliente()
        {
            nome = "";
            morada = "";
            nif = 0;
            telemovel = 0;
            id = AtribuirId();
        }

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
        /// 
        /// </summary>
        public string Nome
        {
            set { nome = value; }
            get { return nome; }
        }

        public string Morada
        {
            set { morada = value; }
            get { return morada; }
        }

        public int Telemovel
        {
            set { telemovel = value; }
            get { return telemovel; }
        }

        public int NIF
        {
            set { nif = value; }
            get { return nif; }
        }

        public int Id
        {
            get { return id; }
        }

        #endregion

        #region Operators

        public static bool operator ==(Cliente c1, Cliente c2)
        {

            // Se apenas um dos objetos é nulo, são diferentes
            if (ReferenceEquals(c1, null) || ReferenceEquals(c2, null))
                return false;

            if (c1.Id == c2.Id)
                return true;

            return false;
        }



        public static bool operator !=(Cliente c1, Cliente c2)
        {
            if (c1 == c2)
                return false;

            return true;
        }

        #endregion

        #region Overrides

        public override bool Equals(object obj)
        {
            if (obj is Cliente)
            {
                Cliente a = obj as Cliente;

                // Comparação dos atributos do objeto atual (this) com o objeto recebido (a)
                if ((a.Id == this.Id))
                {
                    return true;
                }
            }

            return false;
        }


        public override string ToString()
        {

            return string.Format("Id: {0}, Nome: {1}, Morada: {2}, NIF: {3}, Telemovel: {4}", this.Id, this.Nome, this.Morada, this.NIF, this.Telemovel);
        }



        #endregion

        #region Other_Methods

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

        #endregion

        #endregion

    }
}