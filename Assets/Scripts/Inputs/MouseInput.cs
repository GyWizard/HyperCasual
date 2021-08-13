using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HyperCasualTest
{
    internal class MouseInput : InputBase
    {
        internal override bool Tap()
        {
            if(Input.GetMouseButtonDown(0))
            {
                tapPosition = Input.mousePosition;
                Taped?.Invoke();
                return true;
            }
            tapPosition = Vector3.zero;
            return false;
        }
    }    
}

