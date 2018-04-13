using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Collections
{
        /*
        //COVARIÂNCIA:

        o que e?
        Em linguagens orientadas a objeto, se uma função ou variável espera receber um objeto de um tipo você não precisa passar 
        a ela um objeto exatamente desse tipo: segundo o princípio da substituição de Liskov podemos passar qualquer outro objeto 
        compatível que ele também serve. Por exemplo, se uma variável é do tipo Animal, podemos atribuir a ela um objeto do tipo 
        Cachorro, já que os objetos cachorro implementam todos os métodos esperados pela interface da superclasse.

        IMPORTANT!
        -----------------------------------------------------------------------------------------------------------------------------
        Quando você deveria utilizar uma conversão de arrays implícita, como no exemplo abaixo?

        var familiaArray = new string[] { "Dona Florinda", "Kiko" };
        object[] objArray = familiaArray;
        objArray[0] = 123; //erro por o array de objetos foi convertido para array de string.

        O programa vai compilar, porque o array no .NET Framework é covariante (permite conversão de string[] para object[])
         mas o array objArray só poderá armazenar strings, apesar de ser um array de object. 
        O programa irá gerar uma exceção caso você tente armazenar números ou datas ou outros objetos nesse array de object.
        -----------------------------------------------------------------------------------------------------------------------------


        Para você entender melhor, covariância significa que você pode usar IEnumerable<string> onde IEnumerable<object> é esperado. 
        Contravariância permite que você passe um IComparable<object> como um argumento para um método que pede um IComparable.


        º Em conclusão, uma lista de string não pode ser convertida em uma lista de object

        Há um problema da covariância, em relação aos arrays. Isso porque, o array de object não precisa, 
        necessariamente, armazenar somente strings.

        Quando fizemos a conversão implícita, a covariância, isso resultou em um problema no qual um array de objetos não poderá mais armazenar qualquer tipo de objeto, como seria o esperado.

        Este é um problema de covariância do array, que deve ser evitado, sempre. Apesar de ser possível, não é recomendável trocar uma string por outra, isto é uma funcionalidade que está quebrada no .NET Framework.


        Contravariância
        Contravariância funciona do modo oposto de covariância. Vamos dizer que temos um método que cria alguns cachorros e os 
        compara usando um IComparer<Dog>.

        void CompareDog(IComparer comparer) {
        var dog1 = new Dog("Logan");
        var dog2 = new Dog("Wolverine");

        if (comparer.Compare(dog2, dog1) > 0)
            Console.WriteLine("Wolverine ganhou!");
        }
        O objeto comparer aceita Cachorros como argumentos, mas nunca irá retornar um cachorro como resultado. Agora, graças à 
        contravariância, nós podemos criar um comparer que pode comparar animais e usar ele como um argumento para CompareDogs:

        IComparator compareAnimals = new AnimalSizeComparator();
        CompareDogs(compareAnimals);
        O compilador aceita esse código porque a interface IComparer é contravariante e o seu parâmetro de tipo genérico 
        é anotado com in. O objeto compareAnimals que nós criamos sabe como comparar animais, logo, ele sabe como fazer a comparação entre dois cachorros.
                */

    class Program
    {
      
      static void Main(string[] args)
      {
     
        Console.WriteLine("strin[] para object[]?");
        string[] arrayMeses = new string[]
        {
                "Janeiro", "Fevereiro", "Março",
                "Abril", "Maio", "Junho",
                "Julho", "Agosto", "Setembro",
                "Outubro", "Novembro", "Dezembro"
        };
        object[] arrayObj = arrayMeses; //COVARIÂNCIA!

        //Como podemos observar, foi impresso o System.String[], indicando que esse é o namespace, 
        //e o nome da classe que está sendo armazenada, que é arrayObj.
        Console.WriteLine(arrayObj);

        foreach (var item in arrayObj)
        {
            Console.WriteLine(item);
        } 
    }
      
     
    }


}