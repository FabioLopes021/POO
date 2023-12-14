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

        string Nome
        {
            get;
            set;
        }

        int Id
        {
            get;
        }


        string ToString();


        /// <summary>
        /// Funçao para calcular id a ser atribuido a cada Categoria a ser criada
        /// </summary>
        /// <returns></returns>
        int AtribuirId();



    }
}
