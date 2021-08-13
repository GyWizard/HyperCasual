using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HyperCasualTest
{
    internal class LevelSetUp
    {
        private List<WayPoint> _wayPoints;
        private EnemyFactory _enemyFactory;
        internal LevelSetUp(List<WayPoint> wayPoints, EnemyFactory enemyFactory)
        {
            _wayPoints = wayPoints;
            _enemyFactory = enemyFactory;
            SetUpEnemys();
        }

        void SetUpEnemys()
        {
            foreach (WayPoint wayPoint in _wayPoints)
            {
                if (wayPoint.enemyViews.Count > 0)
                {
                    foreach (EnemyView enemyView in wayPoint.enemyViews)
                    {
                        EnemyController enemy = _enemyFactory.SetUpEnemy(enemyView);
                        enemy.EnemyDied += () => { wayPoint.EnemyEleminated(enemyView); };
                    }
                }
                else
                {
                    wayPoint.cleared = true;
                }
            }
        }
    }
}

