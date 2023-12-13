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
    public class Marca
    {
        #region Attributes

        
        private string morada, nome;
        int id;


        #endregion

        #region Methods

        #region Constructors

        public Marca()
        {
            morada = "";
            nome = "";
            id = 0;
        }

        public Marca(string morada, string nome)
        {
            this.morada = morada;
            this.nome = nome;
            id = AtribuirId();
        }

        #endregion

        #region Properties

        public string Morada
        {
            get { return morada; }
            set { morada = value; }
        }

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

            List<Marca> aux = Marcas.ListaMarcas;

            if (ReferenceEquals(listaMarcas, null))
                return maxid;

            foreach (Marca aux in listaMarcas)
            {
                if (aux.id > maxid)
                    maxid = aux.id;
            }

            return maxid;
        }

        #endregion

        #endregion

    }
}