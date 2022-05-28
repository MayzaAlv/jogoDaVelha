using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogo
{
    public class JogoDaVelha
    {
        private string[,] matriz = new string[,] { { "7", "8", "9" }, 
                                                   { "4", "5", "6" }, // jogo da velha
                                                   { "1", "2", "3" } };
        private int numPosicoes = 9;


        public void iniciar()
        { 
            do // while que faz repetir o jogo todo
            {
                Console.Clear();

                Console.WriteLine("JOGO DA VELHA");

                MostrarJogo();  // método com o for para mostrar a matriz

                string numJogador = ValidarJogada();

                PreencherValores(numJogador); // método para as jogadas que serão feitas

                string ganhador = VerificarVitoria(); // método para verificar se alguém ganhou

                if (ganhador != "" && ganhador != "empate") // Verificando se não foi empate
                {
                    MostrarJogo();
                    Console.WriteLine("Resultado final: " + ganhador + " ganhou."); // Declarando vencedor
                    break;
                }
                else if (ganhador == "empate") // Declarando quando for impate
                {
                    MostrarJogo();
                    Console.WriteLine("Empate!!");
                    break;
                }

            } while (true);
        }


        private string ValidarJogada() 
        {
            string numJogador;
            int numInt = 0;

            do
            {
                Console.Write("Insira o número onde deseja colocar (X): "); // pede o número do jogador e registra
                numJogador = Console.ReadLine();

                try
                {
                    numInt = int.Parse(numJogador);
                }
                catch (FormatException) { }

                if (numInt > 0 && numInt < 10)
                {
                    return numJogador;
                }
                Console.WriteLine("Insira um valor valido!\n");

            } while (true);
        }

        private void MostrarJogo()
        {
            Console.WriteLine();

            for (int i = 0; i < 3; i++)  // passando entre os valores da linha
            {
                for (int j = 0; j < 3; j++) // passando entre os valores da coluna
                {
                    if (j != 2) // if para verificar se não é o último, pois o último não tem |
                    {
                        Console.Write(matriz[i, j] + " | "); // mostrando os dois primeiros valores
                    }
                    else
                    {
                        Console.Write(matriz[i, j]); // mostrando o último valor
                    }
                }

                if (i != 2) // if para verificar se não é o último, pois o último não tem a estilização
                {
                    Console.WriteLine("\n--+---+--");
                }
            }
            Console.WriteLine("\n");
        }


        private void PreencherValores(string numJogador)
        {
            if (VerificarValoresIguais(int.Parse(numJogador)))
            { // verificando se o número digitado pelo jogador existe

                Jogar(numJogador, "X");

                if (!ValidarValoresCompletos())
                {
                    string numComputador = JogarComputador(); // recebendo e verificando se o número do computador existe
                    Jogar(numComputador, "O");
                }
            }
            else
            {
                Console.WriteLine("Posição inválida!"); // caso não acha a posição, imprime "Posição inválida"
            }                                           // na tela

        }


        private string JogarComputador()
        { // função para fazer a jogada do computador
            Random valorAleatorio = new Random();
            int numComputador = valorAleatorio.Next(1, 10); // criando um valor random entre 1 e 10

            while (!VerificarValoresIguais(numComputador)) // verificando se o número do computador é válido
            {
                numComputador = valorAleatorio.Next(1, 10);  // será trocado até for válido
            }

            return numComputador.ToString(); // retorna quando é válido 
        }


        private bool VerificarValoresIguais(int numJogada)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (matriz[i, j].Equals(numJogada.ToString())) // verificando se existe o número na matriz
                    {
                        return true;    // retorna verdadeiro se existe
                    }
                }
            }
            return false; // retorna falso se não existir
        }


        private string VerificarVitoria()
        {
            string ganhador = "";
            bool empate = true;

            if (matriz[0, 2] == matriz[1, 1] && matriz[0, 2] == matriz[2, 0]) // comparando as diagonais (direita p/ esquerda)
            {
                ganhador = matriz[0, 2]; // atribuindo o ganhador caso tiver passado da condição

            }
            else if (matriz[0, 0] == matriz[1, 1] && matriz[0, 0] == matriz[2, 2]) // comparando as diagonais (esquerda p/ direita)
            {
                ganhador = matriz[0, 0]; // atribuindo o ganhador caso tiver passado da condição
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    if (matriz[i, 0] == matriz[i, 1] && matriz[i, 0] == matriz[i, 2]) // comparando as linhas
                    {
                        ganhador = matriz[i, 0]; // atribuindo o ganhador caso tiver passado da condição
                    }
                    else if (matriz[0, i] == matriz[1, i] && matriz[0, i] == matriz[2, i]) // comparando as colunas
                    {
                        ganhador = matriz[0, i]; // atribuindo o ganhador caso tiver passado da condição
                    }
                }
                empate = ValidarValoresCompletos();
            }

            if (empate && ganhador == "") // se empate for verdadeiro ele retorna o valor "empate"
            {
                return "empate";
            }

            return ganhador;
        }

        private bool ValidarValoresCompletos()
        {
            if (numPosicoes == 0) 
            {
                return true;
            }
            return false;
        }


        private void Jogar(string jogada, string jogador)
        {
            // jogador = "X" ou "O"
            // jogada = 1 a 9
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (matriz[i, j].Equals(jogada))
                    {
                        matriz[i, j] = jogador;
                    }
                }
            }

            numPosicoes--;
        }
    }
}
