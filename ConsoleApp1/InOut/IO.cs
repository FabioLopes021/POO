/*
*	<copyright file="InOut.cs" company="IPCA">
*	Copyright (c) 2023 All Rights Reserved
*	</copyright>
* 	<author>Fábio Lopes & Ruben Costa</author>
*   <date>12/12/2023</date>
*	<description></description>
*/

using ObjetosNegocio;
using RN;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InOut
{
    /// <summary>
    /// Purpose: 
    /// Created by: Fábio Lopes & Ruben Costa
    /// Created on: 12/12/2023
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class IO
    {

        #region MetodosListar


        /// <summary>
        /// Metodo que lista todas as categorias na lista de categorias
        /// </summary>
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



        /// <summary>
        /// Metodo que lista todas as marcas na lista marcas
        /// </summary>
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


        /// <summary>
        /// Metodo que lista todas os Fornecedores na lista Fornecedores
        /// </summary>
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



        /// <summary>
        /// Metodo que lista todos os clientes na lista clientes
        /// </summary>
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



        /// <summary>
        /// Metodo que lista todos os produtos na lista produtos
        /// </summary>
        public static void ListaProdutos()
        {
            List<Produto> stock = RegrasNegocio.ListaProdutos();

            Console.WriteLine("--------Lista Produtos----------");
            foreach (Produto p in stock)
            {
                Console.WriteLine("Id: {0}, Nome: {1}, Valor: {2}, Categoria: {3}, Marca: {4}, Garantia: {5}, Quantidade: {6}", p.Id, p.Nome, p.Valor, p.CatgId,p.MarcaId ,p.GarantiaAnos, p.Quantidade);
            }
            Console.WriteLine("----------------------------------");
            Console.ReadKey();
        }


        /// <summary>
        /// Metodo que lista todos os produtos de forma ascendente de acordo com o valor dos mesmos
        /// </summary>
        public static void ListaProdutosPrecoAsc()
        {
            List<Produto> stock = RegrasNegocio.ListaProdutos();
            List<Produto> asc;

            asc = stock.OrderBy(e => e.Valor).ToList();

            Console.WriteLine("--------Lista Produtos----------");
            foreach (Produto p in asc)
            {
                Console.WriteLine("Id: {0}, Nome: {1}, Valor: {2}, Categoria: {3}, Marca: {4}, Garantia: {5}, Quantidade: {6}", p.Id, p.Nome, p.Valor, p.CatgId, p.MarcaId, p.GarantiaAnos, p.Quantidade);
            }
            Console.WriteLine("----------------------------------");
            Console.ReadKey();
        }


        /// <summary>
        /// Metodo que lista todos os produtos de forma descendente de acordo com o valor dos mesmos
        /// </summary>
        public static void ListaProdutosPrecoDesc()
        {
            List<Produto> stock = RegrasNegocio.ListaProdutos();
            List<Produto> asc;

            asc = stock.OrderByDescending(e => e.Valor).ToList();

            Console.WriteLine("--------Lista Produtos----------");
            foreach (Produto p in asc)
            {
                Console.WriteLine("Id: {0}, Nome: {1}, Valor: {2}, Categoria: {3}, Marca: {4}, Garantia: {5}, Quantidade: {6}", p.Id, p.Nome, p.Valor, p.CatgId, p.MarcaId, p.GarantiaAnos, p.Quantidade);
            }
            Console.WriteLine("----------------------------------");
            Console.ReadKey();
        }


        /// <summary>
        /// Metodo que lista os dados de uma compra
        /// </summary>
        /// <param name="comp"></param>
        public static void MostrarDadosCompra(Compra comp)
        {
            int count = 0;
            Console.WriteLine("#############");
            Console.WriteLine("Informacoes da compra: ");
            Console.WriteLine("ID Compra: {0}, Data: {1}", comp.Id, comp.Data);
            if (comp.ArtigosComprados.Count > 0)
            {
                foreach (KeyValuePair<int, int> parchave in comp.ArtigosComprados)
                {
                    Produto p;
                    int chave = parchave.Key;
                    p = RegrasNegocio.ProdutoPorId(chave);

                    if (p != null)
                    {
                        if (count == 0)
                            Console.WriteLine("Artigos na lista de compras: ");
                        Console.WriteLine("id: {0}; Nome: {1}; Valor: {2}; Quantidade: {3}", p.Id, p.Nome, p.Valor, comp.ArtigosComprados[chave]);
                    }
                    count++;
                }
            }
            Console.WriteLine("#############");

        }

        /// <summary>
        /// Metodo que lista os dados de uma venda
        /// </summary>
        /// <param name="vend"></param>
        public static void MostrarDadosVenda(Venda vend)
        {
            int count = 0;
            Console.WriteLine("#############");
            Console.WriteLine("Informacoes da Venda: ");
            Console.WriteLine("ID Venda: {0}, Data: {1}", vend.Id, vend.Data);
            if (vend.ArtigosVendidos.Count > 0)
            {
                foreach (KeyValuePair<int, int> parchave in vend.ArtigosVendidos)
                {
                    Produto p;
                    int chave = parchave.Key;
                    p = RegrasNegocio.ProdutoPorId(chave);

                    if (p != null)
                    {
                        if (count == 0)
                            Console.WriteLine("Artigos na lista de compras: ");
                        Console.WriteLine("id: {0}; Nome: {1}; Valor: {2}; Quantidade: {3}", p.Id, p.Nome, p.Valor, vend.ArtigosVendidos[chave]);
                    }
                    count++;
                }
            }
            Console.WriteLine("#############");

        }


        /// <summary>
        /// Metodo que lista os dados de todas as vendas 
        /// </summary>
        public static void ListaVendas()
        {
            List<Venda> vendas = RegrasNegocio.ListaVendas();
            Console.WriteLine("---------------Lista Vendas-------------------------");

            foreach (Venda v in vendas)
            {
                if (!(ReferenceEquals(v, null)))
                    MostrarDadosVenda(v);
            }

            Console.WriteLine("---------------Lista Vendas-------------------------");

        }

        /// <summary>
        /// Metodo que lista os dados de todas as compras
        /// </summary>
        public static void ListaCompras()
        {
            List<Compra> compras = RegrasNegocio.ListaCompras();
            Console.WriteLine("---------------Lista Vendas-------------------------");

            foreach (Compra c in compras)
            {
                if (!(ReferenceEquals(c, null)))
                    MostrarDadosCompra(c);
            }

            Console.WriteLine("---------------Lista Vendas-------------------------");

        }


        #endregion

        #region MetodosMostrarMenus


        /// <summary>
        /// Metodo que apresenta o menu principal na consola
        /// </summary>
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
            Console.WriteLine("- 11 - Listar Produtos asc                  -");
            Console.WriteLine("- 12 - Listar Produtos desc                 -");
            Console.WriteLine("- 13 - Listar Vendas                        -");
            Console.WriteLine("- 14 - Listar Compras                       -");
            Console.WriteLine("- 15 - Criar compra                         -");
            Console.WriteLine("- 16 - Criar Venda                          -");
            Console.WriteLine("- 17 - Alterar dados produto                -");
            Console.WriteLine("- 18 - Alterar dados Marca                  -");
            Console.WriteLine("- 19 - Alterar dados Fornecedor             -");
            Console.WriteLine("- 20 - Alterar dados Clientes               -");
            Console.WriteLine("- 21 - Alterar dados Categorias             -");
            Console.WriteLine("------------------Menu Testes----------------");

        }

        /// <summary>
        /// Metodo que apresenta o menu de compras principal na consola
        /// </summary>
        public static void MenuCompras()
        {
            Console.WriteLine("------------------Menu Compras----------------");
            Console.WriteLine("- 0 - Sair                                  -");
            Console.WriteLine("- 1 - Adicionar Produto a compra            -");
            Console.WriteLine("- 2 - Remover Produto da compra             -");
            Console.WriteLine("- 3 - Registar Compra                       -");
            Console.WriteLine("------------------Menu Compras----------------");
        }


        /// <summary>
        /// Metodo que apresenta o menu de vendas na consola
        /// </summary>
        public static void MenuVendas()
        {
            Console.WriteLine("------------------Menu Vendas----------------");
            Console.WriteLine("- 0 - Sair                                  -");
            Console.WriteLine("- 1 - Adicionar Produto a Venda             -");
            Console.WriteLine("- 2 - Remover Produto da venda              -");
            Console.WriteLine("- 3 - Registar Venda                        -");
            Console.WriteLine("------------------Menu Vendas----------------");
        }


        /// <summary>
        /// Metodo que apresenta o menu de Alteraçoes de dados de produtos na consola
        /// </summary>
        public static void MenuAlterarProduto()
        {
            Console.WriteLine("------------------Menu Alterar Produto----------------");
            Console.WriteLine("- 0 - Sair                                           -");
            Console.WriteLine("- 1 - Alterar Nome                                   -");
            Console.WriteLine("- 2 - Alterar Valor                                  -");
            Console.WriteLine("- 3 - Alterar Garantia                               -");
            Console.WriteLine("- 4 - Alterar Categoria                              -");
            Console.WriteLine("- 5 - Alterar Marca                                  -");
            Console.WriteLine("------------------Menu Alterar Produto----------------");
        }


        /// <summary>
        /// Metodo que apresenta o menu de Alteraçoes de dados de marcas na consola
        /// </summary>
        public static void MenuAlterarMarca()
        {
            Console.WriteLine("------------------Menu Alterar Marca----------------");
            Console.WriteLine("- 0 - Sair                                         -");
            Console.WriteLine("- 1 - Alterar Nome                                 -");
            Console.WriteLine("- 2 - Alterar Morada                               -");
            Console.WriteLine("------------------Menu Alterar Marca----------------");
        }


        /// <summary>
        /// Metodo que apresenta o menu de Alteraçoes de dados de categorias na consola
        /// </summary>
        public static void MenuAlterarCategoria()
        {
            Console.WriteLine("------------------Menu Alterar Categoria----------------");
            Console.WriteLine("- 0 - Sair                                             -");
            Console.WriteLine("- 1 - Alterar Nome                                     -");
            Console.WriteLine("------------------Menu Alterar Categoria----------------");
        }



        /// <summary>
        /// Metodo que apresenta o menu de Alteraçoes de dados de Fornecedores na consola
        /// </summary>
        public static void MenuAlterarFornecedor()
        {
            Console.WriteLine("------------------Menu Alterar Fornecedor----------------");
            Console.WriteLine("- 0 - Sair                                              -");
            Console.WriteLine("- 1 - Alterar Nome                                      -");
            Console.WriteLine("- 2 - Alterar Morada                                    -");
            Console.WriteLine("- 3 - Alterar NIF                                       -");
            Console.WriteLine("- 4 - Alterar Telemovel                                 -");
            Console.WriteLine("------------------Menu Alterar Fornecedor----------------");
        }



        /// <summary>
        /// Metodo que apresenta o menu de Alteraçoes de dados de Clientes na consola
        /// </summary>
        public static void MenuAlterarCliente()
        {
            Console.WriteLine("------------------Menu Alterar Cliente----------------");
            Console.WriteLine("- 0 - Sair                                           -");
            Console.WriteLine("- 1 - Alterar Nome                                   -");
            Console.WriteLine("- 2 - Alterar Morada                                 -");
            Console.WriteLine("- 3 - Alterar NIF                                    -");
            Console.WriteLine("- 4 - Alterar Telemovel                              -");
            Console.WriteLine("------------------Menu Alterar Cliente----------------");
        }



        #endregion

        #region LerOpçoesMenus


        /// <summary>
        /// Metodo que le a opçao escolhida pelo utilizador relativa ao menu principal
        /// </summary>
        /// <returns></returns>
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
            } while (num < 0 || num > 21);
            return num;
        }



        /// <summary>
        /// Metodo que le a opçao escolhida pelo utilizador relativa ao menu de compras e vendas 
        /// </summary>
        /// <returns></returns>
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


        /// <summary>
        /// Metodo que le a opçao escolhida pelo utilizador relativa ao menu de Alteraçoes de dados de Clientes
        /// </summary>
        /// <returns></returns>
        public static int LernumeroMenuCliente()
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
            } while (num < 0 || num > 4);
            return num;
        }


        /// <summary>
        /// Metodo que le a opçao escolhida pelo utilizador relativa ao menu de Alteraçoes de dados de Fornecedores
        /// </summary>
        /// <returns></returns>
        public static int LernumeroMenuFornecedor()
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
            } while (num < 0 || num > 4);
            return num;
        }


        /// <summary>
        /// Metodo que le a opçao escolhida pelo utilizador relativa ao menu de Alteraçoes de dados de Marcas
        /// </summary>
        /// <returns></returns>
        public static int LernumeroMenuMarca()
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
            } while (num < 0 || num > 2);
            return num;
        }



        /// <summary>
        /// Metodo que le a opçao escolhida pelo utilizador relativa ao menu de Alteraçoes de dados de Categorias
        /// </summary>
        /// <returns></returns>
        public static int LernumeroMenuCategoria()
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
            } while (num < 0 || num > 1);
            return num;
        }


        /// <summary>
        /// Metodo que le a opçao escolhida pelo utilizador relativa ao menu de Alteraçoes de dados de produtos  
        /// </summary>
        /// <returns></returns>
        public static int LernumeroMenuProduto()
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
            } while (num < 0 || num > 5);
            return num;
        }


        #endregion

        #region MetodosConsola

        /// <summary>
        /// Metodo que espera que seja pressionada  uma tecla antes de avançar
        /// </summary>
        public static void ReadKey()
        {
            Console.ReadKey();
        }


        /// <summary>
        /// Metodo que limpa a consola
        /// </summary>
        public static void ClearConsole()
        {
            Console.Clear();
        }


        /// <summary>
        /// Metodo que escreve uma mensagem na consola
        /// </summary>
        /// <param name="mensagem"></param>
        public static void EscreverMensagem(string mensagem)
        {
            Console.WriteLine(mensagem);
        }

        #endregion

        #region MetodosAuxliaresLeitura



        /// <summary>
        /// Metodo que le uma string inserida pelo utilizador
        /// </summary>
        /// <returns></returns>
        public static string LerString()
        {
            return Console.ReadLine();
        }




        /// <summary>
        /// Metodo que le um inteiro inserido pelo utilizador
        /// </summary>
        /// <returns></returns>
        public static int LerInt()
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



        /// <summary>
        /// Metodo que le um float inserido pelo utilizador
        /// </summary>
        /// <returns></returns>
        public static float LerFloat()
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



        /// <summary>
        /// Metodo que le os dados necessarios a criaçao de um objeto da classe categoria
        /// </summary>
        /// <returns></returns>
        public static Categoria DadosCategoria()
        {
            Console.WriteLine("-------Criar Categoria--------");
            Console.WriteLine("Indique um nome para a categoria: ");
            string nomeCat = LerString();
            Categoria cat = new Categoria(nomeCat);

            return cat;
        }


        /// <summary>
        /// Metodo que le os dados necessarios a criaçao de um objeto da classe marca
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Metodo que le os dados necessarios a criaçao de um objeto da classe Fornecedor
        /// </summary>
        /// <returns></returns>
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



        /// <summary>
        /// Metodo que le os dados necessarios a criaçao de um objeto da classe Cliente
        /// </summary>
        /// <returns></returns>
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


        /// <summary>
        /// Metodo que le os dados necessarios a criaçao de um objeto da classe Produto
        /// </summary>
        /// <returns></returns>
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


        /// <summary>
        /// Metodo que le os dados necessarios a criaçao de um objeto da classe Compra
        /// </summary>
        /// <returns></returns>
        public static Compra DadosCriarCompra()
        {
            IO.ListaFornecedores();
            Console.WriteLine("Criar compra nova");
            Console.WriteLine("Indique o ID do fornecedor");
            int IDF = LerInt();

            Compra comp = new Compra(DateTime.Now, IDF);

            return comp;
        }


        /// <summary>
        /// Metodo que le os dados necessarios para adicionar um produto a uma compra
        /// </summary>
        /// <param name="quantProd"></param>
        /// <returns></returns>
        public static int DadosAdicionarProdutosCompra(out int quantProd)
        {
            Console.WriteLine("Escolha um produto identificando o seu id: ");
            int idProd = -1;
            do
            {
                idProd = LerInt();
            } while (!RegrasNegocio.ExisteProdutoPorId(idProd));
            Console.WriteLine("Indique a quantidade: ");
            int aux = -1;
            do
            {
                aux = LerInt();
            } while (aux <= 0);

            quantProd = aux;

            return idProd;

        }


        /// <summary>
        /// Metodo que le os dados necessarios para remover um produto de uma compra
        /// </summary>
        /// <param name="quantProd"></param>
        /// <param name="comp"></param>
        /// <returns></returns>
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


        /// <summary>
        /// Metodo que le os dados necessarios a criaçao de um objeto da classe Venda
        /// </summary>
        /// <returns></returns>
        public static Venda DadosCriarVenda()
        {
            IO.ListaClientes();
            Console.WriteLine("Criar venda nova");
            Console.WriteLine("Indique o ID do Cliente");
            int IDC = LerInt();

            Venda vend = new Venda(DateTime.Now, IDC);

            return vend;
        }


        /// <summary>
        /// Metodo que le os dados necessarios para adicionar um produto a uma venda
        /// </summary>
        /// <param name="quantProd"></param>
        /// <returns></returns>
        public static int DadosAdicionarProdutosVenda(out int quantProd)
        {

            Console.WriteLine("Escolha um produto identificando o seu id: ");
            int idProd = -1;
            do
            {
                idProd = LerInt();
            } while (!RegrasNegocio.ExisteProdutoPorId(idProd));
            Console.WriteLine("Indique a quantidade: ");
            int aux = -1;
            do
            {
                aux = LerInt();
            } while (aux <= 0);

            quantProd = aux;

            return idProd;
        }


        /// <summary>
        /// Metodo que le os dados necessarios para remover um produto de uma venda
        /// </summary>
        /// <param name="quantProd"></param>
        /// <param name="vend"></param>
        /// <returns></returns>
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