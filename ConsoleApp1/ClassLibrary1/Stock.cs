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
    public class Stock
    {
        #region Attributes

        static List<Produto> listaProdutos;
        int capacidadeMax;
        string nomeArmazem;
        List<Produto> produtos;

        #endregion

        #region Methods

        #region Constructors

        static Stock()
        {
            listaProdutos = new List<Produto>();     
        }
        
        public Stock()
        {
            capacidadeMax = 0;
            nomeArmazem = string.Empty;
            produtos = new List<Produto>();

        }

        public Stock(int capacidadeMax, string nomeArmazem, List<Produto> produtos)
        {
            this.capacidadeMax = capacidadeMax;
            this.nomeArmazem = nomeArmazem;
            this.produtos = produtos;
        }
        #endregion

        #region Properties

        public int CapacidadeMax
        {
            get { return capacidadeMax; }
            set { capacidadeMax = value;}
        }

        public string NomeArmazem
        {
            get { return nomeArmazem; }
            set { nomeArmazem = value; }
        }

        public List<Produto> Produtos
        {
            get { return new List<Produto>(); }
        }

        public List<Produto> ListaProdutos
        {
            get { return new List<Produto>(); }
        }
        #endregion

        #region Operators
        #endregion

        #region Overrides
        #endregion

        #region Other_Methods


        /// <summary>
        /// Funçao para adicionar produto a um determinado armazem 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool AdicionarProduto(Produto p)
        {
            if (p == null || this.produtos.Count > this.CapacidadeMax) return false;
            
            if(ReferenceEquals(this.produtos,null))
                this.produtos = new List<Produto>();

            if (this.produtos.Contains(p)) return false;

            this.produtos.Add(p);
            return true;
        }


        /// <summary>
        /// Funçao para remover um determinado produto de uma determinado armazem
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool RemoverProduto(Produto p)
        {
            if (p == null) return false;

            if (ReferenceEquals(this.produtos, null) || this.produtos.Count == 0)
                return false;

            if (this.produtos.Contains(p))
            {
                this.produtos.Remove(p);
                return true;
            }
                

            return false;
        }


        /// <summary>
        /// Funçao para dar saida de uma determinada quantidade de um produto de um determinado armazem
        /// </summary>
        /// <param name="p"></param>
        /// <param name="quantidade"></param>
        /// <returns></returns>
        public bool RetirarQuantidade(Produto p, float quantidade)
        {
            if (p == null) return false;

            if (ReferenceEquals(this.produtos, null))
                this.produtos = new List<Produto>();

            if ((this.produtos.Contains(p)) && (p.Quantidade>=quantidade))
            {
                p.Quantidade -= quantidade;
                return true;
            }

            return false;
        }


        /// <summary>
        /// Funçao para dar entrada de uma determinada quantidade de um produto de um determinado armazem
        /// </summary>
        /// <param name="p"></param>
        /// <param name="quantidade"></param>
        /// <returns></returns>
        public bool AumentarQuantidade(Produto p, float quantidade)
        {
            if (p == null) return false;

            if (ReferenceEquals(this.produtos, null))
                this.produtos = new List<Produto>();

            if (this.produtos.Contains(p))
            {
                p.Quantidade += quantidade;
                return true;
            }

            return false;
        }



        /// <summary>
        /// Rever implementaçao a medida que avança o projeto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Produto ProdutoPorIdArmazem(int id)
        {
            if(ReferenceEquals(this.produtos, null))
                return null;

            if ((id < 0) || (this.produtos.Count < 1)) 
                return null;


            Produto aux;

            aux = this.produtos.Find(e => e.Id == id);

            if(aux == null)
                return null;

            return aux;
        }




        #endregion

        #endregion

    }
}