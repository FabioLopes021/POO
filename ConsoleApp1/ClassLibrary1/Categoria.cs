/*
*	<copyright file="ClassLibrary1.cs" company="IPCA">
*	Copyright (c) 2023 All Rights Reserved
*	</copyright>
* 	<author>Fábio Lopes</author>
*   <date>13/11/2023</date>
*	<description></description>
*/

using System;
using System.Collections.Generic;

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

        static List<Categoria> ListaCategorias;
        string nome;
        int id;


        #endregion

        #region Methods

        #region Constructors

        static Categoria()
        {
            ListaCategorias = new List<Categoria>();
        }

        public Categoria()
        {
            nome = "";
            id = 0;
        }

        public Categoria(string morada, string nome)
        {
            this.nome = nome;
            id = AtribuirId();
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
        public static int AtribuirId()
        {
            int maxid = 1;

            if (ReferenceEquals(ListaCategorias, null))
                return maxid;

            foreach (Categoria aux in ListaCategorias)
            {
                if (aux.id > maxid)
                    maxid = aux.id;
            }

            return maxid;
        }


        /// <summary>
        /// Funçao para adicionar uma marca a lista de marcas
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static bool guardarCategoria(Categoria c)
        {

            if (ReferenceEquals(c, null) || ReferenceEquals(ListaCategorias, null))
                return false;

            if (ListaCategorias.Contains(c))
                return false;

            ListaCategorias.Add(c);
            return true;
        }

        
        public Categoria CategoriaPorId(int id)
        {
            if (ReferenceEquals(ListaCategorias, null))
                return null;

            if ((id < 0) || (ListaCategorias.Count < 1))
                return null;


            Categoria aux;

            aux = ListaCategorias.Find(e => e.Id == id);

            if (aux == null)
                return null;

            return aux;
        }


        #endregion

        #endregion



    }
}