using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HyperCasualTest
{
    internal class Ragdoll
    {
        private Rigidbody _rigidbody;
        private Collider _collider;
        private Animator _animator;
        private Rigidbody[] _ragdollRigidBodies;
        private Collider[] _ragdollColliders;
        internal Ragdoll(Rigidbody rigidbody, Collider collider, Animator animator)
        {
            _rigidbody = rigidbody;
            _collider = collider;
            _animator = animator;
            SetUpRagdoll();
        }
        void SetUpRagdoll()
        {
            _ragdollRigidBodies = _rigidbody.gameObject.GetComponentsInChildren<Rigidbody>();
            _ragdollColliders = _rigidbody.gameObject.GetComponentsInChildren<Collider>();

            RagdollSetActive(false);
        }
        internal void RagdollSetActive(bool value)
        {

            foreach (Rigidbody rigidbody in _ragdollRigidBodies)
            {
                rigidbody.isKinematic = !value;

            }

            foreach (Collider collider in _ragdollColliders)
            {
                collider.enabled = value;
            }

            _collider.enabled = !value;
            _rigidbody.isKinematic = value;
            _animator.enabled = !value;
        }


    }
}

