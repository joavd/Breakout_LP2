using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;


namespace Breakout_LP2
{
    class GameLoop
    {
        // Variáveis de instância
        private DoubleBuffer2D<Cell> simWorld;
        private Random random;
        private IRendererCell2D renderer;

        // Construtor
        public GameLoop(
            int xdim, int ydim, double aliveProb, IRendererCell2D renderer)
        {
            // Inicializar gerador de números aleatórios
            random = new Random();

            // Criar double buffer onde vamos guardar o mundo
            simWorld = new DoubleBuffer2D<Cell>(xdim, ydim);

            // Guardar renderer
            this.renderer = renderer;

            // Inicializar mundo
            for (int y = 0; y < ydim; y++)
            {
                for (int x = 0; x < xdim; x++)
                {
                    // Células estão vivas com probabilidade aliveProb
                    simWorld[x, y] = new Cell(
                        random.NextDouble() < aliveProb, x, y, simWorld);
                }
            }

            // Garantir que mundo inicializado fica disponível para leitura
            simWorld.Swap();
        }
        public void Game(int msFramesPerSecond)
        {
            // Setup inicial do renderizador
            renderer.Setup(simWorld);

            // Iniciar game loop
            while (true)
            {
                // Obter tempo atual em ticks (10000 ticks = 1 milisegundo)
                long start = DateTime.Now.Ticks;

                // Realizar um passo da simulação usando o Update Method
                // pattern
                foreach (Ball ball in simWorld)
                {
                    ball.Update();
                }

                // Fazer swap do buffer e envia-lo para o renderer
                simWorld.Swap();
                renderer.Render(simWorld);

                // Esperar até ser tempo da próxima iteração
                Thread.Sleep((int)
                    (start / 10000 + msFramesPerSecond
                    - DateTime.Now.Ticks / 10000));
            }
        }
    }
}
