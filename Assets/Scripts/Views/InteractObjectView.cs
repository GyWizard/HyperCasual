using UnityEngine;
using System;
namespace HyperCasualTest
{
    internal class InteractObjectView : MonoBehaviour
    {
        internal Rigidbody _rigidbody;
        internal Collider _collider;
        internal virtual void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _collider = GetComponent<Collider>();
        }
        internal Action<Collision> Interact;
        void OnCollisionEnter(Collision collision)
        {
            Interact?.Invoke(collision);
        }
    }


}
