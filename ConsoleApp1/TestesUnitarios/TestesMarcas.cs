using Dados;
using Excecoes;
using ObjetosNegocio;


namespace TestesUnitarios
{
    internal class TestesMarcas
    {

        [SetUp]
        public void Setup()
        {
            Marcas.LimparLista();
        }

        [Test, Order(1)]
        public void Dados_Marcas_GuardarMarca_ReturnTrue()
        {
            //Arrange
            Marca marca = new Marca("Barcelos","Teste");

            //Act
            bool resultado = Marcas.GuardarMarca(marca);

            //Assert
            Assert.IsTrue(resultado);
        }


        [Test, Order(2)]
        public void Dados_Marcas_AlterarNomeMarca_ReturnTrue()
        {
            //Arrange
            Marca marca = new Marca("Barcelos", "Teste");
            Marcas.GuardarMarca(marca);

            //Act
            bool resultado = Marcas.AlterarNomeMarca(1,"Marca");

            //Assert
            Assert.IsTrue(resultado);
        }

    }
}
