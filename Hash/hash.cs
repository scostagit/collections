using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Collections
{
    class Program
    {
        /*
        Um conjunto não aceita duplicação de itens. Por outro lado, uma lista permite que o mesmo valor seja armazenado em várias posições diferentes.
        Um conjunto não é uma sequência. Diferente da classe List, onde adicionamos elementos ao final da coleção, os elementos do conjunto HashSet não são mantidos em nenhuma ordem específica.
        */
      static void Main(string[] args)
      {
        ISet<string> alunos = new HashSet<string>();
        
        alunos.Add("Vanessa Tonini");
        alunos.Add("Ana Losnak");
        alunos.Add("Rafael Nercessian");
        alunos.Add("Priscila Stuani");
        alunos.Add("Rafael Rollo");
        alunos.Add("Fabio Gushiken");
        
        alunos.Remove("Ana Losnak");
        alunos.Add("Marcelo Oliveira");

        //Já dissemos que um conjunto em .NET Framework não aceita duplicidade. Vamos comprovar isso?
        alunos.Add("Fabio Gushiken");
        /**
        Veja só, sem erros! Mas algo interessante aconteceu. Ou melhor, não aconteceu. O aluno Fabio Gushiken não 
        foi adicionado novamente! Ou seja, quando adicionamos um valor duplicado em um conjunto, essa operação não gera erro, porém um novo item com o mesmo valor não é inserido!
         */      
        /*
        Até aqui nada de especial, certo? Tanto o método Remove quanto Add existem em outras coleções, como List<T>. 
        Mas a diferença entre o HashSet fica mais evidente quando imprimimos o nosso conjunto novamente:
        Vanessa Tonini,Marcelo Oliveira,Rafael Nercessian,Priscila Stuani,Rafael Rollo,Fabio Gushiken
        Note a posição de Marcelo Oliveira acima!
        
        #####IMPORTANTE #########################
        Quando adicionamos um item numa List<T>, ele vai para o "final" da coleção. Mas Mas veja que agora o aluno Marcelo Oliveira 
        está ocupando a segunda posição, no mesmo lugar onde havia Ana Losnak! Então conseguimos provar que um elemento num HashSet<T> 
        não ocupa uma ordem específica!
        */

        alunos.Sort(); // Erro
        List<string> alunosEmLista = new List<string>(alunos);
        alunosEmLista.Sort();
        Console.WriteLine(string.Join(",", alunosEmLista));
        
      }
      
     
    }
}