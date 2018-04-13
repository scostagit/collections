using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace A1._1_SortedList
{
    class Program
    {
      
      static void Main(string[] args)
      {
        //Dictionary: nao ordenado
        //SortedList: Ordeando automatica conforme addcionamos ou alteramos os itens.
       // IDictionary<string, Aluno> alunos = new Dictionary<string, Aluno>();
        IDictionary<string, Aluno>  sorted  = new SortedList<string, Aluno>();

        sorted.Add("VT", new Aluno("Vanessa", 34672));
        sorted.Add("AL", new Aluno("Ana", 5617));
        sorted.Add("RN", new Aluno("Rafael", 17645));
        sorted.Add("WM", new Aluno("Wanderson", 11287));

        //vamos remover: AL
        sorted.Remove("AL");
        //vamos.adicionar: MO
        sorted.Add("MO", new Aluno("Marcelo", 12345));
        /*
            O novo nome não foi inserido ao final da lista, como poderia ser esperado.
            Caracteristicamente, não é possível sabermos com precisão a localização dos itens no momento da impressão.

            As chaves, que estão na primeira coleção, são armazenadas de uma forma não-ordenada. Isso significa que, a posição que cada chave ocupa na memória, independe da sua ordem de inserção.

            A ordem dependerá do seu código de espalhamento (ou "hash"), que é calculado para direcionar um item para determinado lugar na memória, um bucket, ou uma gaveta, onde cada informação é organizada, para ser recuperada posteriormente.

            O Dictionary, internamente, utiliza um hash para armazenar as chaves.
         */

        foreach (var aluno in sorted)
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
}

/*
Dictionary x SortedList

Temos uma estrutura diferente de armazenamento de chaves e valores. Não teremos a coleção que utiliza o "hash", 
em vez disso, haverá uma lista automaticamente ordenada. Ou seja, cada vez que inserimos um valor, ele será ordenado automaticamente.

Em outra lista, serão armazenados os valores.

Com isso, vemos que há uma clara diferença estrutural entre uma SortedList e um Dictionary.

Lembrando que um SortedList não é uma lista, este nome se deve ao fato de que a sua coleção de chaves é armazenada numa lista.

Com o atalho "Alt + F12" abriremos a implementação. Com isso, veremos que o SortedList implementa o IDictionary.

Abaixo, temos a coleção de chaves,"Keys", que tem como retorno um tipo IList do tipo TKey. Acima, podemos observar a lista de valores 
IList<TValue> Values.

Ambas são representadas pelo diagrama.

Assim, vemos como funciona um "SortedList" e como pode ser utilizado para ordenar automaticamente um dicionário, pelas suas chaves.

 */