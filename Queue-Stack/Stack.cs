using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Collections
{
    /*
        Stack
        Pilha
        LIFO
        no add ou remove
        Push and Pop

        Uma “Stack” é uma coleção que funciona exatamente como uma pilha na vida real: por exemplo, numa pilha de pratos para serviço 
        de um buffet de um restaurante, os últimos pratos colocados na pilha são os primeiros a serem retirados dela.

        Vamos usar um outro tipo de metáfora para aprender como funcionam pilhas: um navegador web começa a navegar pelas páginas, 
        seguindo os links e abrindo novas páginas. Nesse percurso, os botões anterior e próximo nos auxiliam a navegar para os 
        itens navegados anteriormente. Essa funcionalidade é implementada internamente como
        duas pilhas de urls: a primeira pilha permite acessar as páginas anteriores e a segunda as próximas páginas.
     */
  
    class Program
    {
    
      static void Main(string[] args)
      {
        
           var navegador = new Navegador();
            navegador.NavegarPara("google.com");
            navegador.NavegarPara("caelum.com.br");
            navegador.NavegarPara("alura.com.br");           

            navegador.Anterior(); //caelum
            navegador.Anterior(); //google
            navegador.Anterior(); //pilha vazia
            navegador.Anterior();

            navegador.Proximo();
            
      }      
     
    }

    public class Navegador
    {
        private string atual = "vazia";
        private readonly Stack<string> historicoAnterior = new Stack<string>();
        private readonly Stack<string> historicoProximo = new Stack<string>();

        public Navegador()
        {
            Console.WriteLine("Página atual: " + atual);
        }

        public void NavegarPara(string url)
        {
            historicoAnterior.Push(atual);
            atual = url;
            Console.WriteLine("Página atual: " + atual);
        }

        public void Anterior()
        {
            if(historicoAnterior.Any())
            {
                atual = historicoAnterior.Pop();
                Console.WriteLine("Página atual: " + atual);
            }
        }

        public void Proximo()
        {
            if(historicoAnterior.Any())
            {
                historicoProximo.Push(atual);
                atual = historicoAnterior.Pop();
                Console.WriteLine("Página atual: " + atual);
            }
        }

        /*
        A aplicação roda com sucesso, e conseguimos implementar estas duas funcionalidades, os dois botões do navegador.
         Vimos como funciona a pilha, com a prioridade de que "o último elemento que entra é o primeiro que sai", o que chamamos de LIFO,
          em inglês, "Last in, first out"
         */
    }
}