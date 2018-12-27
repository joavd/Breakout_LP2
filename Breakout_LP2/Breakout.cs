using System;
using System.Threading;
using System.Diagnostics;

namespace Breakout_LP2 {
    class Breakout {

        // Variáveis de instância
        private DoubleBuffer2D<int> simWorld;
        private Random random;
        private IRenderer renderer;
        private Stopwatch sw;
        private bool quit;

        // Construtor
        public Breakout(
            int xdim, int ydim, double aliveProb, IRenderer renderer) {
            quit = false;
            // Inicializar gerador de números aleatórios
            random = new Random();

            // Criar double buffer onde vamos guardar o mundo
            simWorld = new DoubleBuffer2D<int>(xdim, ydim);

            // Guardar renderer
            this.renderer = renderer;

            // Inicializar mundo
            for (int y = 0; y < ydim; y++) {
                for (int x = 0; x < xdim; x++) {
                    // Células estão vivas com probabilidade aliveProb
                    simWorld[x, y] = 0;
                }
            }

            // Garantir que mundo inicializado fica disponível para leitura
            simWorld.Swap();
            sw = new Stopwatch();
        }

        // Método que implementa o game loop
        public void GameLoop(int msFramesPerSecond) {
            double t = 0.0;
            double dt = 0.01;

            double currentTime = Stopwatch.GetTimestamp();
            double accumulator = 0.0;

            // Setup inicial do renderizador
            renderer.Setup(simWorld);

            // Iniciar game loop
            while (!quit) {
                double newTime = Stopwatch.GetTimestamp();
                double frameTime = newTime - currentTime;
                currentTime = newTime;

                accumulator += frameTime;

                // Fazer o input do jogador aqui

                while (accumulator >= dt) {
                    // Realizar um passo da simulação usando o Update Method
                    // pattern
                    foreach (int x in simWorld) {
                        //x.Update();
                    }
                    accumulator -= dt;
                    t += dt;
                }


                // Fazer swap do buffer e envia-lo para o renderer
                simWorld.Swap();

                renderer.Render(simWorld);
            }
        }
    }
}
