using Automoveis.ConsoleApp.Compartilhado;
using System;
using Automoveis.ConsoleApp.Interfaces;
using Automoveis.ConsoleApp.ModuloCarro;

namespace Automoveis.ConsoleApp
{
    internal class Program
    {
        static Notificador notificador = new Notificador();
        static TelaMenuPrincipal menuPrincipal = new TelaMenuPrincipal(notificador);
        static void Main(string[] args)
        {

            while (true)
            {
                Telabase telaSelecionada = menuPrincipal.obterTela();

                string opcaoSelecionada = telaSelecionada.MostrarOpcoes();

                if (telaSelecionada is ICadastroBasico)
                    GerenciarCadastroBasico(telaSelecionada, opcaoSelecionada);

               


            }



            

        }
        public static void GerenciarCadastroBasico(Telabase telaSelecionada, string opcaoSelecionada)
        {
            ICadastroBasico telaCadastroBasico = (ICadastroBasico) telaSelecionada;

            if (opcaoSelecionada == "1")
                telaCadastroBasico.InserirRegistro();

            else if (opcaoSelecionada == "2")
                telaCadastroBasico.EditarRegistro();

            else if (opcaoSelecionada == "3")
                telaCadastroBasico.ExcluirRegistro();

            else if (opcaoSelecionada == "4")
            {
                bool temRegistros = telaCadastroBasico.VisualizarRegistros("Tela");

                if (!temRegistros)
                    notificador.apresentarMensagem("Nenhum registro disponível!", TipoMensagem.Atencao);
            }

          

        }
    }
}
