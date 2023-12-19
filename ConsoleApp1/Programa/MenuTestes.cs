/*
*	<copyright file="Programa.cs" company="IPCA">
*	Copyright (c) 2023 All Rights Reserved
*	</copyright>
* 	<author>Fábio Lopes</author>
*   <date>12/12/2023</date>
*	<description></description>
*/

using System;
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
                        Console.ReadKey();
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
                    case 11:     // Menu Compras 
                        int auxMenuc = -1;
                        IO.ClearConsole();
                        Compra comp = IO.DadosCriarCompra();
                        do
                        {
                            IO.ClearConsole();


                            //compaux.MostraListaCompras();                     Mudar o sitio e melhorar
                            

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
                                    Console.ReadKey();
                                    break;
                                case 2:     //Remover Produto da compra
                                    IO.ClearConsole();
                                    if (!(comp.ArtigosComprados.Count < 1))
                                    {
                                        comp.MostraListaCompras();
                                        int idPro, quantPro;

                                        idPro = IO.DadosRemoverProdutosCompra(out quantPro, comp);

                                        bool aux2 = comp.RemoverProdutoCompra(idPro, quantPro);

                                        if (aux2)
                                            IO.EscreverMensagem("Produto Removido Com Sucesso!");
                                        else
                                            IO.EscreverMensagem("Erro ao Remover produto!");
                                        Console.ReadKey();
                                    }
                                    else
                                        IO.EscreverMensagem("Nao exitem produtos adicionados a compra");
                                    break;
                                case 3:     //Registar Compra                                      
                                    bool comprabool = RegrasNegocio.AdicionarCompra(comp);

                                    if (comprabool)
                                        IO.EscreverMensagem("Compra registada com sucesso!");
                                    else
                                        IO.EscreverMensagem("Erro ao registar Compra!");

                                    Console.ReadKey();
                                    auxMenuc = 0;
                                    break;
                                default:
                                    IO.EscreverMensagem("Default, algo errou!!!");
                                    break;
                            }
                        } while (auxMenuc != 0);
                        comp = null;
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