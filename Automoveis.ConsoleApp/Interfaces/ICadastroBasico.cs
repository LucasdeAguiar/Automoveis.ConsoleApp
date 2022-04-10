using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automoveis.ConsoleApp.Interfaces
{
    public interface ICadastroBasico
    {
        void InserirRegistro();
        void EditarRegistro();
        void ExcluirRegistro();
        bool VisualizarRegistros(string tipoVisualizado);


    }
}
