using GameEngine;
using System;

namespace Breakout_LP2
{
    class Brick : Component
    {
        public override void Finish()
        {
            ParentScene.DestroyObject(ParentGameObject);
        }
    }
}
