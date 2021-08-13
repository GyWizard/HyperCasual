using System;
using UnityEngine;
namespace HyperCasualTest
{
    internal class EnemyView : AnimatedInteractView
    {
        internal Action<float> TakeDamage;
        internal Canvas canvas;
        internal override void Awake()
        {
            
        }
        internal void InitEnemyView()
        {
            base.Awake();
            canvas = GetComponentInChildren<Canvas>();
        }
    }
}
