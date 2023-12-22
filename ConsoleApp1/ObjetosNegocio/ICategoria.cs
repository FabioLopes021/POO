using Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetosNegocio
{
    internal interface ICategoria
    {

        /// <summary>
        /// Propriedade para aceder a variavel nome
        /// </summary>
        string Nome
        {
            get;
            set;
        }


        /// <summary>
        /// Propriedade para aceder a variavel id
        /// </summary>
        int Id
        {
            get;
        }


        /// <summary>
        /// Funçao para calcular id a ser atribuido a cada Categoria a ser criada
        /// </summary>
        /// <returns></returns>
        int AtribuirId();

    }
}
