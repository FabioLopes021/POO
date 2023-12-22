/*
*	<copyright file="ObjetosNegocio.cs" company="IPCA">
*	Copyright (c) 2023 All Rights Reserved
*	</copyright>
* 	<author>Fábio Lopes & Ruben Costa</author>
*   <date>13/12/2023</date>
*	<description></description>
*/

using Dados;
using System.Collections.Generic;
using System;

namespace ObjetosNegocio
{
    public interface ICompra
    {

        /// <summary>
        /// Propriedade para aceder a variavel artigosComprados
        /// </summary>
        Dictionary<int, int> ArtigosComprados
        {
            get;
        }


        /// <summary>
        /// Propriedade para aceder a variavel data
        /// </summary>
        DateTime Data
        {
            get;
            set;
        }


        /// <summary>
        /// Propriedade para aceder a variavel idFornecedor
        /// </summary>
        int IdFornecedor
        {
            get;
            set;
        }


        /// <summary>
        /// Propriedade para aceder a variavel id
        /// </summary>
        int Id
        {
            get;
        }


        /// <summary>
        /// Funçao para adicionar o id dos produtos e a respetiva qunatidade ao dicionario 
        /// </summary>
        /// <param name="produtoId"></param>
        /// <param name="quantidade"></param>
        /// <returns></returns>
        bool AdicionarProdutoCompra(int produtoId, int quantidade);


        /// <summary>
        /// Funçao para Remover o id dos produtos e a respetiva qunatidade do dicionario 
        /// </summary>
        /// <param name="produtoId"></param>
        /// <param name="quantidade"></param>
        /// <returns></returns>
        bool RemoverProdutoCompra(int produtoId, int quantidade);


        /// <summary>
        /// Funçao que verifica a integridade da Compra, se os artigos estao em stock ou precisam de ser inicializados
        /// </summary>
        /// <returns></returns>
        bool VerificaIntegridadeCompra();


        /// <summary>
        /// Funçao que verifica se um produto esta adicionado a compra
        /// </summary>
        /// <param name="idProduto"></param>
        /// <returns></returns>
        bool VerificaProdutoCompra(int idProduto);


    }
}