using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Drawing;

/*
-------------------------------------------------------------------------------------------------------------------------
Objetivo 
-------------------------------------------------------------------------------------------------------------------------
O nosso objetivo aqui é carregar uma imagem a partir de um arquivo, e usar essa imagem como ícone do form. 
Para isso, o array (mais especificamente, um array de bytes) será necessário para fazer a carga dos dados 
desse arquivo de imagem.

 */

namespace Collections
{
    class Program
    {
     
        static void Main(string[] args)
        {            
            Bitmap bm = new Bitmap(32, 32);

            /*
            -------------------------------------------------------------------------------------------------------------------------
            Stream de Memória 
            -------------------------------------------------------------------------------------------------------------------------
            Declarando um Stream de Memória
            Trabalhar com arquivos de vídeo pode exigir bastante memória. Se você já tentou copiar um vídeo de um " para um computador 
            sabe do que estou falando. E trabalhar com imagens não é muito diferente.

            Para auxiliar na transmissão de dados, o .NET Framework conta com uma série de classes especializadas em streaming. 
            Uma delas é o MemoryStream, que, como diz o nome, permite manipular dados em memória.
             */
            MemoryStream memStream;

            /*
            -------------------------------------------------------------------------------------------------------------------------
            Trabalhando com Stream de Arquivo
            -------------------------------------------------------------------------------------------------------------------------
            Felizmente, nosso arquivo de imagem já está incluído no projeto, e se chama favicon.ico. Para a leitura desse arquivo, 
            vamos utilizar outro stream, mas desta vez, uma classe especializada para acesso a arquivos: o FileStream:
             */
            using (Stream stream = new FileStream("favicon.ico", FileMode.Open, FileAccess.Read))
            {
                //AQUI VAI SER FEITA A LEITURA DO ARQUIVO E GRAVAÇÃO EM MEMÓRIA!

                /*
                -------------------------------------------------------------------------------------------------------------------------
                Uma História com Duas Piscinas...
                -------------------------------------------------------------------------------------------------------------------------
                Agora imagine que você tenha duas piscinas: uma cheia de água e outra vazia. E você precisa transferir a água de uma piscina 
                para a outra.

                Para isso, você não irá transferir toda a água de uma vez, porque a piscina é muito grane. Em vez disso, você irá utilizar 
                um balde.

                Nessa historinha, a piscina cheia é nosso FileStream, e a piscina vazia é o MemoryStream.
                Agora ficou faltando o balde...

                Esse balde servirá para transportar os dados temporários de um Stream para o outro. E esse "balde" é chamado de buffer.

                Esse buffer tem tamanho fixo e armazena uma coleção de bytes. Adivinha qual tipo de coleção temos que usar? Isso mesmo, 
                um array de bytes!
                 */
                //FileStream piscina cheia
                memStream = new MemoryStream(); //pscina vazia 
                byte[] buffer = new byte[1024]; //balde
                /*
                Note que o array de bytes acima tem tamanho fixo de 1024. Um arquivo de imagem geralmente tem muito mais bytes do que isso, 
                mas o que importante é que o "balde" (buffer) pode ser usado quantas vezes forem necessárias para transferir os dados.

                -------------------------------------------------------------------------------------------------------------------------
                Transportando os Dados
                -------------------------------------------------------------------------------------------------------------------------
                * Agora temos que fazer o transporte dos dados. Quantas vezes faremos isso? Muitas vezes, e quantas vezes forem necessárias.

                * Vamos utilizar uma variável byteCount para saber quantos bytes foram transferidos a cada vez. Sempre que byteCount for maior 
                que zero, significa que transportamos alguma coisa. Quando byteCount for igual a zero, então todo nosso arquivo foi transferido 
                para o MemoryStream.

               * E para a transferência em si, vamos utilizar o método FileStream.Read e MemoryStream.Write, que farão a leitura e a gravação 
                dos dados, respectivamente:
                 */
                
                int byteCount; // contador de bytes, sempre pega o total de bytes.

                do
                {
                    byteCount = stream.Read(buffer, 0, buffer.Length); //Pega um pedaco do arquivo (1024 bytes) e armazena na variavl buffer
                    memStream.Write(buffer, 0, byteCount); //Transporte do arquivo para o  memeoryStream escreve na memoria o aquivo. 1024 bytes por bytes
                } while (byteCount > 0);


                //E por fim, nosso bitmap é montado a partir do stream em memória:
                bm = new Bitmap(Image.FromStream(memStream));

                /*
                Gerando o Ícone
                E, para alterar o ícone da janela, usamos um método especializado da classe Icon:*/
                Icon ic = Icon.FromHandle(bm.GetHicon());
                this.Icon = ic;

                /*
                É isso! Neste Mão na Massa vimos como um array de bytes é utilizado como meio de transporte para um fluxo de dados entre 
                um arquivo e um armazenamento em memória.
                 */
            }

        }      
     
    }
}