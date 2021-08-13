using UnityEngine;
namespace HyperCasualTest
{
    internal class PlayerController : IUpdate
    {
        private PlayerView _view;
        private PlayerMove _moveImplementation;
        private PlayerShoot _shootImplementation;
        private InputBase _input;

        internal PlayerController(PlayerView view, InputBase input, PlayerMove moveImplementation, PlayerShoot shootImplementation)
        {
            _view = view;
            _input = input;
            _moveImplementation = moveImplementation;
            _shootImplementation = shootImplementation;
        }

        public void Update()
        {
            if (_input.Tap())
            {
                if(!_moveImplementation.startMove)
                {
                    _moveImplementation.startMove = true;
                    _moveImplementation.moving = true;
                    return;
                }
                _shootImplementation.Shoot();
            }
            _moveImplementation.Move();
            Animator();
        }

        void Animator()
        {
            if(_moveImplementation.moving)
            {
                _view.animator.SetBool("Running", true);
            }
            else
            {
                _view.animator.SetBool("Running", false);
            }
        }


    }
}
