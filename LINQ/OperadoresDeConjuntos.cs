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
     
        string[] seq1 = { "janeiro", "fevereiro", "março" };
        string[] seq2 = { "fevereiro", "MARÇO", "abril"};

        //Console.WriteLine("Conectanto duas sequências"); //repitidas
       /* var consulta = seq1.Concat(seq2);
        foreach (var item in consulta)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("União de duas sequências");
        var consulta2 = seq1.Union(seq2);
        foreach (var item in consulta2)
        {
            Console.WriteLine(item);
        } 

        Console.WriteLine("União de duas sequências com comparador");
       var consulta3 = seq1.Union(seq2, StringComparer.CurrentCultureIgnoreCase);
                                         
        foreach (var item in consulta3)
        {
            Console.WriteLine(item);
        }*/

        Console.WriteLine("Intersecção de duas sequências");
            var consulta4 = seq1.Intersect(seq2); //vai exibiri so fevereiro
            foreach (var item in consulta4)
            {
                Console.WriteLine(item);
            }

        Console.WriteLine();
   
      }
    }
}

/*

Uma loja de fast-food tem um faturamento que varia dia a dia.

Na última semana, essa loja registrou os seguintes faturamentos:

var dias = new[] { 
new { nome = "segunda", faturamento = 1000 },
new { nome = "terça", faturamento = 2000 },
new { nome = "quarta", faturamento = 12500 },
new { nome = "quinta", faturamento = 11000 },
new { nome = "sexta", faturamento = 22000 },
new { nome = "sábado", faturamento = 9000 },
new { nome = "domingo", faturamento = 18000 }};
Essa loja quer saber quais dias consecutivos tiveram faturamento igual ou superior a 10 mil reais.

Qual consulta LINQ pode trazer esse resultado?


var query = dias
    .SkipWhile(d => d.faturamento < 10000)
    .TakeWhile(d => d.faturamento >= 10000);
 
Isso aí! O método SkipWhile(d => d.faturamento < 10000) vai ignorar os dias iniciais que tiveram faturamento menor que 10 mil. 
O método TakeWhile(d => d.faturamento >= 10000) vai pegar os dias consecutivos que tiveram faturamento igual ou maior a 10 mil.
 */