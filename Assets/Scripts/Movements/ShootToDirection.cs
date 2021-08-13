using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HyperCasualTest
{
    internal class ShootToDirection : PlayerShoot
    {
        private Ray _ray;
        private Vector3 _endPoint;
        private Transform _gunPoint;

        private BulletPool bulletPool;

        private float _shootForce;
        private BulletController _bullet;
        RaycastHit hit;

        private float _distanceFromBehind = 2f;
        private float _rayDistance = 100f;

        InputBase _input;

        internal ShootToDirection(Transform gunPoint, BulletFactory bulletFactory, float shootForce,InputBase input)
        {
            _gunPoint = gunPoint;
            bulletPool = new BulletPool(bulletFactory);
            _shootForce = shootForce;
            _input = input;
        }
        internal override void Shoot()
        {
            _ray = Camera.main.ScreenPointToRay(_input.tapPosition);
            _endPoint = _ray.GetPoint(_rayDistance);
            if (Physics.Raycast(_ray, out hit, _rayDistance))
            {
                    _endPoint = hit.point;
                    if(_endPoint.z - _gunPoint.position.z <= _distanceFromBehind)
                    {
                        _endPoint.z += _gunPoint.position.z - _endPoint.z + _distanceFromBehind;
                    }
            }


            _bullet = bulletPool.GetBullet();
            _bullet.SetUpBullet(_gunPoint, _endPoint);
            _bullet.ShootBullet(_shootForce);

        }
    }

}
