using System;
using System.Collections.Generic;
using UnityEngine;

namespace HyperCasualTest
{
    internal class MoveByWaypoints : PlayerMove
    {
        private List<WayPoint> _waypoints;
        private int _currentWayPoint;
        private Transform _transform;
        private Vector3 _direction;
        private Vector3 _gravityMovement;
        private Vector3 _rotateToPosition;
        private CharacterController _characterController;
        private float _gravityValue = 9.81f;
        private float _minDistanceToReachWaypoint = 0.1f;

        internal MoveByWaypoints(float speed, float rotateSpeed, PlayerView view, List<WayPoint> waypoints)
        {
            _speed = speed;
            _rotateSpeed = rotateSpeed;
            _characterController = view.characterController;
            _transform = view.transform;
            _waypoints = waypoints;
            _currentWayPoint++;
        }

        internal override void Move()
        {
            if (startMove)
            {
                if (moving)
                {
                    CheckEndOfWayPoint();
                    MoveToWayPoint();
                    Rotate();
                }
            }
        }

        void CheckEndOfWayPoint()
        {
            if (Vector3.Distance(_transform.position, _waypoints[_currentWayPoint].transform.position) < _minDistanceToReachWaypoint)
            {
                if (_waypoints[_currentWayPoint].IsStoped)
                {
                    moving = false;
                    if (!_waypoints[_currentWayPoint].cleared)
                    {
                        _waypoints[_currentWayPoint].ActivateWayPoint();
                        _waypoints[_currentWayPoint].WayPointCleared += ChooseNewWayPoint;
                    }
                    else
                    {
                        ChooseNewWayPoint();
                    }
                }
                else
                {
                    ChooseNewWayPoint();
                }
            }
        }

        void ChooseNewWayPoint()
        {
            _waypoints[_currentWayPoint].active = false;
            _currentWayPoint++;
            if(_currentWayPoint >= _waypoints.Count)
            {
                _currentWayPoint--;
                startMove = false;
                EndReached?.Invoke();
                return;
            }
            moving = true;
        }

        void MoveToWayPoint()
        {
            _direction = _waypoints[_currentWayPoint].transform.position - _transform.position;

            _direction = _direction.normalized * _speed * Time.deltaTime;
            _gravityMovement = Vector3.down * _gravityValue * Time.deltaTime;
            _characterController.Move(_direction + _gravityMovement);
        }

        void Rotate()
        {
            _rotateToPosition = new Vector3(_waypoints[_currentWayPoint].transform.position.x, _transform.position.y, _waypoints[_currentWayPoint].transform.position.z);
            _transform.rotation = Quaternion.RotateTowards(_transform.rotation, Quaternion.LookRotation(_rotateToPosition - _transform.position), Time.deltaTime * _rotateSpeed);
        }

    }
}

