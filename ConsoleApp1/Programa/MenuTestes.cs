/*
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
                            bool aux = RegrasNegocio.AdicionarCategoria(cat);
                            if (aux)
                                IO.EscreverMensagem("Categoria Adicionada Com sucesso!");
                            else
                                IO.EscreverMensagem("Erro ao criar Categoria!");
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
                            bool aux = RegrasNegocio.AdicionarMarca(mar);
                            if (aux)
                                IO.EscreverMensagem("Marca Adicionada Com sucesso!");
                            else
                                IO.EscreverMensagem("Erro ao criar marca!");
                        }
                        catch (Exception e)
                        {
                            IO.EscreverMensagem(e.Message);
                        }
                        IO.ReadKey();
                        break;
                    case 3:     //Adicionar Fornecedor
                        IO.ClearConsole();
                        Fornecedor forn = IO.DadosFornecedor();
                        try
                        {
                            bool aux = RegrasNegocio.AdicionarFornecedor(forn);
                            if (aux)
                                IO.EscreverMensagem("Fornecedor Adicionado Com sucesso!");
                            else
                                IO.EscreverMensagem("Erro ao criar Fornecedor!");
                        }
                        catch(Exception e)
                        {
                            IO.EscreverMensagem(e.Message);
                        }
                        IO.ReadKey();
                        break;
                    case 4:     //Adicionar Cliente
                        IO.ClearConsole();
                        Cliente cli = IO.DadosCliente();
                        try
                        {
                            bool aux = RegrasNegocio.AdicionarCliente(cli);
                            if (aux)
                                IO.EscreverMensagem("Cliente Adicionado Com sucesso!");
                            else
                                IO.EscreverMensagem("Erro ao criar Cliente!");
                        }
                        catch (Exception e)
                        {
                            IO.EscreverMensagem(e.Message);
                        }
                        IO.ReadKey();
                        break;
                    case 5:     //Adicionar Produto
                        IO.ClearConsole();
                        Produto produtocriar = IO.DadosProduto();
                        try
                        {
                            bool aux = RegrasNegocio.AdicionarProduto(produtocriar);
                            if (aux)
                                IO.EscreverMensagem("Produto Adicionado Com sucesso!");
                            else
                                IO.EscreverMensagem("Erro ao criar Produto!");
                        }
                        catch (Exception e)
                        {
                            IO.EscreverMensagem(e.Message);
                        }
                        IO.ReadKey();
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
                    case 17:    // Alterar dados produto
                        int auxMenuAltProd = -1;
                        int idProduto;
                        if (RegrasNegocio.NumProdutos() < 1)
                        {
                            IO.EscreverMensagem("Nao existem produtos em stock!");
                            IO.ReadKey();
                            break;
                        }
                            
                        IO.ClearConsole();
                        IO.ListaProdutos();
                        IO.EscreverMensagem("Escolha o Id do produto que deseja alterar: ");
                        do
                        {
                            idProduto = IO.LerInt();
                        } while (!RegrasNegocio.ExisteProdutoPorId(idProduto));
                        do
                        {
                            IO.ClearConsole();
                            IO.MenuAlterarProduto();
                            auxMenuAltProd = IO.LernumeroMenuProduto();
                            switch (auxMenuAltProd)
                            {
                                case 0:
                                    break;
                                case 1:     //Alterar Nome
                                    string NovoNome;
                                    IO.EscreverMensagem("Indique o novo nome");
                                    NovoNome = IO.LerString();
                                    bool aux1 = RegrasNegocio.AlterarNomeProduto(idProduto,NovoNome);
                                    if (aux1)
                                        IO.EscreverMensagem("Nome Alterado com sucesso! ");
                                    else
                                        IO.EscreverMensagem("Ocurreu um erro ao alterar o nome!");
                                    IO.ReadKey();
                                    break;
                                case 2:     //Alterar Valor
                                    float novoValor;
                                    IO.EscreverMensagem("Indique o novo Preço");
                                    novoValor = IO.LerFloat();
                                    bool aux2 = RegrasNegocio.AlterarValorProduto(idProduto, novoValor);
                                    if (aux2)
                                        IO.EscreverMensagem("Preço Alterado com sucesso! ");
                                    else
                                        IO.EscreverMensagem("Ocurreu um erro ao alterar o Preço!");
                                    IO.ReadKey();
                                    break;
                                case 3:     //Alterar Garantia
                                    float novaGarantia;
                                    IO.EscreverMensagem("Indique a nova Garantia (em anos)");
                                    novaGarantia = IO.LerFloat();
                                    bool aux3 = RegrasNegocio.AlterarGarantiaProduto(idProduto, novaGarantia);
                                    if (aux3)
                                        IO.EscreverMensagem("Garantia Alterado com sucesso! ");
                                    else
                                        IO.EscreverMensagem("Ocurreu um erro ao alterar o Garantia!");
                                    IO.ReadKey();
                                    break;
                                case 4:     //Alterar Categoria
                                    int idNovaCat;
                                    IO.ClearConsole();
                                    IO.ListaCategorias();
                                    IO.EscreverMensagem("Indique o Id da nova categoria");
                                    do
                                    {
                                        idNovaCat = IO.LerInt();
                                    } while (idNovaCat < 0);        //Alterar para verificar se existem categorias
                                    bool aux4 = RegrasNegocio.AlterarCategoriaProduto(idProduto, idNovaCat);
                                    if (aux4)
                                        IO.EscreverMensagem("Categoria Alterada com sucesso! ");
                                    else
                                        IO.EscreverMensagem("Ocurreu um erro ao alterar o Categoria!");
                                    IO.ReadKey();
                                    break;
                                case 5:     //Alterar Marca
                                    int idNovaMar;
                                    IO.ClearConsole();
                                    IO.ListaMarcas();
                                    IO.EscreverMensagem("Indique o Id da nova Marca");
                                    do
                                    {
                                        idNovaMar = IO.LerInt();
                                    } while (idNovaMar < 0);        //Alterar para verificar se existem categorias
                                    bool aux5 = RegrasNegocio.AlterarMarcaProduto(idProduto, idNovaMar);
                                    if (aux5)
                                        IO.EscreverMensagem("Marca Alterada com sucesso! ");
                                    else
                                        IO.EscreverMensagem("Ocurreu um erro ao alterar a Marca!");
                                    IO.ReadKey();
                                    break;
                                default:
                                    IO.EscreverMensagem("Default, algo errou!!!");
                                    break;
                            }
                        } while (auxMenuAltProd != 0);
                        break;
                    case 18:    // Alterar dados Marca
                        int auxMenuAltMarca = -1;
                        int idMarca = 0;
                        if (RegrasNegocio.NumMarcas() < 1)
                        {
                            IO.EscreverMensagem("Nao existem Marcas Criadas!");
                            IO.ReadKey();
                            break;
                        }
                        IO.ClearConsole();
                        IO.ListaMarcas();
                        IO.EscreverMensagem("Escolha o Id da marca que deseja alterar: ");
                        do
                        {
                            idMarca = IO.LerInt();
                        } while (!RegrasNegocio.ExisteMarcaPorId(idMarca));
                        do
                        {
                            IO.ClearConsole();
                            IO.MenuAlterarMarca();
                            auxMenuAltMarca = IO.LernumeroMenuMarca();
                            switch (auxMenuAltMarca)
                            {
                                case 0:
                                    break;
                                case 1:     //Alterar Nome
                                    string NovoNome;
                                    IO.EscreverMensagem("Indique o novo nome");
                                    NovoNome = IO.LerString();
                                    bool aux1 = RegrasNegocio.AlterarNomeMarca(idMarca, NovoNome);
                                    if (aux1)
                                        IO.EscreverMensagem("Nome Alterado com sucesso! ");
                                    else
                                        IO.EscreverMensagem("Ocurreu um erro ao alterar o nome!");
                                    IO.ReadKey();
                                    break;
                                case 2:     //Alterar Morada
                                    IO.ClearConsole();
                                    string NovaMorada;
                                    IO.EscreverMensagem("Indique a nova Morada");
                                    NovaMorada = IO.LerString();
                                    bool aux2 = RegrasNegocio.AlterarMoradaMarca(idMarca, NovaMorada);
                                    if (aux2)
                                        IO.EscreverMensagem("Morada Alterado com sucesso! ");
                                    else
                                        IO.EscreverMensagem("Ocurreu um erro ao alterar a Morada!");
                                    IO.ReadKey();
                                    break;
                                default:
                                    IO.EscreverMensagem("Default, algo errou!!!");
                                    break;
                            }
                        } while (auxMenuAltMarca != 0);
                        break;
                    case 19:    // Alterar dados Fornecedor
                        int auxMenuAltForn = -1;
                        int idFornecedor;
                        if (RegrasNegocio.NumFornecedores() < 1)
                        {
                            IO.EscreverMensagem("Nao existem Fornecedores Criados!");
                            IO.ReadKey();
                            break;
                        }
                        IO.ClearConsole();
                        IO.ListaFornecedores();
                        IO.EscreverMensagem("Escolha o Id do Fornecedor que deseja alterar: ");
                        do
                        {
                            idFornecedor = IO.LerInt();
                        } while (!RegrasNegocio.ExisteFornecedorPorId(idFornecedor));
                        do
                        {
                            IO.ClearConsole();
                            IO.MenuAlterarFornecedor();
                            auxMenuAltForn = IO.LernumeroMenuFornecedor();
                            switch (auxMenuAltForn)
                            {
                                case 0:
                                    break;
                                case 1:     //Alterar Nome
                                    string NovoNome;
                                    IO.EscreverMensagem("Indique o novo nome");
                                    NovoNome = IO.LerString();
                                    bool aux1 = RegrasNegocio.AlterarNomeFornecedor(idFornecedor, NovoNome);
                                    if (aux1)
                                        IO.EscreverMensagem("Nome Alterado com sucesso! ");
                                    else
                                        IO.EscreverMensagem("Ocurreu um erro ao alterar o nome!");
                                    IO.ReadKey();
                                    break;
                                case 2:     //Alterar Morada
                                    string NovaMorada;
                                    IO.EscreverMensagem("Indique a nova Morada");
                                    NovaMorada = IO.LerString();
                                    bool aux2 = RegrasNegocio.AlterarMoradaFornecedor(idFornecedor, NovaMorada);
                                    if (aux2)
                                        IO.EscreverMensagem("Morada Alterado com sucesso! ");
                                    else
                                        IO.EscreverMensagem("Ocurreu um erro ao alterar a Morada!");
                                    IO.ReadKey();
                                    break;
                                case 3:     //Alterar NIF
                                    int novoNIF;
                                    IO.EscreverMensagem("Indique o novo NIF");
                                    novoNIF = IO.LerInt();
                                    bool aux3 = RegrasNegocio.AlterarNIFFornecedor(idFornecedor, novoNIF);
                                    if (aux3)
                                        IO.EscreverMensagem("NIF Alterado com sucesso! ");
                                    else
                                        IO.EscreverMensagem("Ocurreu um erro ao alterar a NIF!");
                                    IO.ReadKey();
                                    break;
                                case 4:     //Alterar Telemovel
                                    int novoTel;
                                    IO.EscreverMensagem("Indique o novo numero de telemovel");
                                    novoTel = IO.LerInt();
                                    bool aux4 = RegrasNegocio.AlterarTelemovelFornecedor(idFornecedor, novoTel);
                                    if (aux4)
                                        IO.EscreverMensagem("Telemovel Alterado com sucesso! ");
                                    else
                                        IO.EscreverMensagem("Ocurreu um erro ao alterar a Telemovel!");
                                    IO.ReadKey();
                                    break;
                                default:
                                    IO.EscreverMensagem("Default, algo errou!!!");
                                    break;
                            }
                        } while (auxMenuAltForn != 0);
                        break;
                    case 20:    // Alterar dados Clientes
                        int auxMenuAltCliente = -1;
                        int idCliente;
                        if (RegrasNegocio.NumClientes() < 1)
                        {
                            IO.EscreverMensagem("Nao existem Clientes Criados!");
                            IO.ReadKey();
                            break;
                        }
                        IO.ClearConsole();
                        IO.ListaClientes();
                        IO.EscreverMensagem("Escolha o Id do Cliente que deseja alterar: ");
                        do
                        {
                            idCliente = IO.LerInt();
                        } while (!RegrasNegocio.ExisteClientePorId(idCliente));
                        do
                        {
                            IO.ClearConsole();
                            IO.MenuAlterarCliente();
                            auxMenuAltCliente = IO.LernumeroMenuCliente();
                            switch (auxMenuAltCliente)
                            {
                                case 0:
                                    break;
                                case 1:     //Alterar Nome
                                    string NovoNome;
                                    IO.EscreverMensagem("Indique o novo nome");
                                    NovoNome = IO.LerString();
                                    bool aux1 = RegrasNegocio.AlterarNomeCliente(idCliente, NovoNome);
                                    if (aux1)
                                        IO.EscreverMensagem("Nome Alterado com sucesso! ");
                                    else
                                        IO.EscreverMensagem("Ocurreu um erro ao alterar o Nome!");
                                    IO.ReadKey();
                                    break;
                                case 2:     //Alterar Morada
                                    string NovaMorada;
                                    IO.EscreverMensagem("Indique o novo nome");
                                    NovaMorada = IO.LerString();
                                    bool aux2 = RegrasNegocio.AlterarMoradaCliente(idCliente, NovaMorada);
                                    if (aux2)
                                        IO.EscreverMensagem("Morada Alterado com sucesso! ");
                                    else
                                        IO.EscreverMensagem("Ocurreu um erro ao alterar a Morada!");
                                    IO.ReadKey();
                                    break;
                                case 3:     //Alterar NIF
                                    int novoNIF;
                                    IO.EscreverMensagem("Indique o novo NIF");
                                    novoNIF = IO.LerInt();
                                    bool aux3 = RegrasNegocio.AlterarNIFCliente(idCliente, novoNIF);
                                    if (aux3)
                                        IO.EscreverMensagem("NIF Alterado com sucesso! ");
                                    else
                                        IO.EscreverMensagem("Ocurreu um erro ao alterar o NIF!");
                                    IO.ReadKey();
                                    break;
                                case 4:     //Alterar Telemovel
                                    int novoTel;
                                    IO.EscreverMensagem("Indique o novo numero de telemovel");
                                    novoTel = IO.LerInt();
                                    bool aux4 = RegrasNegocio.AlterarTelemovelCliente(idCliente, novoTel);
                                    if (aux4)
                                        IO.EscreverMensagem("Telemovel Alterado com sucesso! ");
                                    else
                                        IO.EscreverMensagem("Ocurreu um erro ao alterar o Telemovel!");
                                    IO.ReadKey();
                                    break;
                                default:
                                    IO.EscreverMensagem("Default, algo errou!!!");
                                    break;
                            }
                        } while (auxMenuAltCliente != 0);
                        break;
                    case 21:    // Alterar dados Categorias
                        int auxMenuAltCat = -1;
                        int idCat = 0;
                        if (RegrasNegocio.NumMarcas() < 1)
                        {
                            IO.EscreverMensagem("Nao existem categorias Criadas!");
                            IO.ReadKey();
                            break;
                        }
                        IO.ClearConsole();
                        IO.ListaCategorias();
                        IO.EscreverMensagem("Escolha o Id da categoria que deseja alterar: ");
                        do
                        {
                            idCat = IO.LerInt();
                        } while (!RegrasNegocio.ExisteCategoriaPorId(idCat));
                        do
                        {
                            IO.ClearConsole();
                            IO.MenuAlterarCategoria();
                            auxMenuAltCat = IO.LernumeroMenuCategoria();
                            switch (auxMenuAltCat)
                            {
                                case 0:
                                    break;
                                case 1:     //Alterar Nome
                                    string NovoNome;
                                    IO.EscreverMensagem("Indique o novo nome");
                                    NovoNome = IO.LerString();
                                    bool aux1 = RegrasNegocio.AlterarNomeCategoria(idCat, NovoNome);
                                    if (aux1)
                                        IO.EscreverMensagem("Nome Alterado com sucesso! ");
                                    else
                                        IO.EscreverMensagem("Ocurreu um erro ao alterar o nome!");
                                    IO.ReadKey();
                                    break;
                                default:
                                    IO.EscreverMensagem("Default, algo errou!!!");
                                    break;
                            }
                        } while (auxMenuAltCat != 0);
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