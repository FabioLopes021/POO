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
                IO.ClearConsole();
                IO.MenuShow();
                menu = IO.LernumeroMenuPrincipal();
                switch (menu)
                {

                    case 0:
                        break;
                    case 1:
                        IO.ClearConsole();
                        Categoria cat = IO.DadosCategoria();
                        RegrasNegocio.AdicionarCategoria(cat);
                        break;
                    case 2:
                        IO.ClearConsole();
                        Marca mar = IO.DadosMarca();
                        RegrasNegocio.AdicionarMarca(mar);
                        break;
                    case 3:
                        IO.ClearConsole();
                        Fornecedor forn = IO.DadosFornecedor();
                        RegrasNegocio.AdicionarFornecedor(forn);
                        break;
                    case 4:
                        IO.ClearConsole();
                        Cliente cli = IO.DadosCliente();
                        RegrasNegocio.AdicionarCliente(cli);
                        break;
                    case 5:
                        IO.ClearConsole();
                        Produto produtocriar = IO.DadosProduto();
                        RegrasNegocio.AdicionarProduto(produtocriar);
                        break;
                    case 6:
                        IO.ClearConsole();
                        IO.ListaCategorias();
                        break;
                    case 7:
                        IO.ClearConsole();
                        IO.ListaMarcas();
                        break;
                    case 8:
                        IO.ClearConsole();
                        IO.ListaFornecedores();
                        break;
                    case 9:
                        IO.ClearConsole();
                        IO.ListaClientes();
                        break;
                    case 10:
                        IO.ClearConsole();
                        IO.ListaProdutos();
                        break;
                    case 11:     // Menu Compras 
                        int auxMenuc = -1;
                        Compra compaux = new Compra();
                        do
                        {
                            IO.ClearConsole();

                            Console.WriteLine("-------------Informaçoes compra--------------");
                            compaux.MostraListaCompras();
                            Console.WriteLine("-------------Informaçoes compra--------------");

                            IO.MenuCompras();
                            Compra comp;
                            auxMenuc = IO.LernumeroMenuCompra();
                            switch (auxMenuc)
                            {
                                case 0:
                                    break;
                                case 1:     //Criar Compra
                                    IO.ClearConsole();
                                    comp = IO.DadosCriarCompra();
                                    compaux = comp;
                                    break;
                                case 2:     //Adicionar Produto a compra
                                    IO.ClearConsole();
                                    IO.ListaProdutos();
                                    comp = compaux;
                                    int idProd, quantProd;

                                    idProd = IO.DadosAdicionarProdutosCompra(out quantProd);
                                    
                                    comp.AdicionarProdutoCompra(idProd, quantProd);
                                    break;
                                case 3:     //Remover produto da compra
                                    IO.ClearConsole();
                                    comp = compaux;
                                    if (!(comp.ArtigosComprados.Count < 1))
                                    {
                                        comp.MostraListaCompras();
                                        int idPro, quantPro;

                                        idPro = IO.DadosRemoverProdutosCompra(out quantPro, comp);

                                        comp.RemoverProdutoCompra(idPro, quantPro);
                                    }
                                    else
                                        IO.EscreverMensagem("Nao exitem produtos adicionados a compra");
                                    break;
                                case 4:     // Registar Compra
                                    bool comprabool = RegrasNegocio.AdicionarCompra(compaux);
                                    Console.ReadKey();
                                    break;
                                default:
                                    Console.WriteLine("Default, algo errou!!!");                //Alterar para o IO
                                    break;
                            }
                        } while (auxMenuc != 0);
                        break;
                    case 12:    // Menu Vendas
                        int auxMenuV = -1;
                        Venda vendAux = new Venda();
                        do
                        {
                            IO.ClearConsole();
                            IO.MenuVendas();
                            auxMenuV = IO.LernumeroMenuCompra();
                            Venda vend;
                            switch (auxMenuV)
                            {
                                case 0:
                                    break;
                                case 1:
                                    vend = IO.DadosCriarVenda();
                                    vendAux = vend;
                                    break;
                                case 2:
                                    IO.ClearConsole();
                                    IO.ListaProdutos();

                                    int idProd, quantProd;
                                    idProd = IO.DadosAdicionarProdutosVenda(out quantProd);
                                    
                                    vend = vendAux;

                                    vend.AdicionarProdutoVenda(idProd, quantProd);
                                    break;
                                case 3:
                                    IO.ClearConsole();
                                    vend = vendAux;
                                    if (!(vend.ArtigosVendidos.Count < 1))
                                    {
                                        vend.MostraListaCompras();
                                        vend = vendAux;

                                        idProd = IO.DadosRemoverProdutosVenda(out quantProd,vend);

                                        vend.RemoverProdutoVenda(idProd, quantProd);
                                    }
                                    else
                                        Console.WriteLine("Nao exitem produtos adicionados a compra");              // mudar o consol writeline
                                    break;
                                case 4:
                                    RegrasNegocio.AdicionarVenda(vendAux);
                                    
                                    break;
                                default:
                                    Console.WriteLine("Default, algo errou!!!");                    // mudar o consol writeline
                                    break;
                            }
                        } while (auxMenuV != 0);
                        break;
                    default:
                        Console.WriteLine("Default, algo errou!!!");                            // mudar o consol writeline
                        break;
                }

            } while (menu != 0);

            return 0;
        }


        #endregion

        #endregion

    }
}