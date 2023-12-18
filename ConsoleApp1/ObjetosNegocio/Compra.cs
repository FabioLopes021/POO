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
using System.ComponentModel;

namespace ObjetosNegocio
{
    /// <summary>
    /// Purpose: 
    /// Created by: Fábio Lopes & Ruben Costa
    /// Created on: 13/12/2023
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Compra
    {
        #region Attributes

        Dictionary<int, int> artigosComprados;
        DateTime data;
        int idFornecedor;
        int id;

        #endregion

        #region Methods

        #region Constructors

        public Compra()
        {
            artigosComprados = new Dictionary<int, int>();
            data = DateTime.Now;
            idFornecedor = 0;
            id = AtribuirId();
        }

        public Compra(string nomeLoja, DateTime data, int idFornecedor)
        {
            artigosComprados = new Dictionary<int, int>();
            this.data = data;
            this.idFornecedor = idFornecedor;
            this.id = AtribuirId();
        }

        #endregion

        #region Properties

        public Dictionary<int, int> ArtigosComprados
        {
            get { return new Dictionary<int, int>(artigosComprados); }
        }

        public DateTime Data
        {
            get { return data; }
            set { data = value; }
        }

        public int IdFornecedor
        {
            get { return idFornecedor; }
            set { idFornecedor = value; }
        }

        public int Id
        {
            get { return id; }
        }

        #endregion

        #region Operators
        #endregion

        #region Overrides
        #endregion

        #region Other_Methods

        
        /// <summary>
        /// Funçao para calcular id a ser atribuido a cada marca a ser criada
        /// </summary>
        /// <returns></returns>
        public static int AtribuirId()
        {
            int maxid = 1;

            List<Compra> lista = Compras.ListaCompras;

            if (ReferenceEquals(lista, null) || lista.Count == 0)
                return maxid;

            foreach (Compra aux in lista)
            {
                if (aux.id > maxid)
                    maxid = aux.id;
            }

            return ++maxid;
        }
        

        /// <summary>
        /// Funçao para adicionar produtos ao dicionario 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="quantidade"></param>
        /// <returns></returns>
        public bool AdicionarProdutoCompra(int produtoId, int quantidade)
        {
            if (!Produto.ExisteProdutoPorId(produtoId))
                return false;

            if (ReferenceEquals(this.artigosComprados, null))
                this.artigosComprados = new Dictionary<int, int>();

            Produto aux = Produto.ProdutoPorId(produtoId);

            if(aux == null)
                return false;

            if (this.artigosComprados.ContainsKey(produtoId))
            {
                this.artigosComprados[produtoId] += quantidade;
            }

            this.artigosComprados.Add(produtoId, quantidade);
            return true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="quantidade"></param>
        /// <returns></returns>
        public bool RemoverProdutoCompra(int produtoId, int quantidade)
        {
            if (!Produto.ExisteProdutoPorId(produtoId))
                return false;

            if (ReferenceEquals(this.artigosComprados, null))
                this.artigosComprados = new Dictionary<int, int>();

            Produto aux = Produto.ProdutoPorId(produtoId);

            if (aux == null)
                return false;

            if (this.artigosComprados.ContainsKey(produtoId))
            {
                if (this.artigosComprados[produtoId] > quantidade)
                    this.artigosComprados[produtoId] -= quantidade;
                else
                    this.artigosComprados.Remove(produtoId);
                return true;
            }

            return false;
        }


        /// <summary>
        /// Funçao que verifica a integridade da Compra, se os artigos estao em stock ou precisam de ser inicializados
        /// </summary>
        /// <returns></returns>
        public bool VerificaIntegridadeCompra()
        {
            //verificar id Fornecedor
            if (!Fornecedores.VerificaFornecedorId(this.IdFornecedor))
                return false;

            return true;
        }


        public bool VerificaProdutoCompra(int idProduto)
        {
            if (!Produto.ExisteProdutoPorId(idProduto))
                return false;

            foreach(KeyValuePair<int,int> parchave in this.artigosComprados)
            {
                int chave = parchave.Key;

                if( chave == idProduto)
                    return true;
            }

            return false;
        }

        public void MostraListaCompras()
        {
            if((this.artigosComprados.Count < 1) || ReferenceEquals(this,null))
                return;

            Console.WriteLine("-----Lista Compra-----");
            Console.WriteLine("Id: {0}, Data: {1}",this.Id, this.data);
            foreach (KeyValuePair<int, int > parchave in this.artigosComprados)
            {
                int chave = parchave.Key;
                Produto p = Produto.ProdutoPorId(chave);
                if(p != null)
                    Console.WriteLine("Id: {0}, Nome: {1}, Valor: {2}, Quantidade Compra: {3}", p.Id, p.Nome, p.Valor, this.artigosComprados[chave]);
            }

            Console.WriteLine("----------------------");

        }


        #endregion

        #endregion

    }
}