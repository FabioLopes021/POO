

using Dados;
using ObjetosNegocio;

namespace TestesUnitarios
{
    internal class TestesVendas
    {
        [SetUp]
        public void Setup()
        {
            Compras.LimparLista();
            Clientes.LimparLista();
            Stock.LimparLista();
            Marcas.LimparLista();
            Categorias.LimparLista();
        }

        [Test, Order(1)]
        public void ObjetosNegocio_Venda_AdicionarProdutoVenda_ReturnTrue()
        {
            //Arrange
            Cliente cli = new Cliente("Teste", "barcelos", 123, 123456);
            Clientes.RegistarCliente(cli);
            Categoria cat = new Categoria("Geral");
            Categorias.guardarCategoria(cat);
            Marca mar = new Marca("Barcelos", "Nike");
            Marcas.GuardarMarca(mar);
            Produto prod = new Produto("Teste", (float)14.60, 2, 1, 1);
            Stock.AdicionarProduto(prod);
            Venda vend = new Venda(DateTime.Now, cli.Id);


            //Act
            bool resultado = vend.AdicionarProdutoVenda(prod.Id, 10);

            //Assert
            Assert.IsTrue(resultado);
        }

        [Test, Order(2)]
        public void ObjetosNegocio_Venda_RemoverProdutoVenda_ReturnTrue()
        {
            //Arrange
            Cliente cli = new Cliente("Teste", "barcelos", 123, 123456);
            Clientes.RegistarCliente(cli);
            Categoria cat = new Categoria("Geral");
            Categorias.guardarCategoria(cat);
            Marca mar = new Marca("Barcelos", "Nike");
            Marcas.GuardarMarca(mar);
            Produto prod = new Produto("Teste", (float)14.60, 2, 1, 1);
            Stock.AdicionarProduto(prod);
            Venda vend = new Venda(DateTime.Now, cli.Id);
            vend.AdicionarProdutoVenda(prod.Id, 10);

            //Act
            bool resultado = vend.RemoverProdutoVenda(prod.Id,5);

            //Assert
            Assert.IsTrue(resultado);
        }


        [Test, Order(3)]
        public void ObjetosNegocio_Venda_VerificaProdutoVenda_ReturnFalse()
        {
            //Arrange
            Cliente cli = new Cliente("Teste", "barcelos", 123, 123456);
            Clientes.RegistarCliente(cli);
            Categoria cat = new Categoria("Geral");
            Categorias.guardarCategoria(cat);
            Marca mar = new Marca("Barcelos", "Nike");
            Marcas.GuardarMarca(mar);
            Produto prod = new Produto("Teste", (float)14.60, 2, 1, 1);
            Stock.AdicionarProduto(prod);
            Venda vend = new Venda(DateTime.Now, cli.Id);

            //Act
            bool resultado = vend.VerificaProdutoVenda(prod.Id);

            //Assert
            Assert.IsFalse(resultado);
        }


        [Test, Order(4)]
        public void ObjetosNegocio_Venda_VerificaProdutoCompra_ReturnTrue()
        {
            //Arrange
            Cliente cli = new Cliente("Teste", "barcelos", 123, 123456);
            Clientes.RegistarCliente(cli);
            Categoria cat = new Categoria("Geral");
            Categorias.guardarCategoria(cat);
            Marca mar = new Marca("Barcelos", "Nike");
            Marcas.GuardarMarca(mar);
            Produto prod = new Produto("Teste", (float)14.60, 2, 1, 1);
            Stock.AdicionarProduto(prod);
            Venda vend = new Venda(DateTime.Now, cli.Id);
            vend.AdicionarProdutoVenda(prod.Id, 10);


            //Act
            bool resultado = vend.VerificaProdutoVenda(prod.Id);

            //Assert
            Assert.IsTrue(resultado);
        }


        [Test, Order(5)]
        public void Dados_Vendas_RegistarVenda_ReturnTrue()
        {
            //Arrange
            Cliente cli = new Cliente("Teste", "barcelos", 123, 123456);
            Clientes.RegistarCliente(cli);
            Categoria cat = new Categoria("Geral");
            Categorias.guardarCategoria(cat);
            Marca mar = new Marca("Barcelos", "Nike");
            Marcas.GuardarMarca(mar);
            Produto prod = new Produto("Teste", (float)14.60, 2, 1, 1);
            Stock.AdicionarProduto(prod);
            Venda vend = new Venda(DateTime.Now, cli.Id);
            vend.AdicionarProdutoVenda(prod.Id, 10);
            prod.Quantidade = 20;

            //Act
            bool resultado = Vendas.RegistarVenda(vend);

            //Assert
            Assert.IsTrue(resultado);
        }

    }
}
