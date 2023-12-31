using Dados;
using ObjetosNegocio;

namespace TestesUnitarios
{
    internal class TestesCategorias
    {
        [SetUp]
        public void Setup()
        {
            Categorias.LimparLista();
        }

        [Test, Order(1)]
        public void Dados_Categorias_GuardarMarca_ReturnTrue()
        {
            //Arrange
            Categoria cat = new Categoria("Teste");

            //Act
            bool resultado = Categorias.guardarCategoria(cat);

            //Assert
            Assert.IsTrue(resultado);
        }


        [Test, Order(2)]
        public void Dados_Categorias_AlterarNomeCategoria_ReturnTrue()
        {
            //Arrange
            Categoria cat = new Categoria("Teste");
            Categorias.guardarCategoria(cat);

            //Act
            bool resultado = Categorias.AlterarNomeCategoria(1,"Novo");

            //Assert
            Assert.IsTrue(resultado);
        }

    }
}
