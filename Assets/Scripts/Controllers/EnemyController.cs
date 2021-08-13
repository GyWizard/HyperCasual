using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace HyperCasualTest
{
    internal class EnemyController : IUpdate
    {
        private EnemyView _view;
        private float _health;
        private Transform objectToSeek;
        private Ragdoll _ragdoll;
        internal Action EnemyDied;

        internal float Health
        {
            get
            {
                return _health;
            }
            private set
            {
                _health = value;
            }
        }
        internal EnemyController(EnemyView view, float health)
        {
            _view = view;
            Health = health;
            _ragdoll = new Ragdoll(view._rigidbody,view._collider,view.animator);
            _view.TakeDamage += TakeDamage;
            EnemyDied += Die;
        }

        public void Update()
        {

        }


        internal void TakeDamage(float damage)
        {
            Health -= damage;
            if(Health<=0)
            {
                EnemyDied?.Invoke();
            }
        }

        void Die()
        {
            _ragdoll.RagdollSetActive(true);
            _view.TakeDamage -= TakeDamage;
        }

    }

}
