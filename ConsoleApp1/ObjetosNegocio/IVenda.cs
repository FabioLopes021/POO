﻿/*
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
    public interface IVenda
    {

        /// <summary>
        /// Propriedade para aceder a variavel artigosVendidos
        /// </summary>
        Dictionary<int, int> ArtigosVendidos
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
        /// Propriedade para aceder a variavel idCliente
        /// </summary>
        int IdCliente
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



        bool AdicionarProdutoVenda(int produtoId, int quantidade);



        bool RemoverProdutoVenda(int produtoId, int quantidade);



        bool VerificaIntegridadeVenda();



        bool VerificaProdutoVenda(int idProduto);


    }
}