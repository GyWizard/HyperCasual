using UnityEngine;

namespace HyperCasualTest
{
    internal class PlayerView : AnimatedInteractView
    {
        public Transform gunPoint;
        public CharacterController characterController;
        internal override void Awake()
        {
            base.Awake();
            characterController = GetComponent<CharacterController>();
        }
    }

}
