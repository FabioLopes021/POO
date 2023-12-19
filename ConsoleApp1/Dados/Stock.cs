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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Dados
{
    [Serializable]
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

        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// Construtor estatico
        /// </summary>
        static Stock()
        {
            listaProdutos = new List<Produto>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Propriedade para Criar uma lista nova com os mesmos dados da lista de Produtos
        /// </summary>
        public static List<Produto> ListaProdutos
        {
            get { return new List<Produto>(listaProdutos); }
        }


        #endregion

        #region Operators
        #endregion

        #region Overrides
        #endregion

        #region Other_Methods


        /// <summary>
        /// Metodo para adicionar produto ao Stock
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


        /*  Nao implementar (Nao remover produtos para nao perder referencias de Compras/Vendas antigas)
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
        */



        /// <summary>
        /// Metodo para dar saida de uma determinada quantidade de um produto do Stock
        /// </summary>
        /// <param name="produtoId"></param>
        /// <param name="quantidade"></param>
        /// <returns></returns>
        /// <exception cref="StockExcecoes"></exception>
        public static bool RetirarQuantidade(int produtoId, float quantidade)
        {
            if (produtoId < 1 || !Produto.ExisteProdutoPorId(produtoId)) 
                return false;

            Produto p = Produto.ProdutoPorId(produtoId);

            if(p != null)
            {
                if (!p.VerificaIntegridadeProduto())
                    throw new StockExcecoes("Falha de Stock (Impossivel avaliar, Produto com atributos em falta)");

                if (ReferenceEquals(listaProdutos, null))
                    throw new StockExcecoes("Falha de Stock (Impossivel concluir operaçao. Lista vazia)");

                if ((listaProdutos.Contains(p)) && (p.Quantidade >= quantidade))
                {
                    p.Quantidade -= quantidade;
                    return true;
                }
            }
            
            return false;
        }


        /// <summary>
        /// Metodo para dar entrada de uma determinada quantidade de um produto no Stock
        /// </summary>
        /// <param name="produtoId"></param>
        /// <param name="quantidade"></param>
        /// <returns></returns>
        /// <exception cref="StockExcecoes"></exception>
        public static bool AumentarQuantidade(int produtoId, float quantidade)
        {
            if (produtoId < 1 || !Produto.ExisteProdutoPorId(produtoId))
                return false;

            Produto p = Produto.ProdutoPorId(produtoId);


            if (p != null)
            {
                if (!p.VerificaIntegridadeProduto())
                    throw new StockExcecoes("Falha de Stock (Impossivel avaliar, Produto com atributos em falta)");

                if (listaProdutos.Contains(p))
                {
                    p.Quantidade += quantidade;
                    return true;
                }
            }


            return false;
        }


        /// <summary>
        /// Metodo que verifica a disponibilidade dos produtos de uma venda no stock
        /// </summary>
        /// <param name="listaVendas"></param>
        /// <returns></returns>
        /// <exception cref="StockExcecoes"></exception>
        public static bool VerificaDispProdutos(Dictionary<int, int> listaVendas) 
        {
            if(ReferenceEquals(listaVendas, null))
                return false;

            bool aux = false;


            foreach(KeyValuePair<int, int> parchave in listaVendas)
            {
                int chave = parchave.Key;

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
        /// Metodo que verifica a disponibilidade de um produto no stock
        /// </summary>
        /// <param name="produtoId"></param>
        /// <param name="quantidade"></param>
        /// <returns></returns>
        public static bool VerificaDispProduto(int produtoId, int quantidade)
        {
            if (produtoId < 1 || !Produto.ExisteProdutoPorId(produtoId))
                return false;

            Produto aux = null;

            aux = listaProdutos.Find(e => e.Id == produtoId);

            if (aux == null)
                return false;

            if (aux.Quantidade >= quantidade)
                return true;

            return false;
        }


        /// <summary>
        /// Metodo para Atualizar as quantidades do stock ao registar uma venda
        /// </summary>
        /// <param name="listaVendas"></param>
        /// <returns></returns>
        public static bool AtualizarStockVenda(Dictionary<int, int> listaVendas)
        {
            if (ReferenceEquals(listaVendas, null))
                return false;


            foreach (KeyValuePair<int, int> parchave in listaVendas)
            {
                int chave = parchave.Key;

                if (!RetirarQuantidade(chave, listaVendas[chave]))
                {
                    return false;
                }
            }


            return true;

        }



        /// <summary>
        /// Metodo para Atualizar as quantidades do stock ao registar uma compra
        /// </summary>
        /// <param name="listaVendas"></param>
        /// <returns></returns>
        /// <exception cref="StockExcecoes"></exception>
        public static bool AtualizarStockCompra(Dictionary<int, int> listaVendas)
        {
            if (ReferenceEquals(listaVendas, null))
                return false;

            bool aux = false;


            foreach (KeyValuePair<int, int> parchave in listaVendas)
            {
                int chave = parchave.Key;
                Produto produtoChave = null;

                produtoChave = Produto.ProdutoPorId(chave);

                if( produtoChave != null)
                {
                    if (listaProdutos.Contains(produtoChave))
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
                    else
                    {
                            throw new StockExcecoes("Stock: Nao é possivel aceder a um produto que nao esteja na lista ");
                    }
                }
            }


            return true;

        }


        /// <summary>
        /// Funçao para guardar os dados da listaProdutos num ficheiro binario
        /// </summary>
        /// <returns></returns>
        public static bool GuardarStock(string file)
        {
            Stream s;

            try
            {
                s = File.Open(file, FileMode.Create);
            }
            catch (Exception e)
            {
                throw new Exception("Passou na funcao (GuardaStock) " + "-" + e.Message);
            }

            BinaryFormatter b = new BinaryFormatter();

            b.Serialize(s, listaProdutos);
            s.Close();
            return true;
        }



        /// <summary>
        /// Funçao para carregar dados de um ficheiro binario para a lista de Produtos
        /// </summary>
        /// <returns></returns>
        public static bool CarregaStock(string file)
        {
            Stream s;

            try
            {
                s = File.Open(file, FileMode.Open);
            }
            catch (Exception e)
            {
                throw new Exception("Passou na funcao (CarregaStock) " + "-" + e.Message);
            }


            BinaryFormatter b = new BinaryFormatter();

            listaProdutos = (List<Produto>)b.Deserialize(s);

            Produto.TotProd = Produto.AtribuirId();

            s.Close();
            return true;
        }



        #endregion

        #endregion

    }
}