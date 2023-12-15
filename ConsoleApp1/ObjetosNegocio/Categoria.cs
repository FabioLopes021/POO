/*
*	<copyright file="ClassLibrary1.cs" company="IPCA">
*	Copyright (c) 2023 All Rights Reserved
*	</copyright>
* 	<author>Fábio Lopes</author>
*   <date>13/11/2023</date>
*	<description></description>
*/

using System.Collections;
using System.Collections.Generic;
using Dados;

namespace ObjetosNegocio
{
    /// <summary>
    /// Purpose: Garantia de classe 
    /// Created by: Fábio Lopes
    /// Created on: 13/11/2023
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Categoria
    {
        #region Attributes

        string nome;
        int id;


        #endregion

        #region Methods

        #region Constructors

        public Categoria()
        {
            nome = "";
            id = this.AtribuirId();
        }

        public Categoria(string nome)
        {
            this.nome = nome;
            id = this.AtribuirId();
        }

        #endregion

        #region Properties

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public int Id
        {
            get { return id; }
        }

        #endregion

        #region Operators
        #endregion

        #region Overrides

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





        #endregion

        #endregion

    }
}