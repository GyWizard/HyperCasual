using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HyperCasualTest
{
    internal class BulletPool
    {
        Queue<BulletController> bullets;
        internal Transform root;
        private BulletFactory _bulletFactory;

        internal BulletPool(BulletFactory bulletFactory)
        {
            bullets = new Queue<BulletController>();
            GameObject root = new GameObject();
            root.name = "BulletPool";
            this.root = root.transform;
            _bulletFactory = bulletFactory;
        }

        internal BulletController GetBullet()
        {
            if (bullets.Count == 0)
            {
                bullets.Enqueue(_bulletFactory.CreateBullet(this));
            }
            return bullets.Dequeue();
        }

        internal void ReturnBullet(BulletController bulletController)
        {
            bullets.Enqueue(bulletController);
        }

    }

}
