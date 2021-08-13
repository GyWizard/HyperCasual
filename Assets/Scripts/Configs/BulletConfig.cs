
using UnityEngine;

namespace HyperCasualTest
{
    [CreateAssetMenu(fileName = "BulletConfig", menuName = "Configs/Bullet")]
    public class BulletConfig : ScriptableObject
    {
        public float lifeTime;
        public float bulletDamage;
    }

}
