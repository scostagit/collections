using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Collections
{
    /*
        =====================================================================================================================
         --     NAO TEM O ADD   ---------------------------------------------------------------------------------------------
        =====================================================================================================================

        E se quisermos adicionar mais itens? É importante notar que o LinkedList não possui Add, como vimos em outras coleções!
         Na verdade, ele possui estas quatro formas de adição:

        como primeiro nó (AddFirst());
        como último nó (AddLast());
        antes de um nó previamente conhecido (AddBefore());
        depois de um nó previamente conhecido (AddAfter()).
     */
    class Program
    {
     //Lista licanda todo elemento tem uma referencia para o item posterior conforma imagem na pas iamgem.
      static void Main(string[] args)
      {
        
            //instanciando uma nova lista ligada: dias da semana
            LinkedList<string> dias = new LinkedList<string>();
            //adicionando um dia qualquer: "quarta"
            var d4 = dias.AddFirst("quarta");
            /*
            Quando passamos o mouse em cima de AddFirst(), vê-se que é retornado um nó chamado LinkedListNode.
             É ele que irá armazenar o valor quarta, agora o primeiro elemento da nossa lista ligada. 
             Cada elemento desta lista é um nó LinkedListNode<T>, e não uma string, como poderíamos imaginar.
             */


            // Vamos adicionar, então, um novo valor (segunda-feira), antes de quarta-feira:
            var d2 = dias.AddBefore(d4, "segunda");

            /*
            Com d2 e d4 ligados entre si, como acessaremos um nó através do outro? Para pegar o nó seguinte a partir de d2, 
            por exemplo, teremos que d2.Next é igual a d4. Em relação a d4, colocaremos que d4.Previous é igual a d2.
             */
             var d3 = dias.AddAfter(d2, "terça");
             //Neste momento d3 se encontra entre dois elementos, d2 e d4. Perceba que os "ponteiros", ou referências de ambos os 
             //elementos foram redirecionados para d3!
             var d6 = dias.AddAfter(d4, "sexta");
             var d7 = dias.AddAfter(d6, "sábado");
             var d5 = dias.AddBefore(d6, "quinta");
             var d1 = dias.AddBefore(d2, "domingo");

             //mas e o valor "quarta"? está na propriedade d4.Value
           // Console.WriteLine("d4.Value: " + d4.Value);

           //Adicionado os items fora de ordem mais ao exeucutar o codigo abaixo temos o seguinte resultado
           /*
            domingo
            segunda
            terça
            quarta
            quinta
            sexta
            sábado          
            */
            foreach (var dia in dias)
            {
                Console.WriteLine(dia);
            }

            /*
              No entanto, não conseguiremos imprimir utilizando o laço for, pois o LinkedList não dá suporte ao acesso por meio de índices. 
              No caso de querermos usar dias[0], por exemplo, teremos uma sintaxe inválida.

            Como já foi dito, LinkedList facilita muito o acesso à inserção e remoção rápidas, porém, ele não é tão eficiente na realização
             de buscas. Para isto, utilizaremos o método Find(), como neste exemplo:

            var quarta = dias.Find("quarta");
             */

             var quarta = dias.Find("quarta");
             Console.WriteLine(quarta.Value);


             /*
                Removendo um item 

                Poderemos remover um elemento através do nome do nó, como também pela referência do LinkedListNode. 
                Para removermos quarta-feira, existem as opções dias.Remove("quarta") ou dias.Remove(d4).

                Rodaremos a aplicação após escolhermos uma delas, imprimindo novamente a lista com o laço foreach:


              */
            Console.WriteLine("============================================================");
            Console.WriteLine("Item removido");
            dias.Remove("quarta");
            foreach (var dia in dias)
            {
                Console.WriteLine(dia);
            }`

            /*
            Como é que essa lista de produtos mantém a ordem dos produtos?

            Pela mesma ordem determinada pela associação entre os nós. 
             Cada elemento de um LinkedList é um nó, ou seja, um objeto LinkedListNode, que mantém duas referências, 
             apontando para o nó anterior e outra apontando para o próximo nó, e essa lista pode ser navegada pela ordem 
             definida pela associação entre esses nós.
             */
      }
      
     
    }
}