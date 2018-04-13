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
        ----------------------------------------------------------
        - JaggedArray
        ----------------------------------------------------------

        **** uma matriz cujos elementos são matrizes *****

        string[3, ]

        Ao declararmos o tamanho do array, o número de famílias é 3, mas o número de nomes em cada uma varia entre 2 e 5.
        Isto significa que o array não é retangular, tem uma quantidade diferente de elementos por linha.
        Neste caso, teremos que utilizar um tipo diferente de array, o JaggedArray.
        É um tipo de array denteado, ou serrilhado. Ele conterá as três famílias.
        Como a segunda dimensão não é a mesma para todos os itens, criaremos mais um par de colchetes, 
        ao lado de cada um dos pares já existentes
         */
        //família 1: Família Flinstones
        //família 2: Família Simpsons
        //família 3: Família Dona Florinda

          /* string[,] familias = new string[3, ]
            {
                    {"Fred", "Wilma", "Pedrita"},
                    {"Homer", "Marge", "Lisa", "Bart", "Maggie"},
                    "{Florinda", "Kiko}"
            };*/

            string [][] familias = new string [3][];

            familias[0] = new string[] {"Fred", "Wilma", "Pedrita"};
            familias[1] = new string[] {"Homer", "Marge", "Lisa", "Bart", "Maggie"};
            familias[2] = new string[] {"Florinda", "Kiko"};

           foreach (var familia in familias)
            {
                    Console.WriteLine(string.Join(",", familia));
            }
        
      }      
     
    }
}

/*
Mas por que chamamos de array denteado, ou serrilhado?

Este nome é devido ao fato de que, por conterem números diferentes de elementos, quando listados, 
parecem fazer uma imagem de dentes, ou serras, vide figura abaixo:
----
-------
----------
--
---
-
-----
----------

Para criar um array de arrays, por exemplo:

int[][] matriz = new int[3][];
matriz[0] = new int[] { 1, 3, 5, 7, 9 };
matriz[1] = new int[] { 0, 2, 4, 6 };
matriz[2] = new int[] { 11, 22 };
 
Um array denteado ou matriz denteada (jagged array) é uma matriz cujos elementos são matrizes.

string[][] familias = new string[3][];

familias[0] = new string[] 
{ "Fred", "Wilma", "Pedrita" };
familias[1] = new string[] 
{ "Homer", "Marge", "Bart", "Lisa", "Maggie" };
familias[2] = new string[] 
{ "Florinda", "Kiko" };

Qual alternativa tem o código certo para imprimir o elemento "Bart" do array familias?

resposta:
Console.WriteLine(familias[1][2]); 
A expressão familias[1][2] acessa o segundo elemento (índice 1) do array familias, e dentro dele acessa o terceiro elemento (índice 2).
 */