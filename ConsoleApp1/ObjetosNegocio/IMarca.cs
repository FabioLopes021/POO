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
    public interface IMarca
    {


        /// <summary>
        /// Propriedade para aceder a variavel morada
        /// </summary>
        string Morada
        {
            get;
            set;
        }


        /// <summary>
        /// Propriedade para aceder a variavel nome
        /// </summary>
        string Nome
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

    }
}