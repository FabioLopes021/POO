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
    public class Categoria: ICategoria
    {
        #region Attributes

        string nome;
        int id;


        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// Construtor default
        /// </summary>
        public Categoria()
        {
            nome = "";
            id = this.AtribuirId();
        }

        /// <summary>
        /// Construtor com dados
        /// </summary>
        /// <param name="nome"></param>
        public Categoria(string nome)
        {
            this.nome = nome;
            id = this.AtribuirId();
        }

        #endregion

        #region Properties


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
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
        public static bool operator ==(Categoria c1, Categoria c2)
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
        public static bool operator !=(Categoria c1, Categoria c2)
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
            if (obj is Categoria)
            {
                Categoria a = obj as Categoria;

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
            return string.Format("Id: {0}, Nome: {1}", this.Id, this.Nome);
        }

        #endregion

        #region Other_Methods


        /// <summary>
        /// Funçao para calcular id a ser atribuido a cada Categoria a ser criada
        /// </summary>
        /// <returns></returns>
        public int AtribuirId()
        {
            int maxid = 1;

            List<Categoria> list = Categorias.ListaCategorias;

            if (ReferenceEquals(list, null) || list.Count == 0)
                return maxid;

            foreach (Categoria aux in list)
            {
                if (aux.id > maxid)
                    maxid = aux.id;
            }

            return ++maxid;
        }


        /// <summary>
        /// Metodo para alterar o nome de uma Categoria
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



        #endregion

        #endregion

    }
}