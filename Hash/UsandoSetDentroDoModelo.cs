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

        Aluno a1 = new Aluno("Vanessa Tonini", 34672);
        Aluno a2 = new Aluno("Ana Losnak", 5617);
        Aluno a3 = new Aluno("Rafael Nercessian", 17645);

        csharpColecoes.Matricula(a1);
        csharpColecoes.Matricula(a2);
        csharpColecoes.Matricula(a3);

        Console.WriteLine("Imprimindo os alunos matriculados");
        foreach (var aluno in csharpColecoes.Alunos)
        {
            Console.WriteLine(aluno);
        }

        Console.WriteLine($"O aluno a1 {a1.Nome} está matriculado?");

        //Criar um método EstaMatriculado
        Console.WriteLine(csharpColecoes.EstaMatriculado(a1));

        //vamos instanciar uma aluna (Vanessa Tonini)
        Aluno tonini = new Aluno("Vanessa Tonini", 34672);
        //e verificar se Tonini está matriculada
        Console.WriteLine("Tonini está matriculada? " + csharpColecoes.EstaMatriculado(tonini));


        Console.WriteLine("a1 é equals a Tonini?");
        Console.WriteLine(a1.Equals(tonini));
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

        private ISet<Aluno> alunos = new HashSet<Aluno>();
        public IList<Aluno> Alunos
        {
            get
            {
               // Ao fazermos isto, o programa nos informa que alunos não pode ser convertido para um ISet<>, pois estamos trabalhando 
               //com IList<>. Faremos uma conversão de um HashSet para uma lista chamando o método ToList().
                //return new ReadOnlyCollection<Aluno>(alunos);
                return new ReadOnlyCollection<Aluno>(alunos.ToList());
            }
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

        public void Matricula(Aluno aluno)
        {
            alunos.Add(aluno);
        }

        public bool EstaMatriculado(Aluno aluno)
        {
            return alunos.Contains(aluno);
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
}

/*
Lambda Expressions
Uma expressão lambda é uma função anônima (isto é, um método sem nome) que permite criar uma expressão inline, 
ou em linha, sem a necessidade de referenciar um método externo.

Uma expressão lambda contém três partes:

o parâmetro (aula)
o operador lambda (=>)
o corpo do método anônimo ({ Console.WriteLine(aula); })

===============================================================
#####  Tabela de Dispersao(Olhar na paste de imagem) ###########
===============================================================

Conseguimos superar a comparação default .NET Framework simplesmente implementando o Equals(). Porém, cuidado: sempre que o implementamos,
 precisaremos fazer o mesmo com o hash code.

No início da classe Aluno, veremos como observação, um alerta que indica que esta classe sobrescreve o Equals() mas não o GetHashCode.
O que isto significa?

Trata-se de um código de dispersão, ou espalhamento. A imagem abaixo representa o nosso conjunto de alunos, que são convertidos 
internamente no HashSet para códigos. Estes cairão em uma tabela de dispersão, também conhecida por HashTable, responsável 
por informar as "caixinhas" em que estes conjuntos de alunos cairão.



Quer dizer que quanto maior a dispersão, ou mais espalhado forem as caixinhas, maior será a eficiência no algoritmo de busca para posterior comparação ou verificação de um elemento em um objeto. Como podemos ver na imagem, todos os alunos caíram em caixas diferentes, com exceção do Rafael Rollo e do Rafael Nercessian, que caíram em 152 (o HashCode gerado, o tal do código de dispersão), em que ocorreu uma colisão de códigos.

Uma colisão indica que dois ou mais elementos estão caindo no mesmo grupo. Nisso, verifica-se se o elemento está realmente contido naquela caixa e, paralelamente, todos os seus elementos são varridos. Ou seja, para verificar se o Rafael Nercessian está contido em uma caixa específica, por exemplo, passamos primeiro pelo Rafael Rollo. É como se uma "segunda etapa" tivesse acontecido.

Poderíamos ter muitos elementos em uma única caixa, deixando nosso código menos eficiente. Então, via de regra, ao implementarmos o método Equals(), fazemos o mesmo com o GetHashCode para que a dispersão aconteça corretamente. Reforçando também que a rapidez de busca depente do código de dispersão.

Para implementarmos este código de dispersão (GetHashCode), utilizaremos o override para sobrescrita. Como boa prática, seguiremos o mesmo conceito do Equals(), que compara nome com nome. Em Alunos.cs:

public override int GetHashCode()
{
    return this.nome.GetHashCode();
}
Futuramente trabalharemos com dicionários, também beneficiados por este código de dispersão.

Outra informação importante é que dois objetos iguais possuem o mesmo hash code, porém o inverso nem sempre é verdadeiro, ou seja, dois objetos com mesmo hash code não são necessariamente iguais.

 */