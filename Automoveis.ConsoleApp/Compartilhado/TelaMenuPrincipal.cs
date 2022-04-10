using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automoveis.ConsoleApp.ModuloCarro;




namespace Automoveis.ConsoleApp.Compartilhado
{
    public class TelaMenuPrincipal
    {
        #region atributos

        private string opcaoSelecionada;

        private const int QUANTIDADE_REGISTROS = 10;

        private Notificador notificador;

        #endregion

        #region declaração de carros
        private RepositorioCarro repositorioCarro;
        private TelaCadastroCarro telaCadastroCarro;
        #endregion

        #region constructs
        public TelaMenuPrincipal(Notificador notificador)
        {
            this.notificador = notificador;

            repositorioCarro = new RepositorioCarro();
            telaCadastroCarro = new TelaCadastroCarro(repositorioCarro , notificador);

        }

        #endregion

        #region métodos públicos
        public string MostrarOpcoes()
        {
            Console.Clear();

            Console.WriteLine("Venda de móveis 1.0");

            Console.WriteLine();

            Console.WriteLine("Digite 1 para Cadastrar Carros");
            Console.WriteLine("Digite s para sair");

            opcaoSelecionada = Console.ReadLine();

            return opcaoSelecionada;
        }

        public Telabase obterTela()
        {
            string opcao = MostrarOpcoes();

            Telabase tela = null;

            switch (opcao)
            {
                case "1":
                    tela = telaCadastroCarro;
                    break;     
                    
            }

            return tela;
        }

        #endregion
    }
}
