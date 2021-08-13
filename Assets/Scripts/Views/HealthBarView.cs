using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace HyperCasualTest
{
    public class HealthBarView : MonoBehaviour
    {
        public Slider healthSlider;
        public void Awake()
        {
            healthSlider = GetComponent<Slider>();
        }      
    }

}
