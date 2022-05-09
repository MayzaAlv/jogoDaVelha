﻿string[,] matriz = new string[,] { { "7", "8", "9" }, { "4", "5", "6" }, // jogo da velha
                                    { "1", "2", "3" } };
string numJogador;

Console.WriteLine("JOGO DA VELHA");

do // while que faz repetir o jogo todo
{
    Console.WriteLine("\n");
    
    mostraJogo(matriz);  // método com o for para mostrar a matriz

    Console.Write("\n\nInsira o número onde deseja colocar (X): "); // pede o número do jogador e registra
    numJogador = Console.ReadLine();

    jogadas(matriz, numJogador); // método para as jogadas que serão feitas
    
    string ganhador = verificacaoVitoria(matriz); // método para verificar se alguém ganhou

    if (ganhador != "" && ganhador != "empate") // Verificando se não foi empate
    {
        Console.WriteLine("Resultado final: " + ganhador + " ganhou."); // Declarando vencedor
        break;
    }
    else if (ganhador == "empate") // Declarando quando foi impate
    {
        Console.WriteLine("Empate!!");
    }

} while (true);


static void mostraJogo(string[,] matriz) {
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
}


static string[,] jogadas(string[,] matriz, string numJogador)
{   
    string numComputador = jogadaComputador(matriz, int.Parse(numJogador)); // recebendo e verificando se o número
                                                    // do computador existe
    if (verificacao(matriz, int.Parse(numJogador))) { // verificando se o número digitado pelo jogador existe
        for (int i = 0; i < 3; i++)                   // e trocar os valores se existe
        {
            for (int j = 0; j < 3; j++)
            {
                if (matriz[i, j] == numJogador) // verificando se é a posição do jogador
                {
                    matriz[i, j] = "X"; // alterando o valor se for a posição
                }
                else if (matriz[i, j] == numComputador) // verificando se é a posição do computador
                {
                    matriz[i, j] = "O"; // alterando o valor se for a posição
                }
            }
        }
    } else
    {
        Console.WriteLine("Posição inválida!"); // caso não acha a posição, imprime "Posição inválida"
    }                                           // na tela

    return matriz; // retorna a matriz
}


static string jogadaComputador(string[,] matriz, int numJogador) { // função para fazer a jogada do computador
    Random valorAleatorio = new Random();
    int numComputador = valorAleatorio.Next(1, 10); // criando um valor random entre 1 e 10

    while (!verificacao(matriz, numComputador) || numComputador == numJogador) // verificando se o número do computador é válido
    {
        numComputador = valorAleatorio.Next(1, 10);  // será trocado até for válido
    }

    return numComputador.ToString(); // retorna quando é válido 
}


static bool verificacao(string[,] matriz, int numJogada) {
    for (int i = 0; i < 3; i++) {
        for (int j = 0; j < 3; j++) { 
            if (matriz[i, j].Equals(numJogada.ToString())) // verificando se existe o número na matriz
            {
                return true;    // retorna verdadeiro se existe
            }
        }
    }
    return false; // retorna falso se não existir
}


static string verificacaoVitoria(string[,] matriz)
{
    string ganhador = "";
    bool empate = true;

    if (matriz[0, 2] == matriz[1, 1] && matriz[0, 2] == matriz[2, 0]) // comparando as diagonais (direita p/ esquerda)
    {
        ganhador = matriz[0, 2]; // atribuindo o ganhador caso tiver passado da condição

    } else if (matriz[0, 0] == matriz[1, 1] && matriz[0, 0] == matriz[2, 2]) // comparando as diagonais (esquerda p/ direita)
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

        for (int i = 0; i < 3; i++) 
        {
            for (int j = 0; i < 3; i++) {
                if (matriz[i, j] != "O" && matriz[i, j] != "X") // verificando se não deu empate
                {  
                    empate = false; // caso não, valor atrivuido é falso
                }
            }
        }
    }
    if (empate) { // se empate for verdadeiro ele retorna o valor "empate"
        return ganhador = "empate"; 
    }
    return ganhador;
}

