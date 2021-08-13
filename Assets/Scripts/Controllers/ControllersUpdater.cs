using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace HyperCasualTest
{
    internal class ControllersUpdater
    {
        private List<IUpdate> _listOfUpdateControllers;
        private List<IFixedUpdate> _listOfFixedUpdateControllers;

        private List<ILateUpdate> _listOfLateUpdateControllers;


        internal ControllersUpdater()
        {
            _listOfUpdateControllers = new List<IUpdate>();
            _listOfFixedUpdateControllers = new List<IFixedUpdate>();
            _listOfLateUpdateControllers = new List<ILateUpdate>();
        }

        internal void AddController(IController controller)
        {
            if (controller is IUpdate updateController)
            {
                _listOfUpdateControllers.Add(updateController);
            }
            if (controller is IFixedUpdate fixedUpdateController)
            {
                _listOfFixedUpdateControllers.Add(fixedUpdateController);
            }
            if (controller is ILateUpdate lateUpdateController)
            {
                _listOfLateUpdateControllers.Add(lateUpdateController);
            }
        }

        internal void RemoveController(IController controller)
        {
            if (controller is IUpdate updateController)
            {
                _listOfUpdateControllers.Remove(updateController);
            }
            if (controller is IFixedUpdate fixedUpdateController)
            {
                _listOfFixedUpdateControllers.Remove(fixedUpdateController);
            }
            if (controller is ILateUpdate lateUpdateController)
            {
                _listOfLateUpdateControllers.Remove(lateUpdateController);
            }
        }

        internal void Update()
        {
            for (int i = 0; i < _listOfUpdateControllers.Count; i++)
            {
                _listOfUpdateControllers[i].Update();
            }
        }

        internal void FixedUpdate()
        {
            for (int i = 0; i < _listOfFixedUpdateControllers.Count; i++)
            {
                _listOfFixedUpdateControllers[i].FixedUpdate();
            }
        }

        internal void LateUpdate()
        {
            for (int i = 0; i < _listOfLateUpdateControllers.Count; i++)
            {
                _listOfLateUpdateControllers[i].LateUpdate();
            }
        }

    }
}

