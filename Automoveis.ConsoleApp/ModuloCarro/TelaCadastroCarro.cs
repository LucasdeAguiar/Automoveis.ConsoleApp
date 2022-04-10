using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automoveis.ConsoleApp.Compartilhado;
using Automoveis.ConsoleApp.Interfaces;

namespace Automoveis.ConsoleApp.ModuloCarro
{
    public class TelaCadastroCarro : Telabase , ICadastroBasico
    {

        #region atributos
        private readonly Notificador notificador;
        private readonly RepositorioCarro repositorioCarro;
        #endregion

      
        public TelaCadastroCarro(RepositorioCarro repositorioCarro , Notificador notificador): base("Cadastro de Carros")
        {
            this.repositorioCarro = repositorioCarro;
            this.notificador = notificador;
        }
    

        #region métodos publicos
        public override string MostrarOpcoes()
        {
            MostrarTitulo(Titulo);


            Console.WriteLine("Digite 1 para Inserir");
            Console.WriteLine("Digite 2 para Editar");
            Console.WriteLine("Digite 3 para Excluir");
            Console.WriteLine("Digite 4 para Visualizar");
     

            Console.WriteLine("Digite s para sair");

            string opcao = Console.ReadLine();

            return opcao;


        }

       
        public void InserirRegistro()
        {
            MostrarTitulo("Inserindo novo Carro");
            Carro carro = obterCarro();

            repositorioCarro.Inserir(carro);

            
        }

        public void EditarRegistro()
        {
            MostrarTitulo("Editando Carro");

            int numeroCarro = ObterNumeroCarro();

            Carro carroAtualizado = obterCarro();

            repositorioCarro.Editar(numeroCarro, carroAtualizado);

            notificador.apresentarMensagem("Carro editado com sucesso", TipoMensagem.Sucesso);

        }

        public void ExcluirRegistro()
        {
            MostrarTitulo("Excluindo Carro");

            bool temCarrosCadastrados = VisualizarRegistros("Pesquisando:");

            if (temCarrosCadastrados == false)
            {
                notificador.apresentarMensagem("Nenhum carro cadastrado..", TipoMensagem.Atencao);
                return;
            }

            int numeroCarro = ObterNumeroCarro();

            repositorioCarro.Excluir(numeroCarro);

            notificador.apresentarMensagem("Carro excluído com sucesso", TipoMensagem.Sucesso);

        }

        public bool VisualizarRegistros(string tipo)
        {
            if (tipo == "Tela")
                MostrarTitulo("Visualização de Carros");

            List<EntidadeBase> carros = repositorioCarro.SelecionarTodos();

            if (carros.Count == 0)
                return false;
            
            for (int i = 0; i < carros.Count; i++)
            {
                Carro carro = (Carro)carros[i];

                Console.WriteLine("Nome: " + carro.Nome);
                Console.WriteLine("Modelo: " + carro.Modelo);
                Console.WriteLine("Cor: " + carro.Cor);
                Console.WriteLine("Placa: " + carro.Placa);
                Console.WriteLine("\n");
                
            }
            Console.ReadLine();
            return true;
        }

        #endregion

        #region métodos privados

        private Carro obterCarro()
        {
            Console.WriteLine("Digite o nome do carro:");
             string nome = Console.ReadLine();
            Console.WriteLine("Digite o modelo do carro: ");
             string modelo  = Console.ReadLine();
            Console.WriteLine("Digite a cor do carro: " );
             string cor = Console.ReadLine();
            Console.WriteLine("Digite a placa do carro");
             string placa = Console.ReadLine();

            Carro c = new Carro(nome,modelo,cor,placa);

            return c;
        }

        private int ObterNumeroCarro()
        {
            int numeroCarro;
            bool numeroCarroEncontrado;

            do
            {
                List<EntidadeBase> carros = repositorioCarro.SelecionarTodos();

            
                    

                for (int i = 0; i < carros.Count; i++)
                {
                    Carro carro = (Carro)carros[i];

                    Console.WriteLine("Número: " + carro.numero);
                    Console.WriteLine("Nome: " + carro.Nome);
                    Console.WriteLine("Modelo: " + carro.Modelo);
                    Console.WriteLine("Cor: " + carro.Cor);
                    Console.WriteLine("Placa: " + carro.Placa);
                    Console.WriteLine("\n");

                }

                Console.Write("Digite o número do carro que deseja selecionar: ");
                 numeroCarro = Convert.ToInt32(Console.ReadLine());

                numeroCarroEncontrado = repositorioCarro.ExisteRegistro(numeroCarro);

                if (numeroCarroEncontrado == false)
                    notificador.apresentarMensagem("Número do carro não encontrado, tente novamente..", TipoMensagem.Atencao);

            } while (numeroCarroEncontrado == false);

            return numeroCarro; 
        }

        #endregion
    }
}
