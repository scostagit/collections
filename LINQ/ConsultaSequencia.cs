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
          List<Mes> meses = new List<Mes>
          {
            new Mes("Janeiro", 31),
            new Mes("Janeiro", 31),
            new Mes("Fevereiro", 28),
            new Mes("Março", 31),
            new Mes("Abril", 30),
            new Mes("Maio", 31),
            new Mes("Junho", 30),
            new Mes("Julho", 31),
            new Mes("Agosto", 31),
            new Mes("Setembro", 30),
            new Mes("Outubro", 31),
            new Mes("Novembro", 30),
            new Mes("Dezembro", 31)
          };


        /*
          ------------------------------------------------------------------------------------------------
          - Take "pegar"
          ------------------------------------------------------------------------------------------------
          No primeiro problema, iremos isolar o primeiro trimestre. Temos os 12 meses do ano, e queremos selecionar apenas os três primeiros.
          Utilizaremos o método "Take" para obter elementos, que em tradução para o Portugûes é a palavra "pegar".
          Ele exige um parâmetro, que é a quantidade de elementos, ou seja, neste caso, três elementos. Este método retornará um IEnumerable.
         */
        //Pegar o primeiro trimestre
        var consulta = meses.Take(3);
        foreach (var item in consulta)
        {
            Console.WriteLine(item);
        }
        
        /*
          ------------------------------------------------------------------------------------------------
          - Skip "pular
          ------------------------------------------------------------------------------------------------
          Em seguida, isolaremos os meses subsequentes ao primeiro trimestre.
          Ao montar a consulta, precisamos ter em mente que será necessário "pular" os três primeiros meses. Para isso, 
          utilizaremos o método Linq "Skip", cuja tradução seria "pular", em Português.
          Esta nova consulta será denominada "consulta2".
         */
          //Pegar os meses depois do primeiro trimestre
        var consulta2 = meses.Skip(3);
        foreach (var item in consulta2)
        {
            Console.WriteLine(item);
        }

        //terceiro trimestre
        //Pegar os meses do terceiro trimestre
        var consulta3 = meses.Skip(7).Take(3);
        foreach (var item in consulta3)
        {
            Console.WriteLine(item);
        };

        /*
         ------------------------------------------------------------------------------------------------
          - TakeWhile "pegar enquanto algum condicao seja satisfeita"
          ------------------------------------------------------------------------------------------------        
          o método TakeWhile, que nos permite obter algo, enquanto alguma coisa for verdadeira. Como parâmetro, 
          faremos com que não sejam selecionados meses que iniciem com a letra "S". Como é um predicate, 
          ele pode ser representado com uma expressão lambda, como veremos abaixo.

          Pegar os meses até que o mês comece com a letra 'S'
          depois de setembro nao sera exibido mais nenhum mes.
        */
        var consulta4 = meses.TakeWhile(m => !m.Nome.StartsWith("S"));
        foreach (var item in consulta4)
        {
            Console.WriteLine(item);
        }


        /*
        ------------------------------------------------------------------------------------------------
        - SkipWhile "que pulará informações considerando uma condição verdadeira"
        ------------------------------------------------------------------------------------------------    
        Para ignorar certos meses, não utilizaremos método Skip porque, como vimos com o método Take, estes só aceitam 
        números inteiros como parâmetros.

        Assim, utilizaremos o método SkipWhile, que pulará informações considerando uma condição verdadeira.

        A expressão lambda, neste caso, será a mesma do problema anterior.
      */
      //Pular os meses até que o mês comece com a letra 'S'. Serao exibidos todos os meses a partir de Setembro.
        var consulta5 = meses.SkipWhile(m => !m.Nome.StartsWith("S"));
        foreach (var item in consulta5)
        {
          Console.WriteLine(item);
        }

        Console.WriteLine();
      }
      
     
    }

    public  class Mes :IComparable
    {
      public Mes(string nome, int dias)
      {
        Nome = nome;
        Dias = dias;
      }

      public string Nome { get; private set; }
      public int Dias { get; private set; }

      public override string ToString()
      {
         return $"{Nome} -{Dias}";
      }
      public int CompareTo(object obj)
      {
        Mes outro = obj as Mes;
        return this.Nome.CompareTo(outro.Nome);
      }
    }
}