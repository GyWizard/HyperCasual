
using UnityEngine;

namespace HyperCasualTest
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/Player")]
    public class PlayerConfig : ScriptableObject
    {
        public float speed;
        public float turnSpeed;
        public float shootPower;
    }

}
