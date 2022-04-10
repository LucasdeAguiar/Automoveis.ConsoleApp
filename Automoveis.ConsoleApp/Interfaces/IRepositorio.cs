using Automoveis.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automoveis.ConsoleApp.Interfaces
{
    public interface IRepositorio
    {
        string Inserir(EntidadeBase entidade);
        bool Editar(int numeroSelecionado, EntidadeBase novaEntidade);
        bool Excluir(int numeroSelecionado);
    

    }
}
