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
                Console.Clear();
                MenuShow();
                menu = LernumeroMenuPrincipal();
                switch (menu)
                {

                    case 0:
                        break;
                    case 1:
                        Console.Clear();
                        Console.WriteLine("-------Criar Categoria--------");
                        Console.WriteLine("Indique um nome para a categoria: ");
                        string nomeCat = LerString();
                        Categoria cat = new Categoria(nomeCat);
                        RegrasNegocio.AdicionarCategoria(cat);
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("-------Criar Marca--------");
                        Console.WriteLine("Indique um nome para a Marca: ");
                        string nomeMar = LerString();
                        Console.WriteLine("Indique uma Morada para a Marca: ");
                        string MarMorada = LerString();

                        Marca mar = new Marca(MarMorada, nomeMar);

                        RegrasNegocio.AdicionarMarca(mar);

                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("-------Criar Fornecedor--------");
                        Console.WriteLine("Indique um nome para o Fornecedor: ");
                        string fornNome = LerString();
                        Console.WriteLine("Indique uma morada para o Fornecedor: ");
                        string fornMorada = LerString();
                        Console.WriteLine("Indique um NIF para o Fornecedor: ");
                        int fornNIF = LerInt();
                        Console.WriteLine("Indique um telemovel para o Fornecedor: ");
                        int fornTel = LerInt();

                        Fornecedor forn = new Fornecedor(fornNome, fornMorada, fornNIF, fornTel);

                        RegrasNegocio.AdicionarFornecedor(forn);
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("-------Criar Cliente--------");
                        Console.WriteLine("Indique um nome para o Cliente: ");
                        string cliNome = LerString();
                        Console.WriteLine("Indique uma morada para o Cliente: ");
                        string cliMorada = LerString();
                        Console.WriteLine("Indique um NIF para o Cliente: ");
                        int cliNIF = LerInt();
                        Console.WriteLine("Indique um telemovel para o Cliente: ");
                        int clinTel = LerInt();

                        Cliente cli = new Cliente( cliNome, cliMorada, cliNIF, clinTel);

                        RegrasNegocio.AdicionarCliente(cli);
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("-------Criar Produto--------");
                        Console.WriteLine("Indique um nome para o Produto: ");
                        string proNome = LerString();
                        Console.WriteLine("Indique um Valor para o Produto: ");
                        float valorProduto = LerFloat();
                        Console.WriteLine("Indique os anos de garantia para o Produto: ");
                        float anosGarantia = LerFloat();
                        IO.ListaCategorias();
                        Console.WriteLine("Indique o Id da categoria para o produto: ");
                        int catProdId = LerInt();
                        IO.ListaMarcas();
                        Console.WriteLine("Indique o id da marca para o produto: ");
                        int marcaProdId = LerInt();

                        Produto produtocriar = new Produto(proNome,valorProduto,anosGarantia,catProdId,marcaProdId);

                        RegrasNegocio.AdicionarProduto(produtocriar);
                        break;
                    case 6:
                        Console.Clear();
                        IO.ListaCategorias();
                        break;
                    case 7:
                        Console.Clear();
                        IO.ListaMarcas();
                        break;
                    case 8:
                        Console.Clear();
                        IO.ListaFornecedores();
                        break;
                    case 9:
                        Console.Clear();
                        IO.ListaClientes();
                        break;
                    case 10:
                        Console.Clear();
                        IO.ListaProdutos();
                        break;
                    case 11:     // Menu Compras 
                        int auxMenuc = -1;
                        Compra compaux = new Compra();
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("-------------Informaçoes compra--------------");
                            compaux.MostraListaCompras();
                            Console.WriteLine("-------------Informaçoes compra--------------");
                            MenuCompras();
                            Compra comp;
                            auxMenuc = LernumeroMenuCompra();
                            switch (auxMenuc)
                            {
                                case 0:
                                    break;
                                case 1:     //Criar Compra
                                    Console.Clear();
                                    Console.WriteLine("Criar compra nova");
                                    Console.WriteLine("Indique o nome da loja");
                                    string nomeL = LerString();
                                    Console.WriteLine("Indique o ID do fornecedor");
                                    int IDF = LerInt();
                                    comp = new Compra(nomeL, DateTime.Now, IDF);
                                    compaux = comp;
                                    break;
                                case 2:     //Adicionar Produto a compra
                                    Console.Clear();
                                    IO.ListaProdutos();
                                    Console.WriteLine("Escolha um produto identificando o seu id: ");
                                    int idProd = -1;
                                    do
                                    {
                                        idProd = LerInt();
                                    } while (!Produto.ExisteProdutoPorId(idProd));
                                    comp = compaux;
                                    Console.WriteLine("Indique a quantidade: ");
                                    int quantProd = -1;
                                    do
                                    {
                                        quantProd = LerInt();
                                    } while (quantProd <= 0);
                                    comp = compaux;
                                    comp.AdicionarProdutoCompra(idProd, quantProd);
                                    break;
                                case 3:     //Remover produto da compra
                                    Console.Clear();
                                    comp = compaux;
                                    if (!(comp.ArtigosComprados.Count < 1))
                                    {
                                        comp.MostraListaCompras();
                                        Console.WriteLine("Escolha um produto identificando o seu id: ");
                                        idProd = -1;
                                        do
                                        {
                                            idProd = LerInt();
                                        } while (!comp.VerificaProdutoCompra(idProd));
                                        comp = compaux;
                                        Console.WriteLine("Indique a quantidade a remover");
                                        quantProd = -1;
                                        do
                                        {
                                            quantProd = LerInt();
                                        } while (quantProd <= 0);
                                        comp.RemoverProdutoCompra(idProd, quantProd);
                                    }else
                                        Console.WriteLine("Nao exitem produtos adicionados a compra");
                                    break;
                                case 4:     // Registar Compra
                                    bool comprabool = RegrasNegocio.AdicionarCompra(compaux);
                                    Console.WriteLine("Inserido com {0}", comprabool.ToString());
                                    Console.ReadKey();
                                    break;
                                default:
                                    Console.WriteLine("Default, algo errou!!!");
                                    break;
                            }
                        } while (auxMenuc != 0);
                        break;
                    case 12:    // Menu Vendas
                        int auxMenuV = -1;
                        Venda vendAux = new Venda();
                        do
                        {
                            Console.Clear();
                            MenuVendas();
                            auxMenuV = LernumeroMenuCompra();
                            Venda vend;
                            switch (auxMenuV)
                            {
                                case 0:
                                    break;
                                case 1:
                                    Console.WriteLine("Criar compra nova");
                                    Console.WriteLine("Indique o nome da loja");
                                    string nomeL = LerString();
                                    Console.WriteLine("Indique o ID do Cliente");
                                    int IDC = LerInt();
                                    vend = new Venda(nomeL, DateTime.Now, IDC);
                                    vendAux = vend;
                                    break;
                                case 2:
                                    Console.Clear();
                                    IO.ListaProdutos();
                                    Console.WriteLine("Escolha um produto identificando o seu id: ");
                                    int idProd = -1;
                                    do
                                    {
                                        idProd = LerInt();
                                    } while (!Produto.ExisteProdutoPorId(idProd));
                                    Console.WriteLine("Indique a quantidade: ");
                                    int quantProd = -1;
                                    do
                                    {
                                        quantProd = LerInt();
                                    } while (quantProd <= 0);
                                    vend = vendAux;
                                    vend.AdicionarProdutoVenda(idProd, quantProd);
                                    break;
                                case 3:
                                    Console.Clear();
                                    vend = vendAux;
                                    if (!(vend.ArtigosVendidos.Count < 1))
                                    {
                                        vend.MostraListaCompras();
                                        Console.WriteLine("Escolha um produto identificando o seu id: ");
                                        idProd = -1;
                                        do
                                        {
                                            idProd = LerInt();
                                        } while (!vend.VerificaProdutoVenda(idProd));
                                        vend = vendAux;
                                        Console.WriteLine("Indique a quantidade a remover");
                                        quantProd = -1;
                                        do
                                        {
                                            quantProd = LerInt();
                                        } while (quantProd <= 0);
                                        vend.RemoverProdutoVenda(idProd, quantProd);
                                    }
                                    else
                                        Console.WriteLine("Nao exitem produtos adicionados a compra");
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
            } while (num < 0 || num> 12);
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
            Console.WriteLine("- 5 - Adicionar Produto                     -");
            Console.WriteLine("- 6 - Listar Categorias                     -");
            Console.WriteLine("- 7 - Listar Marcas                         -");
            Console.WriteLine("- 8 - Listar Fornecedores                   -");
            Console.WriteLine("- 9 - Listar Clientes                       -");
            Console.WriteLine("- 10 - Listar Produtos                       -");
            Console.WriteLine("- 11 - Menu compras                          -");
            Console.WriteLine("- 12 - Menu Vendas                           -");
            Console.WriteLine("------------------Menu Testes----------------");
            
        }


        public static void MenuCompras()
        {
            Console.WriteLine("------------------Menu Compras----------------");
            Console.WriteLine("- 0 - Sair                                  -");
            Console.WriteLine("- 1 - Criar Compra                          -");
            Console.WriteLine("- 2 - Adicionar Produto a compra            -");
            Console.WriteLine("- 3 - Remover Produto da compra             -");
            Console.WriteLine("- 4 - Registar Compra                       -");
            Console.WriteLine("------------------Menu Compras----------------");
        }


        public static void MenuVendas()
        {
            Console.WriteLine("------------------Menu Vendas----------------");
            Console.WriteLine("- 0 - Sair                                  -");
            Console.WriteLine("- 1 - Criar Venda                           -");
            Console.WriteLine("- 2 - Adicionar Produto a Venda             -");
            Console.WriteLine("- 3 - Remover Produto da venda              -");
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
            // Loop até que o utilizador insira um número válido
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
            // Loop até que o utilizador insira um número válido
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