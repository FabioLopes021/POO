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
    public class Produto
    {
        #region Attributes

        static int totProd;
        int id;
        string nome;
        float valor;
        float garantiaAnos;
        int catgId;
        int marcaId;
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
            catgId = 0;
            marcaId = 0;
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
        public Produto(string nome, float valor, float garantia, int catgId, int marcaId)
        {
            this.nome = nome;
            this.valor = valor;
            this.garantiaAnos = garantia;
            this.catgId = catgId;
            this.marcaId = marcaId;
            this.id = totProd;
            this.quantidade = 0;
            totProd++;
        }

        #endregion

        #region Properties

        
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

        public int CatgId
        {
            set { catgId = value; }
            get { return catgId; }
        }

        public int MarcaId
        {
            set { marcaId = value; }
            get { return marcaId; }
        }

        public float Quantidade
        {
            set { quantidade = value; }
            get { return quantidade; }
        }

        public static int TotProd
        {
            set { totProd = value; }
        }

        #endregion

        #region Operators

        public static bool operator ==(Produto p1, Produto p2)
        {

            // Se apenas um dos objetos é nulo, são diferentes
            if (ReferenceEquals(p1, null) || ReferenceEquals(p2, null))
                return false;

            if (p1.Id == p2.Id)
                return true;

            return false;
        }



        public static bool operator !=(Produto p1, Produto p2)
        {
            if (p1 == p2)
                return false;

            return true;
        }


        #endregion

        #region Overrides

        public override bool Equals(object obj)
        {
            if (obj is Produto)
            {
                Produto a = obj as Produto;

                // Comparação dos atributos do objeto atual (this) com o objeto recebido (a)
                if ((a.Id == this.Id))
                {
                    return true;
                }
            }

            return false;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Id: {0}, Nome: {1},Valor: {2}, Garantia: {3}, CategoriaId: {4}, MarcaId: {5}, Quantidade: {6}",this.Id,this.Nome,this.Valor,this.GarantiaAnos,this.CatgId,this.MarcaId, this.Quantidade);
        }

        #endregion

        #region Other_Methods

        /// <summary>
        /// Funçao para calcular id a ser atribuido a cada Produto a ser criada
        /// </summary>
        /// <returns></returns>
        public static int AtribuirId()
        {
            int maxid = 1;

            List<Produto> lista = Stock.ListaProdutos;

            if (ReferenceEquals(lista, null) || lista.Count == 0)
                return maxid;

            foreach (Produto aux in lista)
            {
                if (aux.id > maxid)
                    maxid = aux.id;
            }

            return ++maxid;
        }

        public bool VerificaIntegridadeProduto()
        {
            if((this.nome == "") || (this.valor <= 0) || (this.garantiaAnos < 0))
                return false;

            if (!Marcas.VerificaMarcaPorId(this.MarcaId) || !Categorias.VerificaCategoriaPorId(this.CatgId))
                return false;
            
            return true;
        }



        public static bool ExisteProdutoPorId(int produtoId)
        {
            List<Produto> lista = Stock.ListaProdutos;


            if (produtoId < 0 || lista.Count < 1)
                return false;

            Produto aux = null;

            aux = lista.Find(e => e.Id == produtoId);

            if (aux == null)
                return false;

            return true;
        }


        public static Produto ProdutoPorId(int produtoId)
        {
            if (!ExisteProdutoPorId(produtoId))
                return null;

            List<Produto> lista = Stock.ListaProdutos;

            Produto aux = null;

            aux = lista.Find(e => e.Id == produtoId);

            if (aux == null)
                return null;

            return aux;
        }



        #endregion

        #endregion

    }
}