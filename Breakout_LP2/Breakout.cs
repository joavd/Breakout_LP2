using System;
using System.Threading;
using System.Diagnostics;

namespace Breakout_LP2 {
    class Breakout {

        // Variáveis de instância
        private DoubleBuffer2D<IGameobject> simWorld;
        private Random random;
        private IRenderer renderer;
        private bool quit;
        private Stopwatch sw = new Stopwatch();

        // Construtor
        public Breakout(
            int xdim, int ydim, IRenderer renderer) {
            quit = false;
            // Inicializar gerador de números aleatórios
            random = new Random();

            // Criar double buffer onde vamos guardar o mundo
            simWorld = new DoubleBuffer2D<IGameobject>(xdim, ydim);

            // Guardar renderer
            this.renderer = renderer;

            // Inicializar mundo
            for (int x = 0; x < xdim; x++) {
                simWorld[x, 3] = new Brick(x, 3);
            }

            simWorld[xdim / 2, ydim - 3] = new Player(xdim / 2, ydim - 3);
            simWorld[xdim / 2, ydim - 4] = new Ball(xdim / 2, ydim - 4);


            // Garantir que mundo inicializado fica disponível para leitura
            simWorld.Swap();
            sw.Start();
        }

        // Método que implementa o game loop
        public void GameLoop(int msFramesPerSecond) {
            renderer.Setup(simWorld);
            double previous = sw.ElapsedMilliseconds;
            double lag = 0.0;
            double ms = 160;

            // Iniciar game loop
            while (!quit) {
                double current = sw.ElapsedMilliseconds;
                double elapsed = current - previous;
                previous = current;
                lag += elapsed;

                // Input

                while (lag >= ms) {
                    foreach (IGameobject obj in simWorld) {
                        if (obj != null) {
                            obj.Update(simWorld);
                        }
                    }
                    lag -= ms;
                }

                // Fazer swap do buffer e envia-lo para o renderer
                simWorld.Swap();
                renderer.Render(simWorld);

            }
        }
    }
}

