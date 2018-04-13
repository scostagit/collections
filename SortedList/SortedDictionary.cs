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
        /*
        SortedDictionary x SortedList
        Estes tipos de listas são diferentes porque sua implementação interna não é igual.

        Uma SortedList tem, internamente, duas listas. Uma de chaves, e outra de valores, que estarão sempre ordenadas.
         Neste sistemas, conforme formos inserindo novos elementos na lista, eles serão automaticamente ordenados.

        Por ser uma classe genérica, temos o tipo da chave e o tipo do valor.

        class SortedDictionary<TKey, TValue>
        Ele também implementa um IDictionary, e terá sua coleção de chaves e de valores, como todo dicionário.

        A declaração das chaves é feita com a propriedade Key, só que aqui ela será uma KeyCollection, diferente do que aconteceu na SortedList.

        Já para a propriedade de valores, utilizaremos uma ValueCollection, que também difere do SortedList, onde tínhamos um IList.

        Na prática, isto funcionará da seguinte forma: Olhar image na pasta imagem

        A diferença é que, o método do dicionário é mais ágil caso seja necessário inserir ou remover elementos com muita frequência. 
        Isto se deve ao seu formato de árvore.

        Na SortedList, que trabalha com um IList, ao removermos um elemento, ela precisa se reajustar, 
        para poder ocupar o vazio deixado. Da mesma forma, ao adicionarmos um elemento, ela aumentará de tamanho e 
        realocará seus itens.

        Por isso, uma inserção ou remoção muito frequente de elementos, neste tipo de lista, é menos eficiente do 
        que num SortedDictionary.

        Entretanto, caso o objetivo seja criar uma coleção em que todos os elementos iniciais já estão definidos, o mais indicado 
        seria a SortedList.

        Estas diferenças são relevantes apenas para coleções muito grandes e, como hoje trabalhamos com altas capacidades de
        processamento, elas acabam não sendo tão gritantes.

        Em caso de dúvida, recomenda-se iniciar com um SortedDictionary

        SortedDictionary: Arvore Binaria: bom pra presquisa porque usa arovre binaria. Ruim para add and Remove.
        SortedList: Uma uma segunda lista (list) ordenada, boa para add e remover. Lenta na pesquisa


       * Um SortedDictionary é mais adequado que um SortedList se você precisa fazer alterações com frequência.
        Isso mesmo! Uma SortedDictionary é mais adequada se você precisa inserir/remover elementos com muita frequência,
        pois essas operações são otimizadas pela sua estrutura interna de árvore binária balanceada.


       *  SortedList contém 2 listas internas (a lista de chaves e a lista de valores). Já SortedDictionary` é mantida 
       internamente como uma árvore binária balanceada. 
       Isso aí! SortedList é uma coleção chave-valor que mantém internamente 2 listas, sendo uma lista para as chaves e outra lista para valores.
       A lista de chaves está sempre ordenada e seus elementos apontam para elementos da lista de valores . 
       Já num SortedDictionary, os elementos são mantidos internamente ordenados, através de uma árvore binária balanceada.

        */

            IDictionary<string, Aluno> sorted = new SortedDictionary<string, Aluno>();   

            sorted.Add("VT", new Aluno("Vanessa", 34672));
            sorted.Add("AL", new Aluno("Ana", 5617));
            sorted.Add("RN", new Aluno("Rafael", 17645));
            sorted.Add("WM", new Aluno("Wanderson", 11287));

            foreach (var item in sorted)
            {
                Console.WriteLine(item);
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