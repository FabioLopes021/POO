using InOut;
using RN;
using System;

namespace Programa
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Carregadados
            
            
            try
            {
                RegrasNegocio.CarregarCategorias("Categorias");
            }
            catch (Exception e)
            {
                IO.EscreverMensagem(e.Message);
            }

            try
            {
                RegrasNegocio.CarregarClientes("Clientes");
            }
            catch (Exception e)
            {
                IO.EscreverMensagem(e.Message);
            }

            try
            {
                RegrasNegocio.CarregarCompras("Compras");
            }
            catch (Exception e)
            {
                IO.EscreverMensagem(e.Message);
            }

            try
            {
                RegrasNegocio.CarregarFornecedores("Fornecedores");
            }
            catch (Exception e)
            {
                IO.EscreverMensagem(e.Message);
            }
            
            try
            {
                RegrasNegocio.CarregarMarcas("Marcas");
            }
            catch (Exception e)
            {
                IO.EscreverMensagem(e.Message);
            }
            
            try
            {
                RegrasNegocio.CarregarStock("Stock");
            }
            catch (Exception e)
            {
                IO.EscreverMensagem(e.Message);
            }

            try
            {
                RegrasNegocio.CarregarVendas("Vendas");
            }
            catch (Exception e)
            {
                IO.EscreverMensagem(e.Message);
            }
            
            #endregion



            MenuTestes.MenuRunner();



            #region guardarDados
            
            try
            {
                RegrasNegocio.GuardarCategorias("Categorias");
            }
            catch (Exception e)
            {
                IO.EscreverMensagem(e.Message);
            }

            try
            {
                RegrasNegocio.GuardarClientes("Clientes");
            }
            catch (Exception e)
            {
                IO.EscreverMensagem(e.Message);
            }

            try
            {
                RegrasNegocio.GuardarCompras("Compras");
            }
            catch (Exception e)
            {
                IO.EscreverMensagem(e.Message);
            }

            try
            {
                RegrasNegocio.GuardarFornecedores("Fornecedores");
            }
            catch (Exception e)
            {
                IO.EscreverMensagem(e.Message);
            }
            
            try
            {
                RegrasNegocio.GuardarMarcas("Marcas");
            }
            catch (Exception e)
            {
                IO.EscreverMensagem(e.Message);
            }
            
            try
            {
                RegrasNegocio.GuardarStock("Stock");
            }
            catch (Exception e)
            {
                IO.EscreverMensagem(e.Message);
            }

            try
            {
                RegrasNegocio.GuardarVendas("Vendas");
            }
            catch (Exception e)
            {
                IO.EscreverMensagem(e.Message);
            }
            
            
            #endregion


        }
    }
}
