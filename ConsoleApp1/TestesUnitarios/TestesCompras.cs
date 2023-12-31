using Dados;
using ObjetosNegocio;


namespace TestesUnitarios
{
    internal class TestesCompras
    {
        [SetUp]
        public void Setup()
        {
            Compras.LimparLista();
            Fornecedores.LimparLista();
            Stock.LimparLista();
            Marcas.LimparLista();
            Categorias.LimparLista();
        }

        [Test, Order(1)]
        public void ObjetosNegocio_Compra_AdicionarProdutoCompra_IsTrue()
        {
            //Arrange
            Fornecedor forn = new Fornecedor("Teste", "Braga", 321, 123123);
            Fornecedores.RegistarFornecedor(forn);
            Categoria cat = new Categoria("Geral");
            Categorias.GuardarCategoria(cat);
            Marca mar = new Marca("Barcelos", "Nike");
            Marcas.GuardarMarca(mar);
            Produto prod = new Produto("Teste", (float)14.60, 2, 1, 1);
            Stock.AdicionarProduto(prod);
            Compra comp = new Compra(DateTime.Now, forn.Id);


            //Act
            bool resultado = comp.AdicionarProdutoCompra(prod.Id,10);

            //Assert
            Assert.IsTrue(resultado);
        }

        [Test, Order(2)]
        public void ObjetosNegocio_Compra_RemoverProdutoCompra_IsTrue()
        {
            //Arrange
            Fornecedor forn = new Fornecedor("Teste", "Braga", 321, 123123);
            Fornecedores.RegistarFornecedor(forn);
            Categoria cat = new Categoria("Geral");
            Categorias.GuardarCategoria(cat);
            Marca mar = new Marca("Barcelos", "Nike");
            Marcas.GuardarMarca(mar);
            Produto prod = new Produto("Teste", (float)14.60, 2, 1, 1);
            Stock.AdicionarProduto(prod);
            Compra comp = new Compra(DateTime.Now, forn.Id);
            comp.AdicionarProdutoCompra(prod.Id, 10);

            //Act
            bool resultado = comp.RemoverProdutoCompra(prod.Id, 5);

            //Assert
            Assert.IsTrue(resultado);
        }


        [Test, Order(3)]
        public void ObjetosNegocio_Compra_VerificaProdutoCompra_IsFalse()
        {
            //Arrange
            Fornecedor forn = new Fornecedor("Teste", "Braga", 321, 123123);
            Fornecedores.RegistarFornecedor(forn);
            Categoria cat = new Categoria("Geral");
            Categorias.GuardarCategoria(cat);
            Marca mar = new Marca("Barcelos", "Nike");
            Marcas.GuardarMarca(mar);
            Produto prod = new Produto("Teste", (float)14.60, 2, 1, 1);
            Stock.AdicionarProduto(prod);
            Compra comp = new Compra(DateTime.Now, forn.Id);

            //Act
            bool resultado = comp.VerificaProdutoCompra(prod.Id);

            //Assert
            Assert.IsFalse(resultado);
        }


        [Test, Order(4)]
        public void ObjetosNegocio_Compra_VerificaProdutoCompra_IsTrue()
        {
            //Arrange
            Fornecedor forn = new Fornecedor("Teste", "Braga", 321, 123123);
            Fornecedores.RegistarFornecedor(forn);
            Categoria cat = new Categoria("Geral");
            Categorias.GuardarCategoria(cat);
            Marca mar = new Marca("Barcelos", "Nike");
            Marcas.GuardarMarca(mar);
            Produto prod = new Produto("Teste", (float)14.60, 2, 1, 1);
            Stock.AdicionarProduto(prod);
            Compra comp = new Compra(DateTime.Now, forn.Id);
            comp.AdicionarProdutoCompra(prod.Id, 10);


            //Act
            bool resultado = comp.VerificaProdutoCompra(prod.Id);

            //Assert
            Assert.IsTrue(resultado);
        }


        [Test, Order(5)]
        public void Dados_Compras_RegistarCompra_IsTrue()
        {
            //Arrange
            Fornecedor forn = new Fornecedor("Teste", "Braga", 321, 123123);
            Fornecedores.RegistarFornecedor(forn);
            Categoria cat = new Categoria("Geral");
            Categorias.GuardarCategoria(cat);
            Marca mar = new Marca("Barcelos", "Nike");
            Marcas.GuardarMarca(mar);
            Produto prod = new Produto("Teste", (float)14.60, 2, 1, 1);
            Stock.AdicionarProduto(prod);
            Compra comp = new Compra(DateTime.Now, forn.Id);
            comp.AdicionarProdutoCompra(prod.Id, 10);


            //Act
            bool resultado = Compras.RegistarCompra(comp);

            //Assert
            Assert.IsTrue(resultado);
        }

    }
}
