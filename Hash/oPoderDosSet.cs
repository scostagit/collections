/*
CONJUNTOS (ISET)
No último vídeo vimos bastante sobre listas, e agora começaremos a explorar outros tipos de coleções. 
Aprenderemos sobre conjuntos (ou "sets" em inglês). No .NET conseguimos implementar conjuntos e, 
agora que temos Cursos e Aulas, criaremos também Alunos, como sets.

Há duas principais propriedades do set, sendo que a primeira é não permitir duplicidade, ou seja, 
um elemento não será contido mais de uma vez em um mesmo conjunto. A segunda característica implica 
nos elementos não serem mantidos em ordem específica quando os incluímos ou removemos.
 */
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
       /* Para declararmos os alunos como conjuntos, utilizaremos ISet<>, uma interface genérica do .NET que exige que se passe o tipo do 
        elemento deste conjunto (neste caso, string, pois armazenaremos os nomes dos alunos).
        Usaremos implementação HashSet<>, também uma classe genérica, com mesmo tipo string. Por termos alunos*/
        //declarando set de alunos
        ISet<string> alunos = new HashSet<string>();
        //adicionando: vanessa, ana, rafael
        alunos.Add("Vanessa Tonini");
        alunos.Add("Vanessa Tonini"); //um set permite apenas um unico seja addcionado
        alunos.Add("Vanessa Tonini");
        alunos.Add("Ana Losnak");
        alunos.Add("Rafael Nercessian");

        //imprimindo
        Console.WriteLine(alunos);
        Console.WriteLine(string.Join(",", alunos)); //apenas umma  Vanessa Tonini

        //remover ana, adicionando marcelo
        alunos.Remove("Ana Losnak");
        alunos.Add("Marcelo Oliveira");
        //imprimindo de novo
        Console.WriteLine(string.Join(",", alunos));

        foreach (var item in alunos)
        {
             Console.WriteLine(item); //apenas umma  Vanessa Tonini
        }


        //ordenando: sort
        //alunos.Sort(); //Error
        //copiando: alunosEmLista
        List<string> alunosEmLista = new List<string>(alunos);
        //ordenando cópia
        alunosEmLista.Sort();
        //imprimindo cópia
        Console.WriteLine(string.Join(",", alunosEmLista));

      }
      
      
    }    
 
}

/*
A maior diferença em relação às listas é que o conjunto é mais rápido na busca de elementos. 
No Stack Overflow é possível encontrar questões em relação às performances entre HashSet e uma lista,
com gráficos e outros exemplos.

Neles, vê-se que quanto mais elementos existem em uma coleção do tipo lista, maior será o tempo de busca por um elemento. 
O HashSet, por sua vez, tem um tempo de busca constante, independentemente desta quantidade.

Isto ocorre pois, diferentemente de uma lista, que faz uma varredura do primeiro ao último elemento, o HashSet, na busca de um elemento, 
utiliza uma tabela de espalhamento, que ocupa um lugar com memória muito maior, no entanto direcionando à posição que o elemento irá ocupar.

Então, com relação ao desempenho, podemos dizer que um HashSet possui grande escalabilidade, permitindo que em uma grande escala 
de elementos, haja bom desempenho. A memória, porém, é um ponto fraco do HashSet: com grande quantidade de elementos, há consumo
 bem maior de memória.

Voltando ao nosso código, será que é possível ordenar nosso conjunto de alunos por meio do método Sort(), como em uma lista?

A partir do conjunto de alunos, chamaremos este método e tentaremos rodar o código, que gera um erro indicando que o ISet,
 tipo de alunos, não contém uma definição para Sort. Já tínhamos visto este problema anteriormente com a lista somente leitura.

Utilizaremos uma técnica similar ao que já foi feito, que é copiar o conjunto para uma lista para podermos ordená-lo, já
 que a lista possui a implementação do método de ordenação Sort. Criaremos uma nova lista de string denominada alunosEmLista
 */