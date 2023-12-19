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
    public class Marca
    {
        #region Attributes

        
        private string morada, nome;
        int id;


        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// Construtor default
        /// </summary>
        public Marca()
        {
            morada = "";
            nome = "";
            id = 0;
        }


        /// <summary>
        /// Construtor com dados
        /// </summary>
        /// <param name="morada"></param>
        /// <param name="nome"></param>
        public Marca(string morada, string nome)
        {
            this.morada = morada;
            this.nome = nome;
            id = AtribuirId();
        }

        #endregion

        #region Properties


        /// <summary>
        /// Propriedade para aceder a variavel morada
        /// </summary>
        public string Morada
        {
            get { return morada; }
            set { morada = value; }
        }


        /// <summary>
        /// Propriedade para aceder a variavel nome
        /// </summary>
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
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
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns></returns>
        public static bool operator ==(Marca m1, Marca m2)
        {

            if (ReferenceEquals(m1, null) || ReferenceEquals(m2, null))
                return false;

            if (m1.Id == m2.Id)
                return true;

            return false;
        }



        /// <summary>
        /// Operador que verifica se dois objetos desta classe sao diferentes
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Marca m1, Marca m2)
        {
            if (m1 == m2)
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
            if (obj is Marca)
            {
                Marca a = obj as Marca;

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

            return string.Format("Id: {0}, Nome: {1}, Morada: {2}", this.Id, this.Nome, this.Morada );
        }

        #endregion

        #region Other_Methods

        
        /// <summary>
        /// Funçao para calcular id a ser atribuido a cada marca a ser criada
        /// </summary>
        /// <returns></returns>
        public static int AtribuirId()
        {
            int maxid = 1;

            List<Marca> lista = Marcas.ListaMarcas;

            if (ReferenceEquals(lista, null) || lista.Count == 0)
                return maxid;

            foreach (Marca aux in lista)
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