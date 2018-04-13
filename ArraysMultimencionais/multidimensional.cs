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
            // string[,]: Indica  que meu arrya vai ter duas dimensoes.
           /* string[,] resultados = new string[3, 3]
            {
                {"Alemanha", "Espanha", "Itália"},
                {"Argentina", "Holanda", "França"},
                {"Holanda", "Alemanha", "Alemanha"}
            };*/
            //Outra forma de preencher os arrays:
            string[,] resultados = new string[4, 3];
            resultados[0, 0] = "Alemanha";
            resultados[1, 0] = "Argentina";
            resultados[2, 0] = "Holanda";
            resultados[3, 0]= "Brasil";

            resultados[0, 1] = "Espanha";
            resultados[1, 1] = "Holanda";
            resultados[2, 1] = "Alemanha";
            resultados[3, 1] = "Uruguai";               

            resultados[0, 2] = "Itália";
            resultados[1, 2] = "França";
            resultados[2, 2] = "Alemanha";
            resultados[3, 2] = "Portugal";
            
            /*foreach (var selecao in resultados)
            {
                Console.WriteLine(selecao);
            }  */
            for (int copa = 0; copa < 3; copa++)
            {
                int ano = 2014 - (copa * 4);
                Console.Write(ano.ToString() .PadRight(12));
            }
            Console.WriteLine();

            /*for (int copa = 0; copa < 3; copa ++)
            {
                    Console.Write(resultados[0,  copa].PadRight(12));
            }
            Console.WriteLine();*/
   
            //GetUpperBound(dimensao)
            //GetUpperBound:busca o maior resultado possível, com a dimensão do índice que estamos buscando que, no caso, é "0".
            // for (int posicao = 0; posicao < 4; posicao++) 
            for (int posicao = 0; posicao <= resultados.GetUpperBound(0); posicao++) 
             {
               // for (int copa = 0; copa < 3; copa ++)
               for (int copa = 0; copa <= resultados.GetUpperBound(1); copa ++)
                {
                    Console.Write(resultados[posicao,  copa].PadRight(12));
                }
                Console.WriteLine();
             }

      }      
     
    }
}