using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HyperCasualTest
{
    internal class BulletController : IUpdate
    {
        private BulletView _view;
        private float _bulletLifeTime;
        private float _bulletCurrentLifeTime;
        private BulletPool _pool;

        private float _bulletDamage;
        private bool _bulletOn;

        internal BulletController(BulletView view, BulletPool pool, float bulletLifeTime, float bulletDamage)
        {
            _view = view;
            _pool = pool;
            _bulletLifeTime = bulletLifeTime;
            _bulletCurrentLifeTime = _bulletLifeTime;
            _bulletDamage = bulletDamage;
            _view.Interact += Interact;
        }
        public void Update()
        {
            if (_bulletOn)
            {
                _bulletCurrentLifeTime -= Time.deltaTime;
                if (_bulletCurrentLifeTime <= 0f)
                {
                    HideBullet();
                }
            }
        }

        internal void SetUpBullet(Transform gunPoint, Vector3 lookAtTransform)
        {
            _view.trailRenderer.Clear();
            _bulletCurrentLifeTime = _bulletLifeTime;
            _view.transform.position = gunPoint.position;
            _view.transform.LookAt(lookAtTransform);
            _bulletOn = true;
            _view.gameObject.SetActive(true);
        }

        void Interact(Collision collision)
        {
            InteractObjectView interactObject = collision.gameObject.GetComponent<InteractObjectView>();
            if (interactObject != null)
            {
                if (interactObject is EnemyView enemy)
                {
                    enemy.TakeDamage?.Invoke(_bulletDamage);
                }
            }
            HideBullet();
        }

        internal void HideBullet()
        {
            _bulletOn = false;
            _view._rigidbody.velocity = Vector3.zero;
            _view._rigidbody.angularVelocity = Vector3.zero;
            _view.gameObject.SetActive(false);
            _pool.ReturnBullet(this);
        }


        internal void ShootBullet(float force)
        {
            _view._rigidbody.AddForce(_view.transform.forward * force, ForceMode.Impulse);
        }

    }

}
