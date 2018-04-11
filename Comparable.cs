using System;
using System.Collections.Generic;
using System.Linq;


namespace UsandoThreads_4
{
    class Program
    {
       static void Main(string[] args)
      {
        var aulaIntro = new Aula("Introdução às Coleções", 20);
        var aulaModelando = new Aula("Modelando a Classe Aula", 18);
        var aulaSets = new Aula("Trabalhando com Conjuntos", 16);
    
        List<Aula> aulas = new List<Aula>();
        aulas.Add(aulaIntro);
        aulas.Add(aulaModelando);
        aulas.Add(aulaSets);
        //aulas.Add("Conclusão");
        aulas.Sort();
        Imprimir(aulas);
        
        aulas.Sort((este, outro) => este.Tempo.CompareTo(outro.Tempo));
        Imprimir(aulas);
      }
      
      private static void Imprimir(List<Aula> aulas)
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
            set{ titulo = value; }
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
}

/*
HTTP Request Life Cycle

https://www.tutorialspoint.com/aspnet_online_training/aspnet_introduction_to_iis.asp

https://www.c-sharpcorner.com/article/what-is-new-in-net-core-2-0/
https://www.c-sharpcorner.com/technologies/deployment




gamil


asp.net mvc pipeline 

https://www.youtube.com/watch?v=t9CAhBPRK4U
*/
