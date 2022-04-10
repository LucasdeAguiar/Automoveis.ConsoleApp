using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automoveis.ConsoleApp.Compartilhado;

namespace Automoveis.ConsoleApp.ModuloCarro
{
    public class Carro : EntidadeBase
    {
        #region atributos
        private string nome;
        private string modelo;
        private string cor;
        private string placa;

        #endregion

        #region constructs
        public Carro(string nome, string modelo, string cor, string placa)
        {
            this.nome = nome;
            this.modelo = modelo;
            this.cor = cor;
            this.placa = placa;
        }
        #endregion

        #region getters and setters
        public string Nome { get => nome; set => nome = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public string Cor { get => cor; set => cor = value; }
        public string Placa { get => placa; set => placa = value; }
        #endregion

        #region métodos
        public override void mostrarEntidade()
        {
   
            Console.WriteLine("Nome: " + Nome);
            Console.WriteLine("Modelo: " + Modelo);
            Console.WriteLine("Cor: " + Cor);
            Console.WriteLine("Placa: " + Placa);
        }
        #endregion

    }
}
