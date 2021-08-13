using UnityEngine;
using System;
namespace HyperCasualTest
{
    internal abstract class InputBase
    {
        internal abstract bool Tap();   
        internal Vector3 tapPosition; 
        internal Action Taped;

    }

}
