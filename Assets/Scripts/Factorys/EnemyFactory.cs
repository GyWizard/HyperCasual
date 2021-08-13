using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace HyperCasualTest
{
    internal class EnemyFactory
    {
        private ControllersUpdater _controllersUpdater;
        private Transform _cameraTransform;
        private EnemyConfig _enemyConfig;
        internal EnemyFactory(ControllersUpdater controllersUpdater)
        {
            _controllersUpdater = controllersUpdater;
            _cameraTransform = Camera.main.transform;
            _enemyConfig = Resources.Load<EnemyConfig>("Configs/EnemyConfig");
        }

        internal EnemyController SetUpEnemy(EnemyView view)
        {
            view.InitEnemyView();
            EnemyController  enemyController = new EnemyController(view, _enemyConfig.health);

            HealthBarView healthBarView  = Object.Instantiate(Resources.Load<HealthBarView>("Prefabs/UI/HealthBar"),view.canvas.transform);
            HealthBarController healthBarController = new HealthBarController(healthBarView,_cameraTransform,_enemyConfig.health);
            _controllersUpdater.AddController(healthBarController);

            view.TakeDamage += healthBarController.TakeDamage;
            
            _controllersUpdater.AddController(enemyController);
            enemyController.EnemyDied  += () => { _controllersUpdater.RemoveController(enemyController); };

            return enemyController;
        }
    }

}
