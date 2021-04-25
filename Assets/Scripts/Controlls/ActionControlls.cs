using System.Collections;
using UnityEngine;

namespace Asteroids
    {
    public sealed class ActionControlls : MonoBehaviour, IActionControlls
        {
        private readonly Rigidbody2D _bullet;
        private readonly Transform _barrel;
        private readonly float _force;

        public ActionControlls(Rigidbody2D bullet, Transform barrel, float force)
            {
            _bullet = bullet;
            _barrel = barrel;
            _force = force;
            }

        public void Action()
            {
            InputFire();
            }

        private void InputFire()
            {
            if(Input.GetButtonDown("Fire1"))
                {
                var temAmmunition = Instantiate(_bullet, _barrel.position, _barrel.rotation);
                temAmmunition.AddForce(_barrel.up * _force);

#if UNITY_EDITOR
                Debug.Log($"Bullet: {_bullet}, position: {_barrel.position}, rotation: {_barrel.rotation}, force: {_barrel.up * _force}");
#endif
                }
            }
        }
    }