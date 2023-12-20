﻿/*
*	<copyright file="Programa.cs" company="IPCA">
*	Copyright (c) 2023 All Rights Reserved
*	</copyright>
* 	<author>Fábio Lopes & Ruben Costa</author>
*   <date>12/12/2023</date>
*	<description></description>
*/

using InOut;
using ObjetosNegocio;
using RN;
using System;

namespace Programa
{
    /// <summary>
    /// Purpose: 
    /// Created by: Fábio Lopes & Ruben Costa
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

                    case 0:     //Sair
                        break;
                    case 1:     //Adicionar Categoria
                        IO.ClearConsole();
                        Categoria cat = IO.DadosCategoria();
                        try
                        {
                            RegrasNegocio.AdicionarCategoria(cat);
                        }catch (Exception e)
                        {
                            IO.EscreverMensagem(e.Message);
                        }
                        IO.ReadKey();
                        break;
                    case 2:     //Adicionar Marca
                        IO.ClearConsole();
                        Marca mar = IO.DadosMarca();
                        try
                        {
                            RegrasNegocio.AdicionarMarca(mar);
                        }
                        catch (Exception e)
                        {
                            IO.EscreverMensagem(e.Message);
                        }
                        break;
                    case 3:     //Adicionar Fornecedor
                        IO.ClearConsole();
                        Fornecedor forn = IO.DadosFornecedor();
                        try
                        {
                            RegrasNegocio.AdicionarFornecedor(forn);
                        }
                        catch(Exception e)
                        {
                            IO.EscreverMensagem(e.Message);
                        }
                        break;
                    case 4:     //Adicionar Cliente
                        IO.ClearConsole();
                        Cliente cli = IO.DadosCliente();
                        RegrasNegocio.AdicionarCliente(cli);
                        break;
                    case 5:     //Adicionar Produto
                        IO.ClearConsole();
                        Produto produtocriar = IO.DadosProduto();
                        try
                        {
                            RegrasNegocio.AdicionarProduto(produtocriar);
                        }
                        catch (Exception e)
                        {
                            IO.EscreverMensagem(e.Message);
                        }
                        break;
                    case 6:     //Listar Categorias
                        IO.ClearConsole();
                        IO.ListaCategorias();
                        break;
                    case 7:     //Listar Marcas
                        IO.ClearConsole();
                        IO.ListaMarcas();
                        break;
                    case 8:     //Listar Fornecedores
                        IO.ClearConsole();
                        IO.ListaFornecedores();
                        break;
                    case 9:     //Listar Clientes
                        IO.ClearConsole();
                        IO.ListaClientes();
                        break;
                    case 10:    //Listar Produtos
                        IO.ClearConsole();
                        IO.ListaProdutos();
                        break;
                    case 11:    //Listar produtos ascendente por valor
                        IO.ClearConsole();
                        IO.ListaProdutosPrecoAsc();
                        break;
                    case 12:    //Listar Produtos descendente por valor
                        IO.ClearConsole();
                        IO.ListaProdutosPrecoDesc();
                        break;
                    case 13:    // ListarVendas
                        IO.ClearConsole();
                        IO.ListaVendas();
                        IO.ReadKey();
                        break;
                    case 14:    //ListarCompras
                        IO.ClearConsole();
                        IO.ListaCompras();
                        IO.ReadKey();
                        break;
                    case 15:     // Menu Compras 
                        int auxMenuc = -1;
                        IO.ClearConsole();
                        Compra comp = IO.DadosCriarCompra();
                        do
                        {
                            IO.ClearConsole();
                            IO.MostrarDadosCompra(comp);
                            IO.MenuCompras();
                            auxMenuc = IO.LernumeroMenuCompra();
                            switch (auxMenuc)
                            {
                                case 0:
                                    break;
                                case 1:     //Adicionar Produto a compra 
                                    IO.ClearConsole();
                                    IO.ListaProdutos();
                                    int idProd, quantProd;
                                    idProd = IO.DadosAdicionarProdutosCompra(out quantProd);
                                    bool aux1 = comp.AdicionarProdutoCompra(idProd, quantProd);
                                    if (aux1)
                                        IO.EscreverMensagem("Produto Adicionado Com Sucesso!");
                                    else
                                        IO.EscreverMensagem("Erro ao adicionar produto!");
                                    IO.ReadKey();
                                    break;
                                case 2:     //Remover Produto da compra
                                    IO.ClearConsole();
                                    if (!(comp.ArtigosComprados.Count < 1))
                                    {
                                        IO.MostrarDadosCompra(comp);
                                        int idPro, quantPro;

                                        idPro = IO.DadosRemoverProdutosCompra(out quantPro, comp);

                                        bool aux2 = comp.RemoverProdutoCompra(idPro, quantPro);

                                        if (aux2)
                                            IO.EscreverMensagem("Produto Removido Com Sucesso!");
                                        else
                                            IO.EscreverMensagem("Erro ao Remover produto!");
                                        IO.ReadKey();
                                    }
                                    else
                                        IO.EscreverMensagem("Nao exitem produtos adicionados a compra");
                                    break;
                                case 3:     //Registar Compra
                                    bool comprabool = false;
                                    try
                                    {
                                        comprabool = RegrasNegocio.AdicionarCompra(comp);
                                    }
                                    catch (Exception e)
                                    {
                                        IO.EscreverMensagem(e.Message);
                                    }
                                    
                                    if (comprabool)
                                        IO.EscreverMensagem("Compra registada com sucesso!");
                                    else
                                        IO.EscreverMensagem("Erro ao registar Compra!");

                                    IO.ReadKey();
                                    auxMenuc = 0;
                                    break;
                                default:
                                    IO.EscreverMensagem("Default, algo errou!!!");
                                    break;
                            }
                        } while (auxMenuc != 0);
                        comp = null;
                        break;
                    case 16:    // Menu Vendas
                        int auxMenuV = -1;
                        IO.ClearConsole();
                        Venda vend = IO.DadosCriarVenda();
                        do
                        {
                            IO.ClearConsole();

                            IO.MostrarDadosVenda(vend);

                            IO.MenuVendas();
                            auxMenuV = IO.LernumeroMenuCompra();
                            switch (auxMenuV)
                            {
                                case 0:
                                    break;
                                case 1:     //Adicionar Produto a venda
                                    IO.ClearConsole();
                                    IO.ListaProdutos();

                                    int idProd, quantProd;
                                    idProd = IO.DadosAdicionarProdutosVenda(out quantProd);
                                    bool auxv = vend.AdicionarProdutoVenda(idProd, quantProd);

                                    if (auxv)
                                        IO.EscreverMensagem("Produto adicionado com sucesso!");
                                    else
                                        IO.EscreverMensagem("Erro ao adicionar produto!");

                                    IO.ReadKey();
                                    break;
                                case 2:     // Remover Produto da Venda
                                    IO.ClearConsole();
                                    if (!(vend.ArtigosVendidos.Count < 1))
                                    {
                                        IO.MostrarDadosVenda(vend);

                                        idProd = IO.DadosRemoverProdutosVenda(out quantProd, vend);

                                        bool auxv1 = vend.RemoverProdutoVenda(idProd, quantProd);

                                        if (auxv1)
                                            IO.EscreverMensagem("Produto removido com sucesso!");
                                        else
                                            IO.EscreverMensagem("Erro ao remover produto!");
                                        IO.ReadKey();
                                    }
                                    else
                                        IO.EscreverMensagem("Nao exitem produtos adicionados a compra");      
                                    break;
                                case 3:     // Registar Venda

                                    bool vendabool = false;

                                    try
                                    {
                                        vendabool = RegrasNegocio.AdicionarVenda(vend);
                                    }
                                    catch (Exception e)
                                    {
                                        IO.EscreverMensagem(e.Message);
                                    }


                                    if (vendabool)
                                        IO.EscreverMensagem("Venda registada com sucesso!");
                                    else
                                        IO.EscreverMensagem("Erro ao registar venda!");
                                    IO.ReadKey();
                                    auxMenuV = 0;
                                    break;
                                default:
                                    IO.EscreverMensagem("Default, algo errou!!!");                   
                                    break;
                            }
                        } while (auxMenuV != 0);
                        break;

                    default:
                        IO.EscreverMensagem("Default, algo errou!!!");                           
                        break;
                }

            } while (menu != 0);

            return 0;
        }


        #endregion

        #endregion

    }
}