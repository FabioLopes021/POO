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
using InOut;
using System.Runtime.InteropServices;

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
                menu = LernumeroMenuPrincipal();
                switch (menu)
                {

                    case 0:
                        break;
                    case 1:
                        
                        Console.WriteLine("-------Criar Categoria--------");
                        Console.WriteLine("Indique um nome para a categoria: ");
                        string nomeCat = LerString();
                        Categoria cat = new Categoria(nomeCat);
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
                        IO.ListaCategorias();
                        break;
                    case 6:
                        IO.ListaMarcas();
                        break;
                    case 7:
                        IO.ListaFornecedores();
                        break;
                    case 8:
                        IO.ListaClientes();
                        break;
                    case 9:
                        IO.ListaProdutos();
                        break;
                    case 10:     // Menu Compras 
                        int auxMenuc = -1;
                        Compra compaux = new Compra();
                        do
                        {
                            MenuCompras();
                            auxMenuc = LernumeroMenuCompra();
                            Compra comp;
                            Produto pda, pdr;
                            switch (auxMenuc)
                            {
                                case 0:
                                    break;
                                case 1:
                                    Console.WriteLine("Criar compra nova");
                                    Console.WriteLine("Indique o nome da loja");
                                    string nomeL = LerString();
                                    Console.WriteLine("Indique o ID do fornecedor");
                                    int IDF = LerInt();
                                    comp = new Compra(nomeL, DateTime.Now, IDF);
                                    compaux = comp;
                                    break;
                                case 2:
                                    Console.WriteLine("Criar o Produto desejado");
                                    Console.WriteLine("Indique o nome do Produto: ");
                                    string nomepr = LerString();
                                    Console.WriteLine("Indique o valor do produto: ");
                                    float valorPr = LerFloat();
                                    Console.WriteLine("Indique a garantia em anos");
                                    float garantiaPr = LerFloat();
                                    Console.WriteLine("Indique o id da categoria");
                                    int idCat = LerInt();
                                    Console.WriteLine("Indique o id da Marca");
                                    int idMarca = LerInt();
                                    pda = new Produto(nomepr, valorPr, garantiaPr, idCat, idMarca, 0);
                                    Console.WriteLine("Indique a quantidade comprada");
                                    int quantcomp = LerInt();
                                    comp = compaux;
                                    comp.AdicionarProdutoCompra(pda, quantcomp);
                                    break;
                                case 3:
                                    Console.WriteLine("Indique o Produto desejado");
                                    Console.WriteLine("Indique o nome do Produto: ");
                                    string nomepr1 = LerString();
                                    Console.WriteLine("Indique o valor do produto: ");
                                    float valorPr1 = LerFloat();
                                    Console.WriteLine("Indique a garantia em anos");
                                    float garantiaPr1 = LerFloat();
                                    Console.WriteLine("Indique o id da categoria");
                                    int idCat1 = LerInt();
                                    Console.WriteLine("Indique o id da Marca");
                                    int idMarca1 = LerInt();
                                    pdr = new Produto(nomepr1, valorPr1, garantiaPr1, idCat1, idMarca1, 0);
                                    Console.WriteLine("Indique a quantidade a remover");
                                    int quantremover = LerInt();
                                    comp = compaux;
                                    comp.RemoverProdutoCompra(pdr, quantremover);
                                    break;
                                case 4:
                                    RegrasNegocio.AdicionarCompra(compaux);
                                    break;
                                default:
                                    Console.WriteLine("Default, algo errou!!!");
                                    break;
                            }
                        } while (auxMenuc != 0);
                        break;
                    case 11:    // Menu Vendas
                        int auxMenuV = -1;
                        Venda vendAux = new Venda();
                        do
                        {
                            MenuCompras();
                            auxMenuV = LernumeroMenuCompra();
                            Venda vend;
                            Produto pda, pdr;
                            switch (auxMenuV)
                            {
                                case 0:
                                    break;
                                case 1:
                                    Console.WriteLine("Criar compra nova");
                                    Console.WriteLine("Indique o nome da loja");
                                    string nomeL = LerString();
                                    Console.WriteLine("Indique o ID do fornecedor");
                                    int IDF = LerInt();
                                    vend = new Venda(nomeL, DateTime.Now, IDF);
                                    vendAux = vend;
                                    break;
                                case 2:
                                    Console.WriteLine("Criar o Produto desejado");
                                    Console.WriteLine("Indique o nome do Produto: ");
                                    string nomepr = LerString();
                                    Console.WriteLine("Indique o valor do produto: ");
                                    float valorPr = LerFloat();
                                    Console.WriteLine("Indique a garantia em anos");
                                    float garantiaPr = LerFloat();
                                    Console.WriteLine("Indique o id da categoria");
                                    int idCat = LerInt();
                                    Console.WriteLine("Indique o id da Marca");
                                    int idMarca = LerInt();
                                    pda = new Produto(nomepr, valorPr, garantiaPr, idCat, idMarca, 0);
                                    Console.WriteLine("Indique a quantidade comprada");
                                    int quantcomp = LerInt();
                                    vend = vendAux;
                                    vend.AdicionarProdutoVenda(pda, quantcomp);
                                    break;
                                case 3:
                                    Console.WriteLine("Indique o Produto desejado");
                                    Console.WriteLine("Indique o nome do Produto: ");
                                    string nomepr1 = LerString();
                                    Console.WriteLine("Indique o valor do produto: ");
                                    float valorPr1 = LerFloat();
                                    Console.WriteLine("Indique a garantia em anos");
                                    float garantiaPr1 = LerFloat();
                                    Console.WriteLine("Indique o id da categoria");
                                    int idCat1 = LerInt();
                                    Console.WriteLine("Indique o id da Marca");
                                    int idMarca1 = LerInt();
                                    pdr = new Produto(nomepr1, valorPr1, garantiaPr1, idCat1, idMarca1, 0);
                                    Console.WriteLine("Indique a quantidade a remover");
                                    int quantremover = LerInt();
                                    vend = vendAux;
                                    vend.RemoverProdutoVenda(pdr, quantremover);
                                    break;
                                case 4:
                                    RegrasNegocio.AdicionarVenda(vendAux);
                                    break;
                                default:
                                    Console.WriteLine("Default, algo errou!!!");
                                    break;
                            }
                        } while (auxMenuV != 0);
                        break;
                    default:
                        Console.WriteLine("Default, algo errou!!!");
                        break;
                }

            } while (menu != 0);

            return 0;
        }


        public static int LernumeroMenuPrincipal()
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
            } while (num < 0 || num> 11);
            return num;
        }


        public static int LernumeroMenuCompra()
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
            } while (num < 0 || num > 4);
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
            Console.WriteLine("- 9 - Listar Produtos                       -");
            Console.WriteLine("- 10 - Menu compras                          -");
            Console.WriteLine("- 11 - Menu Vendas                           -");
            Console.WriteLine("------------------Menu Testes----------------");
            
        }


        public static void MenuCompras()
        {
            Console.WriteLine("------------------Menu Compras----------------");
            Console.WriteLine("- 0 - Sair                                  -");
            Console.WriteLine("- 1 - Criar Compra                          -");
            Console.WriteLine("- 2 - Adicionar Produto                     -");
            Console.WriteLine("- 3 - Remover Produto                       -");
            Console.WriteLine("- 4 - Registar Compra                       -");
            Console.WriteLine("------------------Menu Compras----------------");
        }


        public static void MenuVendas()
        {
            Console.WriteLine("------------------Menu Vendas----------------");
            Console.WriteLine("- 0 - Sair                                  -");
            Console.WriteLine("- 1 - Criar Venda                           -");
            Console.WriteLine("- 2 - Adicionar Produto                     -");
            Console.WriteLine("- 3 - Remover Produto                       -");
            Console.WriteLine("- 4 - Registar Venda                        -");
            Console.WriteLine("------------------Menu Vendas----------------");
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

        // Método para ler e retornar um número de ponto flutuante
        static float LerFloat()
        {
            // Loop até que o usuário insira um número válido
            while (true)
            {
                // Tenta converter a entrada para um número de ponto flutuante
                if (float.TryParse(Console.ReadLine(), out float resultado))
                {
                    return resultado; // Retorna o número de ponto flutuante se a conversão for bem-sucedida
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Por favor, digite um número de ponto flutuante válido: ");
                }
            }
        }

        #endregion

        #endregion

    }
}