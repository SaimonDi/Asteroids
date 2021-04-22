using System.Collections;
using UnityEngine;

namespace Asteroids
    {
    public sealed class MoveControlls : IMoveControlls
        {
        private readonly Transform _transform;
        private readonly float _speed;
        private readonly float _acceleration;
        private AccelerationMove moveTransform;
        private RotationShip rotation;
        private Camera _camera;
        private Ship _ship;
        
        public MoveControlls (Transform transform, float speed, float acceleration)
            {
            _transform = transform;
            _speed = speed;
            _acceleration = acceleration;
            }
        public void Moving()
            {
            StartMove();
            InputRotation();
            InputMove();
            InputAcceleration();
            }

        private void StartMove()
            {
            _camera = Camera.main;
            moveTransform = new AccelerationMove(_transform, _speed, _acceleration);
            rotation = new RotationShip(_transform);
            _ship = new Ship(moveTransform, rotation);
            }

        private void InputAcceleration()
            {
            if(Input.GetKeyDown(KeyCode.LeftShift))
                {
                _ship.AddAcceleration();
#if UNITY_EDITOR
                Debug.Log($"Acceleration On {_ship.Speed}");
#endif
                }

            if(Input.GetKeyUp(KeyCode.LeftShift))
                {
                _ship.RemoveAcceleration();
#if UNITY_EDITOR
                Debug.Log($"Acceleration Off {_ship.Speed}");
#endif
                }
            }

        private void InputMove()
            {
            _ship.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Time.deltaTime);
            }

        private void InputRotation()
            {
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(_transform.position);
            _ship.Rotation(direction);
            }
        }
    }