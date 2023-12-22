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

namespace ObjetosNegocio
{
    public interface IFornecedor
    {

        /// <summary>
        /// Propriedade para aceder a variavel nome
        /// </summary>
        string Nome
        {
            set;
            get;
        }


        /// <summary>
        /// Propriedade para aceder a variavel morada
        /// </summary>
        string Morada
        {
            set;
            get;
        }


        /// <summary>
        /// Propriedade para aceder a variavel telemovel
        /// </summary>
        int Telemovel
        {
            set;
            get;
        }


        /// <summary>
        /// Propriedade para aceder a variavel nif
        /// </summary>
        int NIF
        {
            set;
            get;
        }


        /// <summary>
        /// Propriedade para aceder a variavel id
        /// </summary>
        int Id
        {
            get;
        }



    }
}