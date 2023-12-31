using Dados;
using ObjetosNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesUnitarios
{
    internal class TestesFornecedores
    {

        public void Setup()
        {
            Fornecedores.LimparLista();
        }


        [Test, Order(1)]
        public void Dados_Fornecedores_RegistarFornecedor_ReturnTrue()
        {
            //Arrange
            Fornecedor forn = new Fornecedor("Teste","Braga",321,123123);

            //Act
            bool resultado = Fornecedores.RegistarFornecedor(forn);

            //Assert
            Assert.IsTrue(resultado);
        }


        [Test, Order(2)]
        public void Dados_Fornecedores_AlterarNomeFornecedor_ReturnTrue()
        {
            //Arrange
            Fornecedor forn = new Fornecedor("Teste", "Braga", 321, 123123);
            Fornecedores.RegistarFornecedor(forn);

            //Act
            bool resultado = Fornecedores.AlterarNomeFornecedor(1, "Novo");

            //Assert
            Assert.IsTrue(resultado);
        }


        [Test, Order(3)]
        public void Dados_Fornecedores_RemoverFornecedor_ReturnTrue()
        {
            //Arrange
            Fornecedor forn = new Fornecedor("Teste", "Braga", 321, 123123);
            Fornecedores.RegistarFornecedor(forn);

            //Act
            bool resultado = Fornecedores.RemoverFornecedor(forn.Id);

            //Assert
            Assert.IsTrue(resultado);
        }
    }
}
