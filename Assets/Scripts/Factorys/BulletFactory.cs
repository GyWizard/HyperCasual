using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HyperCasualTest
{
    internal class BulletFactory
    {
        private ControllersUpdater _controllersUpdater;
        private BulletConfig _bulletConfig;
        internal BulletFactory(ControllersUpdater controllersUpdater)
        {
            _controllersUpdater = controllersUpdater;
            _bulletConfig = Resources.Load<BulletConfig>("Configs/BulletConfig");
        }

        internal BulletController CreateBullet(BulletPool pool)
        {
            BulletView view = Object.Instantiate(Resources.Load<BulletView>("Prefabs/Bullet"), pool.root);
            view.gameObject.SetActive(false);
            BulletController bulletController = new BulletController(view, pool, _bulletConfig.lifeTime, _bulletConfig.bulletDamage);
            _controllersUpdater.AddController(bulletController);
            return bulletController;
        }

    }
}

