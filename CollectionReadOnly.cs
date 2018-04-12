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
        Imprimir(csharpColecoes.Aulas);
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
        
        public Curso(string nome, string instrutor)
        {
            this.nome = nome;
            this.instrutor = instrutor;
            this.aulas = new List<Aula>();
        }
    }
}

/*
Conseguimos criar a classe Curso com sucesso, populando e imprimindo as aulas. No entanto, há um problema não muito evidente, 
conhecido por code smell na programação, ou "mau cheiro no código", que neste caso implica no fato de acessarmos csharpColecoes.
Aulas e a lista de aulas da classe Curso adicionando elementos nela.

Isso significa que estamos "passando por cima" da responsabilidade da classe Curso de manter suas propriedades, e 
estamos manipulando diretamente 
esta lista de aulas.

O correto seria chamarmos um método da classe Curso para podermos adicionar estes elementos. Caso contrário, esta classe não tem nenhum controle 
sobre as suas aulas, pois esta listagem está exposta.

Trata-se de um code smell por ser uma "exposição indecente". Para evitarmos que uma propriedade fique exposta à manipulações externas,
é necessário encapsularmos esta funcionalidade de adicionar elementos na lista.

Então, primeiramente, teremos que bloquear esta lista interna para evitar a possibilidade de manipulação por código externo. Acessando-se a classe 
Curso, modificaremos a propriedade Aulas, em que encontramos get e set.

Removeremos o set, pois do jeito que está, qualquer um pode alterá-lo para um valor nulo, e a classe Curso perde qualquer 
chance de barrar esta modificação. Feito isso, retornaremos não mais uma lista de aulas (List<Aula>) em get, mas outro tipo de objeto, 
uma coleção somente leitura (read only collection).

ReadOnlyCollection se localiza no .NET com namespace System.Collections.ObjectModel, e é uma classe genérica, portanto necessita 
também do tipo de elemento (no caso, a classe Aula). Precisaremos passar no construtor um parâmetro que é uma lista, a própria
 referência das aulas.

Error:
Veremos outro problema, desta vez na hora de chamarmos o método Imprimir(), pois estamos passando uma propriedade de tipo IList<>, 
e nosso método recebe List<>. Precisaremos fazer a devida alteração.

Feito isso, rodaremos a aplicação! Há um erro: System.NotSupportedException "Coleção é somente leitura". Protegemos nossa coleção para que ela 
fosse somente leitura, e assim, o código externo fica impedido de modificar esta coleção.

*/