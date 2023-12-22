/*
*	<copyright file="ClassLibrary1.cs" company="IPCA">
*	Copyright (c) 2023 All Rights Reserved
*	</copyright>
* 	<author>Fábio Lopes & Ruben Costa</author>
*   <date>13/11/2023</date>
*	<description></description>
*/

using Dados;
using System.Collections.Generic;

namespace ObjetosNegocio
{
    public interface IProduto
    {

        /// <summary>
        /// Propriedade para aceder a variavel id
        /// </summary>
        int Id
        {
            set;
            get;
        }

        /// <summary>
        /// Propriedade para aceder a variavel nome
        /// </summary>
        string Nome
        {
            set;
            get;
        }

        /// <summary>
        /// Propriedade para aceder a variavel valor
        /// </summary>
        float Valor
        {
            set;
            get;
        }

        /// <summary>
        /// Propriedade para aceder a variavel garantiaAnos
        /// </summary>
        float GarantiaAnos
        {
            set;
            get;
        }

        /// <summary>
        /// Propriedade para aceder a variavel catgId
        /// </summary>
        int CatgId
        {
            set;
            get;
        }

        /// <summary>
        /// Propriedade para aceder a variavel marcaId
        /// </summary>
        int MarcaId
        {
            set;
            get;
        }


        /// <summary>
        /// Propriedade para aceder a variavel quantidade
        /// </summary>
        float Quantidade
        {
            set;
            get;
        }


        /// <summary>
        /// Funçao para verificar se o produto esta completo com os dados obrigatorios
        /// </summary>
        /// <returns></returns>
        bool VerificaIntegridadeProduto();



    }
}