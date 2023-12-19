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
    public class Venda
    {
        #region Attributes
        
        Dictionary<int, int> artigosVendidos;
        DateTime data;
        int idCliente;
        int id;

        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// Construtor Default
        /// </summary>
        public Venda()
        {
            artigosVendidos = new Dictionary<int, int>();
            data = DateTime.Now;
            idCliente = 0;
            id = AtribuirId();
        }


        /// <summary>
        /// Construtor com dados
        /// </summary>
        /// <param name="nomeLoja"></param>
        /// <param name="data"></param>
        /// <param name="idCliente"></param>
        public Venda(DateTime data, int idCliente)
        {
            artigosVendidos = new Dictionary<int, int>();
            this.data = data;
            this.idCliente = idCliente;
            this.id = AtribuirId();
        }


        #endregion

        #region Properties


        /// <summary>
        /// Propriedade para aceder a variavel artigosVendidos
        /// </summary>
        public Dictionary<int, int> ArtigosVendidos
        {
            get { return new Dictionary<int, int>(artigosVendidos); }
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
        /// Propriedade para aceder a variavel idCliente
        /// </summary>
        public int IdCliente
        {
            get { return idCliente; }
            set { idCliente = value; }
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
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Venda v1, Venda v2)
        {

            // Se apenas um dos objetos é nulo, são diferentes
            if (ReferenceEquals(v1, null) || ReferenceEquals(v2, null))
                return false;

            if (v1.Id == v2.Id)
                return true;

            return false;
        }


        /// <summary>
        /// Operador que verifica se dois objetos desta classe sao diferentes
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Venda v1, Venda v2)
        {
            if (v1 == v2)
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
            if (obj is Venda)
            {
                Venda a = obj as Venda;

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
            return String.Format("ID: {0} - ID Cliente: {1} - Data: {2} - Artigos vendidos: {3}", this.id, this.IdCliente, this.Data, this.ArtigosVendidos.ToString());
        }


        #endregion

        #region Other_Methods


        /// <summary>
        /// Funçao para calcular id a ser atribuido a cada venda a ser criada
        /// </summary>
        /// <returns></returns>
        public static int AtribuirId()
        {
            int maxid = 1;

            List<Venda> lista = Vendas.ListaVendas;

            if (ReferenceEquals(lista, null) || lista.Count == 0)
                return maxid;

            foreach (Venda aux in lista)
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
        public bool AdicionarProdutoVenda(int produtoId, int quantidade)
        {
            if (!Produto.ExisteProdutoPorId(produtoId))
                return false;

            if (ReferenceEquals(this.artigosVendidos, null))
                this.artigosVendidos = new Dictionary<int, int>();

            if (this.artigosVendidos.ContainsKey(produtoId))
            {
                this.artigosVendidos[produtoId] += quantidade;
            }else
                this.artigosVendidos.Add(produtoId, quantidade);


            return true;
        }






        /*
                 public bool RemoverProdutoCompra(int produtoId, int quantidade)
        {
            if (Produto.ExisteProdutoPorId(produtoId))
                return false;

            if (ReferenceEquals(this.artigosComprados, null))
                this.artigosComprados = new Dictionary<int, int>();

            Produto aux = Produto.ProdutoPorId(produtoId);

            if (aux == null)
                return false;

            if (this.artigosComprados.ContainsKey(produtoId))
            {
                if (this.artigosComprados[produtoId] < quantidade)
                    this.artigosComprados[produtoId] -= quantidade;
                else
                    this.artigosComprados.Remove(produtoId);
                return true;
            }

            return false;
        } 
        */


        /// <summary>
        /// Funçao para Remover o id dos produtos e a respetiva quantidade do dicionario 
        /// </summary>
        /// <param name="produtoId"></param>
        /// <param name="quantidade"></param>
        /// <returns></returns>
        public bool RemoverProdutoVenda(int produtoId, int quantidade)
        {
            if (!Produto.ExisteProdutoPorId(produtoId))
                return false;

            if (ReferenceEquals(this.artigosVendidos, null))
                this.artigosVendidos = new Dictionary<int, int>();

            if (this.artigosVendidos.ContainsKey(produtoId))
            {
                if (this.ArtigosVendidos[produtoId] < quantidade)
                    this.artigosVendidos[produtoId] -= quantidade;
                else
                    this.artigosVendidos.Remove(produtoId);
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


        /// <summary>
        /// Funçao que verifica se um produto esta adicionado a venda
        /// </summary>
        /// <param name="idProduto"></param>
        /// <returns></returns>
        public bool VerificaProdutoVenda(int idProduto)
        {
            if (!Produto.ExisteProdutoPorId(idProduto))
                return false;

            foreach (KeyValuePair<int, int> parchave in this.ArtigosVendidos)
            {
                int chave = parchave.Key;

                if (chave == idProduto)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Funçao Para mostrar Lista de Compras
        /// </summary>
        public void MostraListaCompras()
        {
            if ((this.artigosVendidos.Count < 1))
                return;

            Console.WriteLine("-----Lista Venda-----");
            Console.WriteLine("Id: {0}, Data: {1}", this.Id, this.data);
            foreach (KeyValuePair<int, int> parchave in this.artigosVendidos)
            {
                int chave = parchave.Key;
                Produto p = Produto.ProdutoPorId(chave);
                if (p != null)
                    Console.WriteLine("Id: {0}, Nome: {1}, Valor: {2}, Categoria: {3}, Garantia: {4}, Quantidae: {5}", p.Id, p.Nome, p.Valor, p.CatgId, p.GarantiaAnos, p.Quantidade);
            }

            Console.WriteLine("----------------------");

        }


        #endregion

        #endregion

    }
}