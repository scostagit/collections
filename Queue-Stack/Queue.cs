using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Collections
{
    /*
        Queue
        Fila
        FIFO
        no add ou remove
        Enqueue and dequeue

        Em muitas situações do dia-a-dia, nos deparamos com o tipo de coleção que veremos agora: as filas, que em inglês são chamadas de queues.

No .NET Framework, esse tipo de coleção é implementada pela classe Queue<T>, onde T é o tipo de dado armazenado nos elementos.

Vamos criar um novo projeto Console Application para lidar com as filas em C#.Nosso programa fará a implementação de uma fila de carros passando pelo pedágio.

Na classe Program, colocamos uma variável estática chamada pedagio, que conterá os nomes dos carros enfileirados.
     */
  
    class Program
    {
    
        static Queue<string> pedagio = new Queue<string>();

        static void Main(string[] args)
        {
            
            //entrou: van
            Enfileirar("van");
            //entrou: kombi
            Enfileirar("kombi");
            //entrou: guincho
            Enfileirar("guincho");
            //entrou: pickup
            Enfileirar("pickup");

            Console.WriteLine("FILA:");      
            ImprimirFila();

            //carro liberado
            Desenfileirar();
            Desenfileirar();
            Desenfileirar();
                
                    
        }  

        private static void Enfileirar(string veiculo)    
        { 
            pedagio.Enqueue(veiculo);  
        }
     
        private static void Desenfileirar()
        {
            if (pedagio.Any())
            {
                /*
                E se quisermos ver o próximo elemento da fila, porém sem removê-lo? Podemos “dar uma olhada” no elemento sem desenfileirar. 
                Em inglês, “dar uma espiada” é “peek”, logo vamos usar o método Peek(), que retorna o próximo elemento a sair da fila:
                 */
                if (pedagio.Peek() == "guincho")
                {
                    Console.WriteLine("guincho está fazendo o pagamento.");
                }

                string veiculo = pedagio.Dequeue();
                Console.WriteLine($"Saiu da fila: {veiculo}");
                ImprimirFila();
            }
        }

        private static void ImprimirFila()
        {
            foreach (var v in pedagio)        
            {
                Console.WriteLine(v);
            }
        }
    }
  
}