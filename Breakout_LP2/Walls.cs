using GameEngine;

namespace Breakout_LP2
{
    class Walls : Component
    {
        public override void Finish()
        {
            ParentScene.DestroyObject(ParentGameObject);
        }
    }
}
