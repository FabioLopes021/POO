using Dados;
using Excecoes;
using ObjetosNegocio;

namespace TestesUnitarios
{
    public class Tests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Dados_Stock_AdicionarProduto_LancaStockExcecoes() 
        {

            //Arrange
            Produto prod = new Produto("Teste", (float)14.60, 2, 1, 1);

            //Act

            //Assert
            Assert.Throws<StockExcecoes>(() => Stock.AdicionarProduto(prod));
        }

        
        [Test]
        public void Dados_Stock_AdicionarProduto_LancaStockExcecoes1()
        {

            //Arrange
            Categoria cat = new Categoria("Geral");
            Produto prod = new Produto("Teste", (float)14.60, 2, 1, 1);
            Categorias.guardarCategoria(cat);

            //Act

            //Assert
            Assert.Throws<StockExcecoes>(() => Stock.AdicionarProduto(prod));
        }


        [Test]
        public void Dados_Stock_AdicionarProduto_LancaStockExcecoes2()
        {

            //Arrange
            Marca mar = new Marca("Barcelos","Nike");
            Produto prod = new Produto("Teste", (float)14.60, 2, 1, 1);
            Marcas.GuardarMarca(mar);

            //Act
            bool resultado = Stock.AdicionarProduto(prod);

            //Assert
            Assert.IsTrue(resultado);
        }

    }
}