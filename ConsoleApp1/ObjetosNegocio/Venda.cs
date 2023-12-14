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
    /// <summary>
    /// Purpose: 
    /// Created by: Fábio Lopes & Ruben Costa
    /// Created on: 13/12/2023
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Venda
    {
        #region Attributes

        Dictionary<Produto, int> artigosVendidos;
        DateTime data;
        int idCliente;
        int id;

        #endregion

        #region Methods

        #region Constructors

        public Venda()
        {
            artigosVendidos = new Dictionary<Produto, int>();
            data = DateTime.Now;
            idCliente = 0;
            id = AtribuirId();
        }

        public Venda(string nomeLoja, DateTime data, int idCliente)
        {
            artigosVendidos = new Dictionary<Produto, int>();
            this.data = data;
            this.idCliente = idCliente;
            this.id = AtribuirId();
        }


        #endregion

        #region Properties

        public Dictionary<Produto, int> ArtigosVendidos
        {
            get { return new Dictionary<Produto, int>(artigosVendidos); }
        }

        public DateTime Data
        {
            get { return data; }
            set { data = value; }
        }

        public int IdCliente
        {
            get { return idCliente; }
            set { idCliente = value; }
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

            List<Venda> lista = Vendas.ListaVendas;

            if (ReferenceEquals(lista, null))
                return maxid;

            foreach (Venda aux in lista)
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
        public bool AdicionarProdutoVenda(Produto p, int quantidade)
        {
            if (ReferenceEquals(p, null))
                return false;

            if (ReferenceEquals(this.artigosVendidos, null))
                this.artigosVendidos = new Dictionary<Produto, int>();

            if (this.artigosVendidos.ContainsKey(p))
            {
                this.artigosVendidos[p] += quantidade;
            }

            this.artigosVendidos.Add(p, quantidade);
            return true;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="quantidade"></param>
        /// <returns></returns>
        public bool RemoverProdutoVenda(Produto p, int quantidade)
        {
            if (ReferenceEquals(p, null))
                return false;

            if (ReferenceEquals(this.artigosVendidos, null))
                this.artigosVendidos = new Dictionary<Produto, int>();

            if (this.artigosVendidos.ContainsKey(p))
            {
                if (this.ArtigosVendidos[p] < quantidade)
                    this.artigosVendidos[p] -= quantidade;
                else
                    this.artigosVendidos.Remove(p);
                return true;
            }

            return false;
        }

        
        /// <summary>
        /// Funçao que verifica a integridade da venda, se os artigos estao disponiveis em stock e o id do cliente esta correto
        /// </summary>
        /// <returns></returns>
        public bool VerificaIntegridadeVenda()
        {

            //verificar id CLiente
            if (!Clientes.VerificaClienteId(this.IdCliente))
                return false;

            //Verificar a disponivilidade no stock do armazem indicado
            if (!Stock.VerificaDispProdutos(this.ArtigosVendidos))
                return false;

            return true;
        }
        



        #endregion

        #endregion

    }
}