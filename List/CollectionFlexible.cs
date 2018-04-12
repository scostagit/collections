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
        Curso csharpColecoes = new Curso("C# Collections", "Marcelo Oliveira");
        csharpColecoes.Adiciona(new Aula("Trabalhando com Listas", 21));

         //adicionar 2 aulas
        csharpColecoes.Adiciona(new Aula("Criando uma Aula", 20));
        csharpColecoes.Adiciona(new Aula("Modelando com Coleções", 19));

        //ordenar a lista de aulas
       //csharpColecoes.Aulas.Sort();

       //copiar a lista para outra lista
        List<Aula> aulasCopiadas = new List<Aula>(csharpColecoes.Aulas);

        //ordenar a cópia
        aulasCopiadas.Sort();
        //Imprimir
        //Imprimir(csharpColecoes.Aulas);
        Imprimir(aulasCopiadas);

        Console.WriteLine(csharpColecoes.TempoTotal);
        Console.WriteLine(csharpColecoes);
      }
      
      private static void Imprimir(IList<Aula> aulas)
        {
            Console.Clear();
            foreach (var aula in aulas)
            {
                Console.WriteLine(aula);
            }
        }
    }
    
    public class Aula : IComparable
    {
        private string titulo;
        private int tempo;
    
        public Aula(string titulo, int tempo)
        {
            this.titulo = titulo;
            this.tempo = tempo;
        }
    
        public string Titulo { 
            get { return  titulo; } 
            set { titulo = value; }
        }

        public int Tempo {
            get { return tempo;}  
            set { tempo = value; }        
        }
        
        public override string ToString()
        {
            return $"[título: {titulo}, tempo: {tempo} minutos]";
        }
        
        public int CompareTo(object obj)
        {
            Aula that = obj as Aula;
            return this.titulo.CompareTo(that.titulo);
        }
    }
    
    public class Curso
    {
        private IList<Aula> aulas;
        /*
        Aulas é o campo privado que está sendo protegido, porém o Visual Studio não consegue converter ReadOnlyCollection para 
        um List<Aula>, declarado na propriedade. Portanto, precisaremos trocá-lo por um IList<Aula>, que é o que o ReadOnlyCollection implementa
        */
        public IList<Aula> Aulas
        {
            get { return new ReadOnlyCollection<Aula>(aulas); }
        }
        
        //agora a classe curso estsa controlando a listagem
        public void Adiciona (Aula aula)
        {
            this.aulas.Add(aula);
        }

        private string nome;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        private string instrutor;

        public string Instrutor
        {
            get { return instrutor; }
            set { instrutor = value; }
        }

        public int TempoTotal
        {
            get
            {
                /*int total = 0;
                foreach (var aula in aulas)
                {
                    total += aula.Tempo;
                }
                return total;*/
                return aulas.Sum(aula => aula.Tempo);
            }
        }
        
        public Curso(string nome, string instrutor)
        {
            this.nome = nome;
            this.instrutor = instrutor;
            this.aulas = new List<Aula>();
        }

        public override string ToString()
        {
            return $"Curso: {nome}, Tempo: {TempoTotal}, Aulas: {string.Join(",", aulas)}";
        }
    }
}

/*
Lambda Expressions
Uma expressão lambda é uma função anônima (isto é, um método sem nome) que permite criar uma expressão inline, 
ou em linha, sem a necessidade de referenciar um método externo.

Uma expressão lambda contém três partes:

o parâmetro (aula)
o operador lambda (=>)
o corpo do método anônimo ({ Console.WriteLine(aula); })
 */