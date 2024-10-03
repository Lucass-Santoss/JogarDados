using System;
using System.Security.Cryptography.X509Certificates;

namespace JogarDados
{
    internal class Program
    {
        public static string NomeJogador1;
        public static string NomeJogador2;

        public static int ValorDadoJogador1;
        public static int ValorDadoJogador2;

        public static int QtdRodadas;
        public static int Rodada;

        public static int PlacarAcumulado1 = 0;
        public static int PlacarAcumulado2 = 0;


        static void Main(string[] args)
        {
            QtdRodadas = 3;

            Console.WriteLine("Informe o nome do primeiro jogador: ");
            NomeJogador1 = Console.ReadLine();
            Console.WriteLine("Informe o nome do segundo jogador: ");
            NomeJogador2 = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Iniciando Partida: " + Environment.NewLine);

            for (int i = 0; i < QtdRodadas; i++)
            {
                Rodada = i + 1;

                Console.WriteLine("Rodada: " + Rodada + ".");

                ValorDadoJogador1 = JogarDado();
                ValorDadoJogador2 = JogarDado();

                Console.WriteLine("O jogador " + NomeJogador1 + " tirou: " + ValorDadoJogador1 + ".");
                Console.WriteLine("O jogador " + NomeJogador2 + " tirou: " + ValorDadoJogador2 + ".");

                PlacarAcumulado1 += ValorDadoJogador1;
                PlacarAcumulado2 += ValorDadoJogador2;
                

                Console.WriteLine(InformarVencedorRodada());
                Console.WriteLine();
                Console.WriteLine(InformarPlacar(PlacarAcumulado1, PlacarAcumulado2));
                Console.WriteLine("----------------------------------------------------------------------" + Environment.NewLine);

            }

            Console.WriteLine(VencedorPartida());

            #region Funções
            static int JogarDado()
            {
                Random random = new Random();

                int NumeroAleatorio = random.Next(1, 7);

                return NumeroAleatorio;
            }

            static string InformarVencedorRodada()
            {
                string mensagem = "";

                if (ValorDadoJogador1 > ValorDadoJogador2)
                {
                    mensagem = "O vencedor da rodada " + Rodada + " foi: " + NomeJogador1 + ".";

                }
                else if (ValorDadoJogador2 > ValorDadoJogador1)
                {
                    mensagem = "O vencedor da rodada " + Rodada + " foi: " + NomeJogador2 + ".";
                }
                else
                {
                    mensagem = "Rodada empatada!";
                }

                return mensagem;
            }

            static string InformarPlacar(int placarAcumulado1, int placarAcumulado2)
            {
                PlacarAcumulado1 = placarAcumulado1;
                PlacarAcumulado2 = placarAcumulado2;
                string mensagem = "Placar acumulado do jogador " + NomeJogador1 + ": " + PlacarAcumulado1 + "." + Environment.NewLine +
                    "Placar acumulado do jogador " + NomeJogador2 + ": " + PlacarAcumulado2 + ".";

                return mensagem;
            }

            static string VencedorPartida()
            {
                string mensagem = "";

                if (PlacarAcumulado1 > PlacarAcumulado2)
                {
                    mensagem = "O vencedor da partida foi o jogador: " + NomeJogador1 + " com " + PlacarAcumulado1 + "pontos. Parabéns!";
                }
                else if (PlacarAcumulado2 > PlacarAcumulado1)
                {
                    mensagem = "O vencedor da partida foi o jogador: " + NomeJogador2 + " com " + PlacarAcumulado2 + "pontos. Parabéns!";
                }
                else
                {
                    mensagem = "Houve um empate entro os jogadores!";
                }

                return mensagem;
            }
            #endregion
        }
    }
}
