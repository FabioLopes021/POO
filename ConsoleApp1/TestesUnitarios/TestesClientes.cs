using Dados;
using ObjetosNegocio;

namespace TestesUnitarios
{
    internal class TestesClientes
    {

        [SetUp]
        public void Setup()
        {
            Clientes.LimparLista();
        }

        [Test, Order(1)]
        public void Dados_Clientes_RegistarCliente_ReturnTrue()
        {
            //Arrange
            Cliente cli = new Cliente("Teste","barcelos", 123, 123456);

            //Act
            bool resultado = Clientes.RegistarCliente(cli);

            //Assert
            Assert.IsTrue(resultado);
        }


        [Test, Order(2)]
        public void Dados_Clientes_AlterarNomeCliente_ReturnTrue()
        {
            //Arrange
            Cliente cli = new Cliente("Teste", "barcelos", 123, 123456);
            Clientes.RegistarCliente(cli);

            //Act
            bool resultado = Clientes.AlterarNomeCliente(1, "Novo");

            //Assert
            Assert.IsTrue(resultado);
        }


        [Test, Order(3)]
        public void Dados_Clientes_RemoverCliente_ReturnTrue()
        {
            //Arrange
            Cliente cli = new Cliente("Teste", "barcelos", 123, 123456);
            Clientes.RegistarCliente(cli);

            //Act
            bool resultado = Clientes.RemoverCliente(cli.Id);

            //Assert
            Assert.IsTrue(resultado);
        }

    }
}
