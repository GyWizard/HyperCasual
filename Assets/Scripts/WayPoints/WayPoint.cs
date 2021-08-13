using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace HyperCasualTest
{
    internal class WayPoint : MonoBehaviour
    {
        public bool IsStoped;
        public List<EnemyView> enemyViews;
        public Action WayPointCleared;
        public Action WayPointActivated;
        internal bool active;
        internal bool cleared;
        public void EnemyEleminated(EnemyView enemy)
        {
            enemyViews.Remove(enemy);
            if (enemyViews.Count == 0)
            {
                if (active)
                {
                    WayPointCleared?.Invoke();
                }
                cleared = true;
                active = false;
            }
        }
        public void ActivateWayPoint()
        {
            active = true;
            WayPointActivated?.Invoke();
        }

    }
}

