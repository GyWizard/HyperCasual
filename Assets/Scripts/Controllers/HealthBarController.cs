using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HyperCasualTest
{
    internal class HealthBarController : ILateUpdate
    {
        private HealthBarView _view;
        private Transform _camera;
        private bool _active;
        internal HealthBarController(HealthBarView view, Transform camera, float maxHealth)
        {
            _view = view;
            _camera = camera;
            _view.healthSlider.maxValue = maxHealth;
            _view.healthSlider.value = maxHealth;
            _active = true;
        }

        public void LateUpdate()
        {
            if (_active)
            {
                _view.transform.LookAt(_view.transform.position + _camera.forward);
            }
        }

        internal void SetActive(bool value)
        {
            _active = value;
            _view.gameObject.SetActive(value);
        }

        internal void TakeDamage(float damage)
        {
            _view.healthSlider.value = _view.healthSlider.value - damage;
            if (_view.healthSlider.value <= 0)
            {
                SetActive(false);
            }
        }
    }

}
