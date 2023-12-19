/*
*	<copyright file="InOut.cs" company="IPCA">
*	Copyright (c) 2023 All Rights Reserved
*	</copyright>
* 	<author>Fábio Lopes</author>
*   <date>12/12/2023</date>
*	<description></description>
*/

using ObjetosNegocio;
using RN;
using System;
using System.Collections.Generic;

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

        #region MetodosListar


        public static void ListaCategorias()
        {
            List<Categoria> categorias = RegrasNegocio.ListaCategorias();

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
            List<Marca> marcas = RegrasNegocio.ListaMarcas();

            Console.WriteLine("--------Lista Marcas----------");
            foreach (Marca m in marcas)
            {
                Console.WriteLine("Id: {0},Nome: {1}, Morada: {2}", m.Id, m.Nome, m.Morada);
            }
            Console.WriteLine("----------------------------------");
            Console.ReadKey();
        }


        public static void ListaFornecedores()
        {
            List<Fornecedor> fornecedores = RegrasNegocio.ListaFornecedores();

            Console.WriteLine("--------Lista Fornecedores----------");
            foreach (Fornecedor f in fornecedores)
            {
                Console.WriteLine("Id: {0}, Nome: {1}, Morada: {2}, NIF: {3}, Telemovel: {4}", f.Id, f.Nome, f.Morada, f.NIF, f.Telemovel);
            }
            Console.WriteLine("----------------------------------");
            Console.ReadKey();
        }




        public static void ListaClientes()
        {
            List<Cliente> clientes = RegrasNegocio.ListaClientes();

            Console.WriteLine("--------Lista Clientes----------");
            foreach (Cliente c in clientes)
            {
                Console.WriteLine("Id: {0}, Nome: {1}, Morada: {2}, NIF: {3}, Telemovel: {4}", c.Id, c.Nome, c.Morada, c.NIF, c.Telemovel);
            }
            Console.WriteLine("----------------------------------");
            Console.ReadKey();
        }




        public static void ListaProdutos()
        {
            List<Produto> stock = RegrasNegocio.ListaProdutos();

            Console.WriteLine("--------Lista Produtos----------");
            foreach (Produto p in stock)
            {
                Console.WriteLine("Id: {0}, Nome: {1}, Valor: {2}, Categoria: {3}, Garantia: {4}, Quantidade: {5}", p.Id, p.Nome, p.Valor, p.CatgId, p.GarantiaAnos, p.Quantidade);
            }
            Console.WriteLine("----------------------------------");
            Console.ReadKey();
        }

        #endregion

        #region MetodosMostrarMenus

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
            Console.WriteLine("- 10 - Listar Produtos                      -");
            Console.WriteLine("- 11 - Criar compra                         -");
            Console.WriteLine("- 12 - Criar Venda                          -");
            Console.WriteLine("------------------Menu Testes----------------");

        }


        public static void MenuCompras()
        {
            Console.WriteLine("------------------Menu Compras----------------");
            Console.WriteLine("- 0 - Sair                                  -");
            Console.WriteLine("- 1 - Adicionar Produto a compra            -");
            Console.WriteLine("- 2 - Remover Produto da compra             -");
            Console.WriteLine("- 3 - Registar Compra                       -");
            Console.WriteLine("------------------Menu Compras----------------");
        }


        public static void MenuVendas()
        {
            Console.WriteLine("------------------Menu Vendas----------------");
            Console.WriteLine("- 0 - Sair                                  -");
            Console.WriteLine("- 1 - Adicionar Produto a Venda             -");
            Console.WriteLine("- 2 - Remover Produto da venda              -");
            Console.WriteLine("- 2 - Registar Venda                        -");
            Console.WriteLine("------------------Menu Vendas----------------");
        }
        #endregion

        #region LerOpçoesMenus

        public static int LernumeroMenuPrincipal()
        {
            int num = -1;
            do
            {
                Console.WriteLine("Digite um número: ");

                string input = Console.ReadLine();


                if (int.TryParse(input, out int numero))
                {
                    num = numero;
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Por favor, digite um número inteiro válido.");
                }
            } while (num < 0 || num > 12);
            return num;
        }


        public static int LernumeroMenuCompra()
        {
            int num = -1;
            do
            {
                Console.WriteLine("Digite um número: ");

                string input = Console.ReadLine();


                if (int.TryParse(input, out int numero))
                {
                    num = numero;
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Por favor, digite um número inteiro válido.");
                }
            } while (num < 0 || num > 3);
            return num;
        }

        #endregion

        #region MetodosConsola

        public static void ClearConsole()
        {
            Console.Clear();
        }

        public static void EscreverMensagem(string mensagem)
        {
            Console.WriteLine(mensagem);
        }

        #endregion

        #region MetodosAuxliaresLeitura



        static string LerString()
        {
            return Console.ReadLine();
        }




        
        static int LerInt()
        {
            
            while (true)
            {
                
                if (int.TryParse(Console.ReadLine(), out int resultado))
                {
                    return resultado; 
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Por favor, digite um número inteiro válido: ");
                }
            }
        }



        
        static float LerFloat()
        {
            
            while (true)
            {
                
                if (float.TryParse(Console.ReadLine(), out float resultado))
                {
                    return resultado; 
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Por favor, digite um número de ponto flutuante válido: ");
                }
            }
        }

        #endregion

        #region MetodosLerDadosClasses


        public static Categoria DadosCategoria()
        {
            Console.WriteLine("-------Criar Categoria--------");
            Console.WriteLine("Indique um nome para a categoria: ");
            string nomeCat = LerString();
            Categoria cat = new Categoria(nomeCat);

            return cat;
        }

        public static Marca DadosMarca()
        {

            Console.WriteLine("-------Criar Marca--------");
            Console.WriteLine("Indique um nome para a Marca: ");
            string nomeMar = LerString();
            Console.WriteLine("Indique uma Morada para a Marca: ");
            string MarMorada = LerString();

            Marca mar = new Marca(MarMorada, nomeMar);

            return mar;
        }


        public static Fornecedor DadosFornecedor()
        {
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

            return forn;
        }


        public static Cliente DadosCliente()
        {
            Console.WriteLine("-------Criar Cliente--------");
            Console.WriteLine("Indique um nome para o Cliente: ");
            string cliNome = LerString();
            Console.WriteLine("Indique uma morada para o Cliente: ");
            string cliMorada = LerString();
            Console.WriteLine("Indique um NIF para o Cliente: ");
            int cliNIF = LerInt();
            Console.WriteLine("Indique um telemovel para o Cliente: ");
            int clinTel = LerInt();

            Cliente cli = new Cliente(cliNome, cliMorada, cliNIF, clinTel);

            return cli;
        }


        public static Produto DadosProduto()
        {
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

            Produto produtocriar = new Produto(proNome, valorProduto, anosGarantia, catProdId, marcaProdId);

            return produtocriar;
        }



        public static Compra DadosCriarCompra()
        {
            Console.WriteLine("Criar compra nova");
            Console.WriteLine("Indique o ID do fornecedor");
            int IDF = LerInt();

            Compra comp = new Compra(DateTime.Now, IDF);

            return comp;
        }


        public static int DadosAdicionarProdutosCompra(out int quantProd)
        {
            Console.WriteLine("Escolha um produto identificando o seu id: ");
            int idProd = -1;
            do
            {
                idProd = LerInt();
            } while (!Produto.ExisteProdutoPorId(idProd));
            Console.WriteLine("Indique a quantidade: ");
            int aux = -1;
            do
            {
                aux = LerInt();
            } while (aux <= 0);

            quantProd = aux;

            return idProd;

        }


        public static int DadosRemoverProdutosCompra(out int quantProd, Compra comp)
        {
            Console.WriteLine("Escolha um produto identificando o seu id: ");
            int idProd = -1;
            do
            {
                idProd = LerInt();
            } while (!comp.VerificaProdutoCompra(idProd));

            Console.WriteLine("Indique a quantidade a remover");
            int aux = -1;
            do
            {
                aux = LerInt();
            } while (aux <= 0);

            quantProd = aux;

            return idProd;

        }


        public static Venda DadosCriarVenda()
        {

            Console.WriteLine("Criar venda nova");
            Console.WriteLine("Indique o ID do Cliente");
            int IDC = LerInt();

            Venda vend = new Venda(DateTime.Now, IDC);

            return vend;
        }


        public static int DadosAdicionarProdutosVenda(out int quantProd)
        {

            Console.WriteLine("Escolha um produto identificando o seu id: ");
            int idProd = -1;
            do
            {
                idProd = LerInt();
            } while (!Produto.ExisteProdutoPorId(idProd));
            Console.WriteLine("Indique a quantidade: ");
            int aux = -1;
            do
            {
                aux = LerInt();
            } while (aux <= 0);

            quantProd = aux;

            return idProd;
        }


        public static int DadosRemoverProdutosVenda(out int quantProd, Venda vend)
        {

            Console.WriteLine("Escolha um produto identificando o seu id: ");
            int idProd = -1;
            do
            {
                idProd = LerInt();
            } while (!vend.VerificaProdutoVenda(idProd));
            
            Console.WriteLine("Indique a quantidade a remover");
            int aux = -1;
            do
            {
                aux = LerInt();
            } while (aux <= 0);

            quantProd = aux;

            return idProd;
        }

        #endregion

    }
}