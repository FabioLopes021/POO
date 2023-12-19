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

namespace ObjetosNegocio
{
    [Serializable]
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


        /// <summary>
        /// Constutor default
        /// </summary>
        public Compra()
        {
            artigosComprados = new Dictionary<int, int>();
            data = DateTime.Now;
            idFornecedor = 0;
            id = AtribuirId();
        }

        /// <summary>
        /// Constutor com dados
        /// </summary>
        /// <param name="data"></param>
        /// <param name="idFornecedor"></param>
        public Compra(DateTime data, int idFornecedor)
        {
            artigosComprados = new Dictionary<int, int>();
            this.data = data;
            this.idFornecedor = idFornecedor;
            this.id = AtribuirId();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Propriedade para aceder a variavel artigosComprados
        /// </summary>
        public Dictionary<int, int> ArtigosComprados
        {
            get { return new Dictionary<int, int>(artigosComprados); }
        }


        /// <summary>
        /// Propriedade para aceder a variavel data
        /// </summary>
        public DateTime Data
        {
            get { return data; }
            set { data = value; }
        }


        /// <summary>
        /// Propriedade para aceder a variavel idFornecedor
        /// </summary>
        public int IdFornecedor
        {
            get { return idFornecedor; }
            set { idFornecedor = value; }
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
        public static bool operator ==(Compra c1, Compra c2)
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
        public static bool operator !=(Compra c1, Compra c2)
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
            if (obj is Compra)
            {
                Compra a = obj as Compra;

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
            return String.Format("ID: {0} - ID Fornecedor: {1} - Data: {2} - Artigos: {2}", this.id, this.IdFornecedor, this.Data, this.ArtigosComprados.ToString());
        }


        #endregion

        #region Other_Methods


        /// <summary>
        /// Funçao para calcular id a ser atribuido a cada Compra a ser criada
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
        /// Funçao para adicionar o id dos produtos e a respetiva qunatidade ao dicionario 
        /// </summary>
        /// <param name="produtoId"></param>
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
            }else
                this.artigosComprados.Add(produtoId, quantidade);

            return true;
        }


        /// <summary>
        /// Funçao para Remover o id dos produtos e a respetiva qunatidade do dicionario 
        /// </summary>
        /// <param name="produtoId"></param>
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



        /// <summary>
        /// Funçao que verifica se um produto esta adicionado a compra
        /// </summary>
        /// <param name="idProduto"></param>
        /// <returns></returns>
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



        #endregion

        #endregion

    }
}