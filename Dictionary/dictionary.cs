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

        Aluno a1 = new Aluno("Vanessa Tonini", 34672);
        Aluno a2 = new Aluno("Ana Losnak", 5617);
        Aluno a3 = new Aluno("Rafael Nercessian", 17645);

        csharpColecoes.Matricula(a1);
        csharpColecoes.Matricula(a2);
        csharpColecoes.Matricula(a3);

        //-----------------------------------------------------------------
            ///Aparece um erro: "Já foi adicionado um item com a mesma chave"!!
            //Aluno fabio = new Aluno("Fabio Gushiken", 5617);
            // csharpColecoes.Matricula(fabio);

            /*
                 # Chave Unica #
                Uma das características de um dicionário é justamente esta: a chave é única. Não é possível armazenar mais de um valor 
                em uma chave. Vamos comentar a linha que acabamos de criar e testar o que acontece ao substituirmos o aluno com a chave 
                5617 pelo valor do aluno fabio.
             */
        //-----------------------------------------------------------------

        //limpando o console
        Console.Clear();

        Aluno fabio = new Aluno("Fabio Gushiken", 5617);
        csharpColecoes.SubstituiAluno(fabio);

        //pergunta: "Quem é o aluno com matrícula 5617?"
        Console.WriteLine("Quem é o aluno com matrícula 5617?");
        //implementando Curso.BuscaMatriculado
        Aluno aluno5617 = csharpColecoes.BuscaMatriculado(5617);
        Console.WriteLine(aluno5617);
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
        //implementando um dicionário de alunos
        private IDictionary<int, Aluno> dicionarioAlunos = new Dictionary<int, Aluno>();

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
            //Adicionando o aluno ao dicionario
            this.dicionarioAlunos.Add(aluno.NumeroMatricula, aluno);
        }

        public bool EstaMatriculado(Aluno aluno)
        {
            return alunos.Contains(aluno);
        }

        public Aluno BuscaMatriculado(int numeroMatricula)
        {   
            //Esse implentacao quebra quando passamos um index que nao conste no dicionario
            //return this.dicionarioAlunos[numeroMatricula];

            //"tentarmos a obtenção do valor"
            Aluno aluno = null;
            this.dicionarioAlunos.TryGetValue(numeroMatricula, out aluno);
            return aluno;
        }

        public void SubstituiAluno(Aluno aluno)
        {
            this.dicionarioAlunos[aluno.NumeroMatricula] = aluno;
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
Deste modo conseguimos substituir um aluno para uma matrícula que já existia antes. 
Para terminar, veremos como um dicionário é implementado internamente. Assim como o HashSet,
 ele também faz uso de um código de dispersão. No diagrama abaixo veremos que de um lado há 
 as chaves e, do outro, os valores.
 ver images na pasta imgem

 Ao buscarmos pela chave, o .NET Framework irá pegá-la internamente e rodar um algoritmo para a obtenção do código de dispersão, que indicará o grupo de valores em que cairá o valor que estamos armazenando, como se fossem gavetas ou caixas que os armazenam.

A busca pode ser mais ou menos eficiente de acordo com o código de dispersão. Na grande maioria dos casos, como no do dicionário,
 é possível confiar no algoritmo gerado no GetHashCode do próprio programa. Observando o diagrama, para obtermos o valor Rafael R
 ollo ou Rafael Nercessian, ambos caíram no mesmo grupo, pois seus valores foram calculados para o mesmo hash code (código de dispersão)
  do dicionário.



  Você sabe como os elementos de um dicionário são espalhados na memória? 
  Que informação é usada por um Dictionary<TKey, TValue> para mapear um elemento para um grupo de dispersão?

  O código de dispersão (hash) da chave do elemento 
  Isso aí! É pelo Hash Code da chave (key) do elemento que o dicionário sabe onde posicionar o elemento na memória.
 */