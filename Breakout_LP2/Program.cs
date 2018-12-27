using System;

namespace Breakout_LP2 {
    class Program {
        static void Main(string[] args) {
            // Instanciar um renderizador de consola para o nosso Game of Life
            IRenderer renderer = new Renderer();

            // Criar uma instância de game of life com dimensões 80x40, 20% de
            // probabilidade inicial de células vivas e com um renderizador de
            // consola
            Breakout br = new Breakout(80, 40, renderer);

            // Iniciar simulação, definir que cada frame deve durar
            // 100 milisegundos
            br.GameLoop(100);
        }
    }
}
