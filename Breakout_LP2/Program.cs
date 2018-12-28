using System;

namespace Breakout_LP2 {
    class Program {
        static void Main(string[] args) {
            // Instanciar um renderizador de consola para o nosso Game of Life
            IRenderer renderer = new Renderer();
            
            Breakout br = new Breakout(60, 30, renderer);

            // Iniciar simulação, definir que cada frame deve durar
            // 100 milisegundos
            br.GameLoop(100);
        }
    }
}
