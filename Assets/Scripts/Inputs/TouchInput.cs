using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HyperCasualTest
{
    internal class TouchInput : InputBase
    {
        internal override bool Tap()
        {
            if (Input.touchCount > 0)
            { 
                if(Input.GetTouch(0).phase.Equals(TouchPhase.Began))
                {
                    tapPosition = Input.GetTouch(0).position;
                    Taped?.Invoke();
                    return true;    
                }          
            }
            tapPosition = Vector3.zero;
            return false;
        }
    }

}
