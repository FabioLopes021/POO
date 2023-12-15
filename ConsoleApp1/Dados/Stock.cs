/*
*	<copyright file="Dados.cs" company="IPCA">
*	Copyright (c) 2023 All Rights Reserved
*	</copyright>
* 	<author>Fábio Lopes & Ruben Costa</author>
*   <date>13/12/2023</date>
*	<description></description>
*/

using System;
using System.Collections.Generic;
using ObjetosNegocio;
using Excecoes;
using System.Runtime.Remoting.Channels;

namespace Dados
{
    /// <summary>
    /// Purpose: 
    /// Created by: Fábio Lopes & Ruben Costa
    /// Created on: 13/12/2023
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Stock
    {
        #region Attributes

        static List<Produto> listaProdutos;
        const int CAPACIDADEMAX = 100;
        static string nomeArmazem;

        #endregion

        #region Methods

        #region Constructors

        static Stock()
        {
            listaProdutos = new List<Produto>();
        }

        #endregion

        #region Properties

        public static string NomeArmazem
        {
            get { return nomeArmazem; }
            set { nomeArmazem = value; }
        }

        public static List<Produto> ListaProdutos
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
        public static bool AdicionarProduto(Produto p)
        {
            if (p == null || listaProdutos.Count >= CAPACIDADEMAX)
                throw new StockExcecoes("Falha de Stock (Capacidade do Armazem excedida)");

            if(!p.VerificaIntegridadeProduto())
                throw new StockExcecoes("Falha de Stock (Produto com atributos em falta)");

            if (listaProdutos.Contains(p))
                throw new StockExcecoes("Falha de Stock (Produto ja existente no armazem)");

            listaProdutos.Add(p);
            return true;
        }


        /// <summary>
        /// Funçao para remover um determinado produto de uma determinado armazem
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool RemoverProduto(Produto p)
        {
            if (p == null) 
                return false;

            if (!p.VerificaIntegridadeProduto())
                throw new StockExcecoes("Falha de Stock (Impossivel avaliar, Produto com atributos em falta)");

            if (ReferenceEquals(listaProdutos, null) || listaProdutos.Count == 0)
                throw new StockExcecoes("Falha de Stock (Impossivel concluir operaçao. Lista vazia)");

            if (listaProdutos.Contains(p))
            {
                listaProdutos.Remove(p);
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
        public static bool RetirarQuantidade(Produto p, float quantidade)
        {
            if (p == null) 
                return false;

            if (!p.VerificaIntegridadeProduto())
                throw new StockExcecoes("Falha de Stock (Impossivel avaliar, Produto com atributos em falta)");

            if (ReferenceEquals(listaProdutos, null))
                throw new StockExcecoes("Falha de Stock (Impossivel concluir operaçao. Lista vazia)");

            if ((listaProdutos.Contains(p)) && (p.Quantidade >= quantidade))
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
        public static bool AumentarQuantidade(Produto p, float quantidade)
        {
            if (p == null) 
                return false;

            if (!p.VerificaIntegridadeProduto())
                throw new StockExcecoes("Falha de Stock (Impossivel avaliar, Produto com atributos em falta)");

            if (listaProdutos.Contains(p))
            {
                p.Quantidade += quantidade;
                return true;
            }

            return false;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="listaCompras"></param>
        /// <returns></returns>
        public static bool VerificaDispProdutos(Dictionary<Produto, int> listaVendas) 
        {
            if(ReferenceEquals(listaVendas, null))
                return false;

            bool aux = false;


            foreach(KeyValuePair<Produto, int> parchave in listaVendas)
            {
                Produto chave = parchave.Key;

                try
                {
                    aux = VerificaDispProduto(chave, listaVendas[chave]);
                }
                catch (StockExcecoes e)
                {
                    throw new StockExcecoes("Stock: Erro no metodo VerificaDispProduto " + "-" + e.Message);
                }

                if (!aux)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="quantidade"></param>
        /// <returns></returns>
        public static bool VerificaDispProduto(Produto p, int quantidade)
        {
            if (p == null) 
                return false;

            Produto aux = null;

            aux = listaProdutos.Find(e => e.Id == p.Id);

            if(aux == null)
                return false;

            if (aux.Quantidade >= quantidade)
                return true;

            return false;
        }


        public static bool AtualizarStockVenda(Dictionary<Produto, int> listaVendas)
        {
            if (ReferenceEquals(listaVendas, null))
                return false;



            foreach (KeyValuePair<Produto, int> parchave in listaVendas)
            {
                Produto chave = parchave.Key;

                if (!RetirarQuantidade(chave, listaVendas[chave]))
                {
                    return false;
                }
            }


            return true;

        }


        // Ver com o professor, adicionar try catch ???
        public static bool AtualizarStockCompra(Dictionary<Produto, int> listaVendas)
        {
            if (ReferenceEquals(listaVendas, null))
                return false;

            bool aux = false;


            foreach (KeyValuePair<Produto, int> parchave in listaVendas)
            {
                Produto chave = parchave.Key;

                if (!listaProdutos.Contains(chave))
                {
                    try
                    {
                        aux = AdicionarProduto(chave);
                    }catch (StockExcecoes e)
                    {
                        throw new StockExcecoes("Stock: Erro no metodo AdicionarProduto " + "-" + e.Message);
                    }
                    if(!aux)
                        return false;
                    else
                    {
                        try
                        {
                            aux = AumentarQuantidade(chave, listaVendas[chave]);
                        }
                        catch (StockExcecoes e)
                        {
                            throw new StockExcecoes("Stock: Erro no metodo AumentarQuantidade " + "-" + e.Message);
                        }
                        if (!aux)
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    try
                    {
                        aux = AumentarQuantidade(chave, listaVendas[chave]);
                    }
                    catch (StockExcecoes e)
                    {
                        throw new StockExcecoes("Stock: Erro no metodo AumentarQuantidade " + "-" + e.Message);
                    }
                    if (!aux)
                    {
                        return false;
                    }
                }
            }


            return true;

        }




        #endregion

        #endregion

    }
}