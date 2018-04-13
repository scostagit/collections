using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Collections
{


    class Program
    {
     
      /*
        List implementa IEnumerable, que tem um metodo chamado GetEnumerator(), que por sua vez retorna um IEnumerator<T>.

        Nela, vemos que há um enumerador que é um struct, e tem uma propriedade Current - que é o elemento atual de uma 
        varredura com a instrução foreach -, e um método MoveNext, que é utilizado para mover o ponteiro para o próximo elemento desta varredura.

        -----------------------------------------------------------------------------------------------------------------------------
        -- Como funcion o Forech
        -----------------------------------------------------------------------------------------------------------------------------

        Temos um laço foreach e o enumerador será posicionado no índice "-1", que está antes do elemento de índice "0". Está, portanto,
        fora da faixa do array, mas, assim que o laço passa a pegar elemento por elemento, ele utilizará o método MoveNext.

        Este método será movido para a primeira posição, ou seja, o índice "0". Com isso, a variável mês, que está dentro do laço, 
        assumirá o valor "janeiro".

        Assim que passa pelo código, dentro do foreach, novamente o MoveNext passará para o próximo elemento, 
        ou seja, "fevereiro".

        Isso seguirá até que se atinja o último elemento.
        (Ve imagem na pasta imagen)

        Tentaremos então trocar o valor da variável mes, para que passe a ser escrito em letras maiúsculas.

       */
      static void Main(string[] args)
      {
         /* var meses = new List<string>
            {
                    "Janeiro", "Fevereiro", "Março",
                    "Abril", "Maio", "Junho",
                    "Julho", "Agosto", "Setembro",
                    "Outubro", "Novembro", "Dezembro"
            };

        foreach (var mes in meses)
        {
                
                 mes = mes.ToUpper();
                Ao fazermos isso, o Visual Studio aponta um erro, porque não podemos modificar a variável de interação do foreach,
                 ou seja, mes. Isto é uma proteção da instrução, evitando que hajam modificações sem sentido.

                  error CS1656: Cannot assign to `mes' because it is a `foreach iteration variable'
                              
                meses[0] = meses.ToUpper();   
                
                meses[0] = meses.ToUpper();  
                Ao executarmos a aplicação, surgirá uma caixa de diálogo, indicando que há um erro:
                "Exceção sem tratamento: (...) Coleção foi modificada; talvez a operação de enumeração não seja executada.
                Isto acontece, novamente, como uma forma de proteção, não permitindo a modificação da coleção que está sendo enumerada

                 -----------------------------------------------------------------------------------------------------------------------------
                -- Por acontence?
                 -----------------------------------------------------------------------------------------------------------------------------
                Isto é feito por meio de um código, dentro do indexador, que verifica a versão da coleção. Ou seja, a cada modificação, 
                a versão interna de uma coleção - que é o número - é modificada.

                A primeira vez que o código entra no laço foreach ele armazena qual é a versão da coleção naquele ponto, 
                se dentro do laço a coleção for modificada, foi alterado também o número da versão.

                Portanto, a cada vez que passar pela coleção, haverá a verificação do número anterior com o atual. 
                Caso haja diferença, será lançada uma exceção, para proteção.
                 -----------------------------------------------------------------------------------------------------------------------------
                */ 


                 var meses = new string []
                {
                        "Janeiro", "Fevereiro", "Março",
                        "Abril", "Maio", "Junho",
                        "Julho", "Agosto", "Setembro",
                        "Outubro", "Novembro", "Dezembro"
                };

                foreach (var mes in meses)
                {
                        //Essa funciona
                        meses[0] = meses[0].ToUpper();
                        Console.WriteLine(mes);
                }   

                /*
                Por que o ultimo codigo funcionou?
                Veremos que foram impressos todos os meses, de janeiro até dezembro.

                Não foi identificado nenhum erro desta vez, porque o laço foreach trabalha com arrays de uma forma diferente.
                Ele não trabalha com o enumerador da classe array, mas sim transforma em um laço for.

                Como se estivesse realizando a seguinte operação:

                                foreach (var mes in meses)
                                {

                                        meses[0] = meses[0].ToUpper();
                                        Console.WriteLine(mes);
                                }

                                for (int i = 0; i < lenght; i++) // Internamento o compilador muda de laco foreach para for quando encontra um array



                     Em que temos um laço for, e, para cada índice dentro do tamanho do array, no caso meses, 
                     ele armazenará uma variável var mes = meses[i] e continuará fazendo o laço, do modo como ele existe dentro do foreach.

                    Isto é a implementação, que o compilador cria, quando encontra uma instrução foreach dentro de um array.

                    Portanto, vimos um pouco sobre a instrução foreach, e como ela aciona o enumerador de um IEnumerable, 
                    para poder selecionar os elementos. Também vimos qual é a diferença do laço foreach para uma lista, e para um array.


                    ponto Chanve
                    O laço foreach pode varrer qualquer coleção que implementa a interface IEnumerable.
                 */
                
      }      
    
      
      
     
    }


}