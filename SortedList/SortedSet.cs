using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Collections
{
    class Program
    {      
        static void Main(string[] args)
        {
            //Conjunto de alunos:
            //HashSet nao ordenado
            //SortedSet: conjunto ordanedo
            //ISet<string> alunos = new HashSet<string>()
            ISet<string> alunos = new SortedSet<string>()
            {
                "Vanessa Tonini",
                "Ana Losnak",
                "Rafael Nercessian",
                "Priscila Stuani"
            };

            //adicionar: Rafael Rollo
            alunos.Add("Rafael Rollo");
            //adicionar: Fabio Gushiken
            alunos.Add("Fabio Gushiken");
            //adicionar: FABIO GUSHIKEN
            alunos.Add("FABIO GUSHIKEN");

            /*
             alunos.Add("FABIO GUSHIKEN");
            Surgirá uma caixa de texto onde veremos a listagem dos alunos. No caso do nome minúsculo e maiúsculo, o programa não 
            identificou como sendo o mesmo nome. Veremos adiante, como podemos evitar isso.
             */

            foreach (var aluno in alunos)
            {
                Console.WriteLine(aluno);
            }
        }
    }

    public class Aluno
    {
        private string nome;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        private int numeroMatricula;

        public int NumeroMatricula
        {
            get { return numeroMatricula; }
            set { numeroMatricula = value; }
        }

        public Aluno(string nome, int matricula )
        {
            this.Nome = nome;
            this.numeroMatricula = matricula;
        }

        public override string ToString()
        {
            return $"[Nome: {nome}, Matrícula: {numeroMatricula}]";
        }

        public override bool Equals(object obj)
        {
            Aluno outro = obj as Aluno;

            if (outro == null)
            {
                return false;
            }

            return this.nome.Equals(outro.nome);
        }
        public override int GetHashCode()
        {
            return this.nome.GetHashCode();
        }
    }

    //Classe para implentar a sobrecarga do metodo Compare da classe SortedSet.
    public class ComparadorMinusculo : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return string.Compare(x, y, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}