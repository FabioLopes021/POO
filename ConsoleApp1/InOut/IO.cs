/*
*	<copyright file="InOut.cs" company="IPCA">
*	Copyright (c) 2023 All Rights Reserved
*	</copyright>
* 	<author>Fábio Lopes</author>
*   <date>12/12/2023</date>
*	<description></description>
*/

using ObjetosNegocio;
using Dados;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace InOut
{
    /// <summary>
    /// Purpose: 
    /// Created by: Fábio Lopes
    /// Created on: 12/12/2023
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class IO
    {
        #region Attributes
        #endregion

        #region Methods

        #region Constructors
        #endregion

        #region Properties
        #endregion

        #region Operators
        #endregion

        #region Overrides
        #endregion

        #region Other_Methods


        public static void ListaCategorias()
        {
            List<Categoria> categorias = Categorias.ListaCategorias;

            Console.WriteLine("--------Lista categorias----------");
            foreach (Categoria c in categorias)
            {
                Console.WriteLine("Id: {0},Nome: {1}", c.Id, c.Nome);
            }
            Console.WriteLine("----------------------------------");
            Console.ReadKey();
        }


        public static void ListaMarcas()
        {
            List<Marca> marcas = Marcas.ListaMarcas;

            Console.WriteLine("--------Lista categorias----------");
            foreach (Marca m in marcas)
            {
                Console.WriteLine("Id: {0},Nome: {1}, Morada: {2}", m.Id, m.Nome, m.Morada);
            }
            Console.WriteLine("----------------------------------");
            Console.ReadKey();
        }


        public static void ListaFornecedores()
        {
            List<Fornecedor> fornecedores = Fornecedores.ListaFornecedores;

            Console.WriteLine("--------Lista categorias----------");
            foreach (Fornecedor f in fornecedores)
            {
                Console.WriteLine("Id: {0}, Nome: {1}, Morada: {2}, NIF: {3}, Telemovel: {4}", f.Id, f.Nome, f.Morada, f.NIF, f.Telemovel);
            }
            Console.WriteLine("----------------------------------");
            Console.ReadKey();
        }




        public static void ListaClientes()
        {
            List<Cliente> clientes = Clientes.ListaClientes;

            Console.WriteLine("--------Lista categorias----------");
            foreach (Cliente c in clientes)
            {
                Console.WriteLine("Id: {0}, Nome: {1}, Morada: {2}, NIF: {3}, Telemovel: {4}", c.Id, c.Nome, c.Morada, c.NIF, c.Telemovel);
            }
            Console.WriteLine("----------------------------------");
            Console.ReadKey();
        }




        public static void ListaProdutos()
        {
            List<Produto> stock = Stock.ListaProdutos;

            Console.WriteLine("--------Lista categorias----------");
            foreach (Produto p in stock)
            {
                Console.WriteLine("Id: {0}, Nome: {1}, Valor: {2}, Categoria: {3}, Garantia: {4}, Quantidae: {5}", p.Id, p.Nome, p.Valor, p.CatgId, p.GarantiaAnos, p.Quantidade);
            }
            Console.WriteLine("----------------------------------");
            Console.ReadKey();
        }






        #endregion

        #endregion

    }
}