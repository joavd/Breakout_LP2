using System;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;

namespace Breakout_LP2 {
    class Breakout {

        // Variáveis de instância
        private int xd, yd;
        private DoubleBuffer2D<string> simWorld;
        private List<IGameobject> gameobjects;
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
            xd = xdim;
            yd = ydim;

            // Criar double buffer onde vamos guardar o mundo
            simWorld = new DoubleBuffer2D<string>(xdim, ydim);

            gameobjects = new List<IGameobject>();

            // Guardar renderer
            this.renderer = renderer;

            // Inicializar mundo
            for (int y = 0; y < ydim; y++) {
                for (int x = 0; x < xdim; x++) {
                    simWorld[x, y] = " ";
                }
            }

            for (int x = 0; x < xdim; x++) {
                gameobjects.Add(new Brick(x, 3));
                simWorld[x, 3] = gameobjects[gameobjects.Count - 1].Img;
            }

            gameobjects.Add(new Player(xdim / 2, ydim - 3));
            simWorld[xdim / 2, ydim - 3] = gameobjects[gameobjects.Count - 1].Img;
            gameobjects.Add(new Ball(xdim / 2, ydim - 4));
            simWorld[xdim / 2, ydim - 4] = gameobjects[gameobjects.Count - 1].Img;


            // Garantir que mundo inicializado fica disponível para leitura
            simWorld.Swap();
            sw.Start();
        }

        // Método que implementa o game loop
        public void GameLoop(int msFramesPerSecond) {
            renderer.Setup(simWorld);
            double previous = sw.ElapsedMilliseconds;
            double lag = 0.0;
            double ms = 16;

            // Iniciar game loop
            while (!quit) {
                double current = sw.ElapsedMilliseconds;
                double elapsed = current - previous;
                previous = current;
                lag += elapsed;
                
                simWorld.Clear();

                // Input

                while (lag >= ms) {
                    // Mete tudo branco
                    for (int y = 0; y < yd; y++) {
                        for (int x = 0; x < xd; x++) {
                            simWorld[x, y] = " ";
                        }
                    }

                    foreach (IGameobject obj in gameobjects) {
                        if (obj != null) {
                            obj.Update(simWorld);
                        }
                    }
                    
                    foreach (IGameobject obj in gameobjects) {
                        obj.Render(simWorld);
                        simWorld[obj.X, obj.Y] = obj.Img;
                    }
                    lag -= ms;
                }

                simWorld.Swap();
                renderer.Render(simWorld);
            }
        }
    }
}

