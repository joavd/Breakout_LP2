using System;
using System.Collections.Generic;
using GameEngine;

namespace Breakout_LP2 {
    /// <summary>
    /// The main scene for the game
    /// </summary>
    public class Breakout {
        // World dimensions
        private int xdim, ydim;

        // The (only) game scene
        private Scene gameScene;

        /// <summary>
        /// Initializes a new instance of the <see cref="Breakout"/> class.
        /// </summary>
        /// <param name="xdim">X dimension of the game window</param>
        /// <param name="ydim">Y dimension of the game windows</param>
        public Breakout(int xdim, int ydim) {
            // Initializes the variables to the given ones 
            this.xdim = xdim;
            this.ydim = ydim;
            // Create scene
            ConsoleKey[] quitKeys = new ConsoleKey[] { ConsoleKey.Escape };
            gameScene = new Scene(xdim, ydim,
                new InputHandler(quitKeys),
                new ConsoleRenderer(xdim, ydim, new ConsolePixel(' ')));

            // Create quitter object
            GameObject quitter = new GameObject("Quitter");
            KeyObserver quitSceneKeyListener = new KeyObserver(new ConsoleKey[]
                { ConsoleKey.Escape });
            // Adds the given components
            quitter.AddComponent(quitSceneKeyListener);
            quitter.AddComponent(new Quitter());
            // Adds the object to the scene
            gameScene.AddGameObject(quitter);

            // Create player object
            char[,] playerSprite =
            {
                { ' ' },
                { ' ' },
                { ' ' },
                { ' ' },
                { ' ' },
                { ' ' },
                { ' ' }
            };
            GameObject player = new GameObject("Player");
            KeyObserver playerKeyListener = new KeyObserver(new ConsoleKey[] {
                ConsoleKey.RightArrow,
                ConsoleKey.LeftArrow});
            // Adds the given components
            player.AddComponent(playerKeyListener);
            Position playerPos = new Position(25f, 35f, 0f);
            player.AddComponent(playerPos);
            player.AddComponent(new Player());
            player.AddComponent(new ConsoleSprite(
                playerSprite, ConsoleColor.Yellow, ConsoleColor.DarkRed));
            // Adds the object to the scene
            gameScene.AddGameObject(player);

            // Ball Object
            char[,] ballSprite =
            {
                { ' ' }
            };
            GameObject ball = new GameObject("Ball");
            Position ballPos = new Position(25f, 30f, 0f);
            // Adds the given components
            ball.AddComponent(ballPos);
            ball.AddComponent(new Ball());
            ball.AddComponent(new ConsoleSprite(
                ballSprite, ConsoleColor.Red, ConsoleColor.Red));
            // Adds the object to the scene
            gameScene.AddGameObject(ball);

            // Bricks Objects
            char[,] brickSprite =
            {
                { ' ' },
                { ' ' },
                { ' ' }
            };

            GameObject[,] brick = new GameObject[xdim, ydim];

            // Creates the bricks
            for (int i = 0; i < 60; i++) {
                for (int j = 5; j < 17; j++) {
                    if (i % 3 == 0) {
                        brick[i, j] = new GameObject("Brick" + i + j);

                        Position brickPos = new Position(i, j, 0f);
                        brick[i, j].AddComponent(brickPos);
                        brick[i, j].AddComponent(new Brick());

                        // Sets the color of the bricks
                        if (j >= 4 && j <= 6) {
                            brick[i, j].AddComponent(new ConsoleSprite(
                            brickSprite, ConsoleColor.White,
                            ConsoleColor.DarkRed));
                            gameScene.AddGameObject(brick[i, j]);
                        } else if (j > 6 && j <= 8) {
                            brick[i, j].AddComponent(new ConsoleSprite(
                            brickSprite, ConsoleColor.White,
                            ConsoleColor.Red));
                            gameScene.AddGameObject(brick[i, j]);
                        } else if (j > 8 && j <= 10) {
                            brick[i, j].AddComponent(new ConsoleSprite(
                            brickSprite, ConsoleColor.White,
                            ConsoleColor.DarkYellow));
                            gameScene.AddGameObject(brick[i, j]);
                        } else if (j > 10 && j <= 12) {
                            brick[i, j].AddComponent(new ConsoleSprite(
                            brickSprite, ConsoleColor.White,
                            ConsoleColor.Green));
                            gameScene.AddGameObject(brick[i, j]);
                        } else if (j > 12 && j <= 14) {
                            brick[i, j].AddComponent(new ConsoleSprite(
                            brickSprite, ConsoleColor.White,
                            ConsoleColor.DarkCyan));
                            gameScene.AddGameObject(brick[i, j]);
                        } else {
                            brick[i, j].AddComponent(new ConsoleSprite(
                            brickSprite, ConsoleColor.White,
                            ConsoleColor.Blue));
                            gameScene.AddGameObject(brick[i, j]);

                        }
                    }
                }
            }


            // Create walls
            GameObject walls = new GameObject("Walls");
            ConsolePixel wallPixel = new ConsolePixel(
                ' ', ConsoleColor.Blue, ConsoleColor.White);
            Dictionary<Vector2, ConsolePixel> wallPixels =
                new Dictionary<Vector2, ConsolePixel>();
            for (int x = 0; x < xdim; x++)
                wallPixels[new Vector2(x, 0)] = wallPixel;
            for (int x = 0; x < xdim; x++)
                wallPixels[new Vector2(x, ydim - 1)] = wallPixel;
            for (int y = 0; y < ydim; y++)
                wallPixels[new Vector2(0, y)] = wallPixel;
            for (int y = 0; y < ydim; y++)
                wallPixels[new Vector2(xdim - 1, y)] = wallPixel;
            // Adds the given components
            walls.AddComponent(new ConsoleSprite(wallPixels));
            walls.AddComponent(new Position(0, 0, 1));
            // Adds object to the scene
            gameScene.AddGameObject(walls);

            // Create game object for showing position
            GameObject pos = new GameObject("Position");
            pos.AddComponent(new Position(1, 0, 10));
            RenderableStringComponent rscPos = new RenderableStringComponent(
                () => $"({playerPos.Pos.X}, {playerPos.Pos.Y})",
                i => new Vector2(i, 0),
                ConsoleColor.DarkMagenta, ConsoleColor.White);
            // Adds the given components
            pos.AddComponent(rscPos);
            // Adds the object to the scene
            gameScene.AddGameObject(pos);


            // Create game object for showing puntuation
            GameObject points = new GameObject("Points");
            points.AddComponent(new Position(50, 0, 10));
            RenderableStringComponent rscPoints = new RenderableStringComponent(
                () => $"({gameScene.points})",
                i => new Vector2(i, 0),
                ConsoleColor.DarkMagenta, ConsoleColor.White);
            // Adds the given components
            points.AddComponent(rscPoints);
            // Adds the object to the scene
            gameScene.AddGameObject(points);
        }

        /// <summary>
        /// Starts the game and runs it in loop
        /// </summary>
        public void Run() {
            // Start game loop
            gameScene.GameLoop();
        }
    }

}


