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
    public interface IVenda
    {




        IVenda();


        IVenda(DateTime data, int idCliente);


        bool AdicionarProdutoVenda(int produtoId, int quantidade);



        bool RemoverProdutoVenda(int produtoId, int quantidade);



        bool VerificaIntegridadeVenda();



        bool VerificaProdutoVenda(int idProduto);


    }
}