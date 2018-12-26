using System;
using System.Text;
using System.Runtime.InteropServices;

namespace Exercicio4
{
    // Esta classe é uma implementação de renderizador do game of life para
    // consola/terminal
    public class ConsoleRendererCell2D : IRendererCell2D
    {
        // Caracteres a imprimir para mostrar células vivas e mortas
        private readonly char alive, dead;

        // Construtor
        public ConsoleRendererCell2D(char alive, char dead)
        {
            this.alive = alive;
            this.dead = dead;
        }

        // Faz o setup inicial antes da renderização começar
        public void Setup(IBuffer2D<Cell> worldToRender)
        {
            // Limpar a consola
            Console.Clear();

            // Esconder o cursor pois causa distração
            Console.CursorVisible = false;

            // Se estivermos em Windows vamos meter o terminal com o tamanho do
            // mundo de simulação (não suportado em Linux e Mac)
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Console.SetWindowSize(
                    worldToRender.XDim, worldToRender.YDim + 2);
            }
        }

        // Método que faz a renderização
        public void Render(IBuffer2D<Cell> worldToRender)
        {
            // Usamos uma instância de StringBuilder para criar uma string de
            // forma eficiente, indicando o tamanho final dessa string
            StringBuilder sb = new StringBuilder(
                worldToRender.XDim * worldToRender.YDim
                +
                Environment.NewLine.Length * worldToRender.YDim);

            // Construir a string contendo o mundo
            for (int y = 0; y < worldToRender.YDim; y++)
            {
                for (int x = 0; x < worldToRender.XDim; x++)
                {
                    sb.Append(worldToRender[x, y].Alive ? alive : dead);
                }
                sb.Append(Environment.NewLine);
            }

            // Posicionar cursor no início
            Console.SetCursorPosition(0, 0);

            // Mostrar mundo
            Console.WriteLine(sb.ToString());
        }
    }
}

