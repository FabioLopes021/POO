/*
*	<copyright file="ClassLibrary1.cs" company="IPCA">
*	Copyright (c) 2023 All Rights Reserved
*	</copyright>
* 	<author>Fábio Lopes</author>
*   <date>13/11/2023</date>
*	<description></description>
*/

namespace ClassLibrary1
{
    /// <summary>
    /// Purpose: Garantia de classe 
    /// Created by: Fábio Lopes
    /// Created on: 13/11/2023
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Produto
    {
        #region Attributes

        static int totProd;
        int id;
        string nome;
        float valor;
        float garantiaAnos;
        Categoria catg;
        Marca marca;
        float quantidade;

        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// Constutor estatico
        /// </summary>
        static Produto()
        {
            totProd = 1;
        }

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public Produto()
        {
            nome = "";
            valor = 0;
            garantiaAnos = 0;
            totProd++;
            id = totProd;
            catg = new Categoria();
            marca = new Marca();
            quantidade = 0;
        }

        /// <summary>
        /// Construtor com dados public Produto(string nome, float valor, Categoria catg, float garantia)
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="valor"></param>
        /// <param name="garantia"></param>
        /// <param name="catg"></param>
        /// <param name="marca"></param>
        public Produto(string nome, float valor, float garantia, Categoria catg, Marca marca, float quantidade)
        {
            this.nome = nome;
            this.valor = valor;
            this.garantiaAnos = garantia;
            this.catg= catg;
            this.marca = marca;
            this.id = totProd;
            this.quantidade = quantidade;
            totProd++;
        }

        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        
        public int Id{
            set{ id = value; }
            get{ return id;  }
        }

        public string Nome
        {
            set { nome = value; }
            get { return nome; }
        }

        public float Valor
        {
            set { valor = value; }
            get { return valor; }
        }


        public float GarantiaAnos
        {
            set { valor = value; }
            get { return garantiaAnos;}
        }

        public Categoria Catg
        {
            set { catg = value; }
            get { return catg; }
        }

        public Marca Marca
        {
            set { marca = value; }
            get { return marca; }
        }

        public float Quantidade
        {
            set { quantidade = value; }
            get { return quantidade; }
        }

        #endregion

        #region Operators
        #endregion

        #region Overrides


        public override string ToString()
        {

            return string.Format("Id: {0}, Nome: {1},Valor: {2}, Garantia: {3}, Categoria: {4}, Marca: {5}",this.Id,this.Nome,this.Valor,this.GarantiaAnos,this.catg.ToString(),
                this.Marca.ToString());
        }

        #endregion

        #region Other_Methods



        #endregion

        #endregion

    }
}