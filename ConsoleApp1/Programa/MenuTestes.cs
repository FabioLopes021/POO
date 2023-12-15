/*
*	<copyright file="Programa.cs" company="IPCA">
*	Copyright (c) 2023 All Rights Reserved
*	</copyright>
* 	<author>Fábio Lopes</author>
*   <date>12/12/2023</date>
*	<description></description>
*/

using System;
using Dados;
using ObjetosNegocio;
using RN;

namespace Programa
{
    /// <summary>
    /// Purpose: 
    /// Created by: Fábio Lopes
    /// Created on: 12/12/2023
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class MenuTestes
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

        public static int MenuRunner()
        {
            int menu;
            do
            {
                MenuShow();
                menu = Lernumero();
                switch (menu)
                {

                    case 0:
                        break;
                    case 1:
                        
                        Console.WriteLine("-------Criar Categoria--------");
                        Console.WriteLine("Indique um nome para a categoria: ");
                        string nomeCat = LerString();
                        Categoria cat = new Categoria();
                        RegrasNegocio.AdicionarCategoria(cat);
                        break;
                    case 2:
                        Console.WriteLine("-------Criar Marca--------");
                        Console.WriteLine("Indique um nome para a Marca: ");
                        string nomeMar = LerString();
                        Console.WriteLine("Indique uma Morada para a Marca: ");
                        string MarMorada = LerString();

                        Marca mar = new Marca(MarMorada, nomeMar);

                        RegrasNegocio.AdicionarMarca(mar);

                        break;
                    case 3:
                        Console.WriteLine("-------Criar Fornecedor--------");
                        Console.WriteLine("Indique um nome para o Fornecedor: ");
                        string fornNome = LerString();
                        Console.WriteLine("Infique uma morada para o Fornecedor: ");
                        string fornMorada = LerString();
                        Console.WriteLine("Infique um NIF para o Fornecedor: ");
                        int fornNIF = LerInt();
                        Console.WriteLine("Infique um telemovel para o Fornecedor: ");
                        int fornTel = LerInt();

                        Fornecedor forn = new Fornecedor(fornNome, fornMorada, fornNIF, fornTel);

                        RegrasNegocio.AdicionarFornecedor(forn);
                        break;
                    case 4:
                        Console.WriteLine("-------Criar Cliente--------");
                        Console.WriteLine("Indique um nome para o Cliente: ");
                        string cliNome = LerString();
                        Console.WriteLine("Infique uma morada para o Cliente: ");
                        string cliMorada = LerString();
                        Console.WriteLine("Infique um NIF para o Cliente: ");
                        int cliNIF = LerInt();
                        Console.WriteLine("Infique um telemovel para o Cliente: ");
                        int clinTel = LerInt();

                        Cliente cli = new Cliente( cliNome, cliMorada, cliNIF, clinTel);

                        RegrasNegocio.AdicionarCliente(cli);
                        break;
                    case 5:

                        break;
                    case 6:

                        break;
                    case 7:

                        break;
                    case 8:

                        break;
                    default:
                        Console.WriteLine("Default, algo errou!!!");
                        break;
                }

            } while (menu != 0);

            return 0;
        }


        public static int Lernumero()
        {
            int num = -1;
            do
            {
                Console.WriteLine("Digite um número: ");
                // Lê a entrada do usuário como uma string
                string input = Console.ReadLine();

                // Tenta converter a string para um número
                if (int.TryParse(input, out int numero))
                {
                    num = numero;
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Por favor, digite um número inteiro válido.");
                }
            } while (num < 0 || num> 8);
            return num;
        }

        public static void MenuShow()
        {

            Console.WriteLine("------------------Menu Testes----------------");
            Console.WriteLine("- 0 - Sair                                  -");
            Console.WriteLine("- 1 - Adicionar Categoria                   -");
            Console.WriteLine("- 2 - Adicionar Marca                       -");
            Console.WriteLine("- 3 - Adicionar Fornecedor                  -");
            Console.WriteLine("- 4 - Adicionar Cliente                     -");
            Console.WriteLine("- 5 - Listar Categorias                     -");
            Console.WriteLine("- 6 - Listar Marcas                         -");
            Console.WriteLine("- 7 - Listar Fornecedores                   -");
            Console.WriteLine("- 8 - Listar Clientes                       -");
            Console.WriteLine("------------------Menu Testes----------------");
            
        }


        static string LerString()
        {
            return Console.ReadLine();
        }



        // Método para ler e retornar um número inteiro
        static int LerInt()
        {
            // Loop até que o usuário insira um número válido
            while (true)
            {
                // Tenta converter a entrada para um número inteiro
                if (int.TryParse(Console.ReadLine(), out int resultado))
                {
                    return resultado; // Retorna o número inteiro se a conversão for bem-sucedida
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Por favor, digite um número inteiro válido: ");
                }
            }
        }

        #endregion

        #endregion

    }
}