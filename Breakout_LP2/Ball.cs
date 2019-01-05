using System;
using GameEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;


namespace Breakout_LP2
{
    public class Ball : Component
    {
        private int xMove = 1;
        private int yMove = -1;

        // Ball script requries access to the key observer and position
        // components
        private Position position;

        GameObject removeObject;

        // Initialize player
        public override void Start()
        {
            position = ParentGameObject.GetComponent<Position>();
        }

        // Update ball in the current frame
        public override void Update()
        {
            // Get ball position
            float x = position.Pos.X;
            float y = position.Pos.Y;

            removeObject = null;

            foreach (GameObject s in ParentScene.gameObjects.Values.ToList())
            {
                if (s != null)
                {
                    if (s.Name == "Player")
                    {
                        Position positionOther = s.GetComponent<Position>();

                        if (positionOther.Pos.Y - 1 == y
                        && (positionOther.Pos.X + 3 == x
                        || positionOther.Pos.X + 4 == x) 
                        || (positionOther.Pos.X +5 == x 
                        && positionOther.Pos.Y == y))
                        {
                            yMove *= -1;
                            xMove = 1;
                        }
                        else if (positionOther.Pos.Y - 1 == y
                        && (positionOther.Pos.X == x
                        || positionOther.Pos.X + 1 == x)
                        || (positionOther.Pos.X - 1 == x
                        && positionOther.Pos.Y == y))
                        {
                            yMove *= -1;
                            xMove = -1;
                        }
                        else if (positionOther.Pos.Y - 1 == y
                        && positionOther.Pos.X + 2 == x)
                        {
                            yMove *= -1;
                        }
                    }
                    else if ((s.Name != "Ball" && s.Name != "Quitter"))
                    {
                        Position positionOther = s.GetComponent<Position>();
                        if (positionOther.Pos.Y - 1 == y
                            && (positionOther.Pos.X == x
                            || positionOther.Pos.X + 1 == x
                            || positionOther.Pos.X + 2 == x
                            || positionOther.Pos.X + 3 == x)
                            || positionOther.Pos.Y + 1 == y
                            && (positionOther.Pos.X == x
                            || positionOther.Pos.X + 1 == x
                            || positionOther.Pos.X + 2 == x
                            || positionOther.Pos.X + 3 == x))
                        {
                            yMove *= -1;
                            removeObject = s;
                        }
                        else if (positionOther.Pos.X - 1 == x
                           && positionOther.Pos.Y == y
                           || positionOther.Pos.X + 4 == x
                           && positionOther.Pos.Y == y)
                        {
                            xMove *= -1;
                            removeObject = s;
                        }
                    }

                }
                if (removeObject != null)
                {
                    removeObject.Finish();
                }
            }


            // If detects another object changes direction
            // Não sei ver como se encontra outro gameobject
            if (y + yMove >= ParentScene.ydim - 1)
            {
                ParentScene.Terminate();
                Console.WriteLine("Terminei");
            }

            if (x + xMove >= ParentScene.xdim - 1 || x + xMove <= 0)
            {
                xMove *= -1;
            }

            if (y + yMove <= 0)
            {
                yMove *= -1;
            }


            if (true)
            {
                // Moves in the given direction
                x += xMove;
                y += yMove;
            }

            // Make sure ball doesn't get outside of game area
            y = Math.Clamp(y, 1, ParentScene.ydim - 1);

            // Update ball position
            position.Pos = new Vector3(x, y, position.Pos.Z);
        }

        public override void Finish()
        {
            ParentScene.DestroyObject(ParentGameObject);
        }
    }
}
