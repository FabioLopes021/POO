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

        Dictionary<Produto, int> artigosComprados;
        DateTime data;
        int idFornecedor;
        int id;

        #endregion

        #region Methods

        #region Constructors

        public Compra()
        {
            artigosComprados = new Dictionary<Produto, int>();
            data = DateTime.Now;
            idFornecedor = 0;
            id = AtribuirId();
        }

        public Compra(string nomeLoja, DateTime data, int idCliente)
        {
            artigosComprados = new Dictionary<Produto, int>();
            this.data = data;
            this.idFornecedor = idCliente;
            this.id = AtribuirId();
        }

        #endregion

        #region Properties

        public Dictionary<Produto, int> ArtigosComprados
        {
            get { return new Dictionary<Produto, int>(artigosComprados); }
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

            if (ReferenceEquals(lista, null))
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
        public bool AdicionarProdutoCompra(Produto p, int quantidade)
        {
            if (ReferenceEquals(p, null))
                return false;

            if (ReferenceEquals(this.artigosComprados, null))
                this.artigosComprados = new Dictionary<Produto, int>();

            if (this.artigosComprados.ContainsKey(p))
            {
                this.artigosComprados[p] += quantidade;
            }

            this.artigosComprados.Add(p, quantidade);
            return true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="quantidade"></param>
        /// <returns></returns>
        public bool RemoverProdutoCompra(Produto p, int quantidade)
        {
            if (ReferenceEquals(p, null))
                return false;

            if (ReferenceEquals(this.artigosComprados, null))
                this.artigosComprados = new Dictionary<Produto, int>();

            if (this.artigosComprados.ContainsKey(p))
            {
                if (this.artigosComprados[p] < quantidade)
                    this.artigosComprados[p] -= quantidade;
                else
                    this.artigosComprados.Remove(p);
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
            if (!Fornecedores.VerificaFornecedorId(this.Id))
                return false;

            return true;
        }



        #endregion

        #endregion

    }
}