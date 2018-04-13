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


        IEnumerable<string> consulta = meses.Where(m => m.Dias == 31)
                                          .OrderBy(m => m.Nome)
                                          .Select(m => m.Nome.ToUpper());
        /*
        Percebemos que o método Where retorna um IEnumerable de mês, mantendo o mesmo tipo da nossa consulta, e recebe como parâmetro 
        a instância da nossa listagem de meses.
        * Este método pertence a uma classe estática, chamada Enumerable, que é, na verdade, uma extensão da classe do tipo IEnumerable.
        * Ela faz parte do pacote namespace System.Linq, que é o conjunto de técnicas da ferramenta Linq
       *  Este, por sua vez, fornece uma série de instrumentos para consultar, ordenar ou agrupar informações de coleções em geral.

       * É uma ferramenta muito poderosa, que permite fazermos uma série de coisas que não seriam possíveis com os métodos mais
          básicos das coleções.


          *Executaremos o programa, e vemos que foi possível ordenarmos alfabeticamente os nomes, sem utilizar o IComparable.

         * O OrderBy faz parte do System.Linq, da classe estática Enumerable, ou seja, é um método de extensão da interface para fornecer 
         novas possibilidades, ferramentas.

         * Ele retorna uma IOrderedEnumerable, que também é uma implementação do IEnumerable que estamos utilizando na consulta.

         Para transformarmos uma informação utilizando o Linq, utilizaremos um operador chamado Select(m => m.Nme);

         Com isso, o Visual Studio identifica a presença de um erro, informando que não é possível converter um 
         IEnumerable<string> para um IEnumerable<Mes>.

          Isso porque estamos transformando uma instância da classe Mes, para uma string. Não é possível fazer esta conversão.

          Para que isso não ocorra, podemos utilizar um IEnumerable<string> ou, ainda, um var consulta.
         */

          foreach (var item in consulta)
          {
              Console.WriteLine(item.ToString());
          }
        
      }
      
     
    }

    public  class Mes //:IComparable
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

  /* public int CompareTo(object obj)
      {
        Mes outro = obj as Mes;
        return this.Nome.CompareTo(outro.Nome);
      }*/
    }
}