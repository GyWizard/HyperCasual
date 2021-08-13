using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HyperCasualTest
{
    internal class Waypoints : MonoBehaviour
    {
        internal List<WayPoint> wayPoints;

        public void AddWayPoints()
        {
            wayPoints = new List<WayPoint>();
            foreach(WayPoint wayPoint in transform.GetComponentsInChildren<WayPoint>())
            {
                wayPoints.Add(wayPoint);
            }
        }
    }    
}

