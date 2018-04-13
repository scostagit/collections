using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

/*
O Código
Baseado no projeto do "Mão na Massa" anterior, desenvolvemos algumas funções para ler o conteúdo do Bitmap do ícone 
e exibi-lo ampliado na tela.

Vamos explicar alguns dos métodos utilizados:

Bitmap GetIconBitmap(): método que encapsula o código para obter o Bitmap a partir do arquivo do ícone (favicon.ico)

ReadOnlyCollection<Color> ObterCores(Bitmap bm): Método que recebe um Bitmap e obtém uma lista somente-leitura de cores (classe Color)

Color: um struct do sistema (namespace System.Drawing) que representa uma cor. Cada Color possui 4 propriedades: A, R, G, B, 
respectivamente: Alfa, Vermelho, Verde, Azul

void VisualizarIcone(List<Color> cores): Método que recebe uma lista de cores e exibe na tela os pixels do ícone. Cada pixel é 
representado por um controle Label do Windows Forms.
 */

namespace Collections
{
    class Program
    {        
      static void Main(string[] args)
      {
        
      }
      
     
    }
}