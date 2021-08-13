using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HyperCasualTest
{
    internal class BulletView : InteractObjectView
    {
        internal TrailRenderer trailRenderer;

        internal override void Awake()
        {
            base.Awake();
            trailRenderer = GetComponent<TrailRenderer>();
        }
    }

}
