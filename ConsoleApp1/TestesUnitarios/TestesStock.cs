using Dados;
using Excecoes;
using ObjetosNegocio;
using System.Diagnostics;

namespace TestesUnitarios
{
    internal class TestesStock
    {
        [SetUp]
        public void Setup()
        {
            Stock.LimparLista();
            Marcas.LimparLista();
            Categorias.LimparLista();
        }

        [Test, Order(1)]
        public void Dados_Stock_RemoverProduto_ReturnTrue()
        {

            //Arrange
            Categoria cat = new Categoria("Geral");
            Marca mar = new Marca("Barcelos", "Nike");
            Produto prod = new Produto("Teste", (float)14.60, 2, 1, 1);

            //Act
            Marcas.GuardarMarca(mar);
            Categorias.GuardarCategoria(cat);
            Stock.AdicionarProduto(prod);
            bool resultado = Stock.RemoverProduto(1);

            //Assert
            Assert.IsTrue(resultado);
        }

        [Test, Order(2)]
        public void Dados_Stock_AdicionarProduto_LancaStockExcecoes()
        {
            //Arrange
            Produto prod = new Produto("Teste", (float)14.60, 2, 2, 2);


            //Assert
            Assert.Throws<StockExcecoes>(() => Stock.AdicionarProduto(prod));
        }


        [Test, Order(3)]
        public void Dados_Stock_AumentarQuantidade_ReturnTrue()
        {

            //Arrange
            Marca mar = new Marca("Barcelos", "Nike");
            Marcas.GuardarMarca(mar);
            Categoria cat = new Categoria("Geral");
            Categorias.GuardarCategoria(cat);
            Produto p = new Produto("Teste1", (float)10.1,2,1,1);
            Stock.AdicionarProduto(p);


            //Act
            Stock.AumentarQuantidade(p.Id, (float)10.0);


            //Assert
            Assert.That(actual: p.Quantidade, Is.EqualTo(expected: (float)10.0));
        }


        [Test, Order(4)]
        public void Dados_Stock_AlterarNomeProduto_ReturnTrue(){
            //Arrange
            Marca mar = new Marca("Barcelos", "Nike");
            Marcas.GuardarMarca(mar);
            Categoria cat = new Categoria("Geral");
            Categorias.GuardarCategoria(cat);
            Produto p = new Produto("Teste1", (float)10.1, 2, 1, 1);
            Stock.AdicionarProduto(p);

            //Act
            bool resultado = Stock.AlterarNomeProduto(p.Id,"Novo");


            //Assert
            Assert.IsTrue(resultado);
        }



    }
}
