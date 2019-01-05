using GameEngine;

namespace Breakout_LP2
{
    class Time: Component
    {
        public override void Finish()
        {
            ParentScene.DestroyObject(ParentGameObject);
        }
    }
}
