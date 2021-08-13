using System;

namespace HyperCasualTest
{
    internal abstract class PlayerMove
    {
        protected float _speed;
        protected float _rotateSpeed;
        internal bool moving;
        internal abstract void Move();
        internal bool startMove;
        internal Action EndReached;
    }
}
