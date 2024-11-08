﻿/*
*	<copyright file="Dados.cs" company="IPCA">
*	Copyright (c) 2023 All Rights Reserved
*	</copyright>
* 	<author>Fábio Lopes & Ruben Costa</author>
*   <date>13/12/2023</date>
*	<description></description>
*/

using Excecoes;
using ObjetosNegocio;
using System;
using System.Collections.Generic;
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
        /// <exception cref="StockExcecoes"></exception>
        public static bool AdicionarProduto(Produto p)
        {
            if (ReferenceEquals(p,null) || listaProdutos.Count >= CAPACIDADEMAX)
                throw new StockExcecoes("Falha de Stock (Capacidade do Armazem excedida)");

            if(!p.VerificaIntegridadeProduto())
                throw new StockExcecoes("Falha de Stock (Produto com atributos em falta)");

            if (listaProdutos.Contains(p))
                throw new StockExcecoes("Falha de Stock (Produto ja existente no armazem)");

            listaProdutos.Add(p);
            return true;
        }


        
        //  Nao implementar (Nao remover produtos para nao perder referencias de Compras/Vendas antigas)
        /// <summary>
        /// Metodo para remover um produto do Stock
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="StockExcecoes"></exception>
        public static bool RemoverProduto(int id)
        {
            Produto p = ProdutoPorId(id);

            if (ReferenceEquals(p,null)) 
                return false;

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
        /// Metodo para dar saida de uma determinada quantidade de um produto do Stock
        /// </summary>
        /// <param name="produtoId"></param>
        /// <param name="quantidade"></param>
        /// <returns></returns>
        /// <exception cref="StockExcecoes"></exception>
        public static bool RetirarQuantidade(int produtoId, float quantidade)
        {
            if (produtoId < 1 || !ExisteProdutoPorId(produtoId)) 
                return false;

            Produto p = ProdutoPorId(produtoId);

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
            if (produtoId < 1 || !ExisteProdutoPorId(produtoId))
                return false;

            Produto p = ProdutoPorId(produtoId);


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
            if (produtoId < 1 || !ExisteProdutoPorId(produtoId))
                return false;

            Produto aux = null;

            aux = listaProdutos.Find(e => e.Id == produtoId);

            if (ReferenceEquals(aux, null))
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

                produtoChave = ProdutoPorId(chave);

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
        /// Metodo para guardar os dados da lista de Produtos num ficheiro binario
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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
        /// Metodo para carregar dados de um ficheiro binario para a lista de Produtos
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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



        /// <summary>
        /// Metodo para encontrar o produto a qual sera alterado o nome
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nome"></param>
        /// <returns></returns>
        public static bool AlterarNomeProduto(int id, string nome)
        {
            if(!ExisteProdutoPorId(id))
                return false;

            Produto p = ProdutoPorId(id);

            if(ReferenceEquals(p, null)) 
                return false;

            bool aux = p.AlterarNome(nome);

            return aux;
        }


        /// <summary>
        /// Metodo para encontrar o produto a qual sera alterado o valor 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="valor"></param>
        /// <returns></returns>
        public static bool AlterarValorProduto(int id, float valor)
        {
            if (!ExisteProdutoPorId(id))
                return false;

            Produto p = ProdutoPorId(id);

            if (ReferenceEquals(p, null))
                return false;

            bool aux = p.AlterarValor(valor);

            return aux;
        }

        /// <summary>
        /// Metodo para encontrar o produto a qual sera alterado a garantia
        /// </summary>
        /// <param name="id"></param>
        /// <param name="garantia"></param>
        /// <returns></returns>
        public static bool AlterarGarantiaProduto(int id, float garantia)
        {
            if (!ExisteProdutoPorId(id))
                return false;

            Produto p = ProdutoPorId(id);

            if (ReferenceEquals(p, null))
                return false;

            bool aux = p.AlterarGarantia(garantia);

            return aux;
        }


        /// <summary>
        /// Metodo para encontrar o produto a qual sera alterada a categoria 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="categoria"></param>
        /// <returns></returns>
        public static bool AlterarCategoriaProduto(int id, int categoria)
        {
            if (!ExisteProdutoPorId(id))
                return false;

            Produto p = ProdutoPorId(id);

            if (ReferenceEquals(p,null))
                return false;

            bool aux = p.AlterarCategoria(categoria);

            return aux;
        }

        /// <summary>
        /// Metodo para encontrar o produto a qual sera alterada a marca
        /// </summary>
        /// <param name="id"></param>
        /// <param name="marca"></param>
        /// <returns></returns>
        public static bool AlterarMarcaProduto(int id, int marca)
        {
            if (!ExisteProdutoPorId(id))
                return false;

            Produto p = ProdutoPorId(id);

            if (ReferenceEquals(p, null))
                return false;

            bool aux = p.AlterarMarca(marca);

            return aux;
        }


        /// <summary>
        /// Metodo para verificar se o produto existe no Stock
        /// </summary>
        /// <param name="produtoId"></param>
        /// <returns></returns>
        public static bool ExisteProdutoPorId(int produtoId)
        {


            if (produtoId < 0 || listaProdutos.Count < 1)
                return false;

            Produto aux = null;

            aux = listaProdutos.Find(e => e.Id == produtoId);

            if (ReferenceEquals(aux, null))
                return false;

            return true;
        }



        /// <summary>
        /// Metodo que retorna o produto referente ao id recebido
        /// </summary>
        /// <param name="produtoId"></param>
        /// <returns></returns>
        public static Produto ProdutoPorId(int produtoId)
        {
            if (!ExisteProdutoPorId(produtoId))
                return null;
            

            Produto aux = null;

            aux = listaProdutos.Find(e => e.Id == produtoId);

            if (ReferenceEquals(aux, null))
                return null;

            return aux;
        }


        /// <summary>
        /// Metodo para limpar a lista de Produtos
        /// </summary>
        public static void LimparLista()
        {
            listaProdutos = new List<Produto>();
            Produto.TotProd = 1;
        }


        #endregion

        #endregion

    }
}