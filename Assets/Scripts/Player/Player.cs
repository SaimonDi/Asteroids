using UnityEngine;

namespace Asteroids
{
    internal sealed class Player : MonoBehaviour, IExecute
    {
        [SerializeField] private float _hp;
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private Rigidbody2D _bullet;
        [SerializeField] private Transform _barrel;
        [SerializeField] private float _force;
        private IExecute _keyControlls;
        private IMoveControlls _moveControlls;
        private IActionControlls _actionControlls;
        

        private void Start()
        {
            _moveControlls = new MoveControlls(transform, _speed, _acceleration);
            _actionControlls = new ActionControlls(_bullet, _barrel, _force);
            _keyControlls = new KeyControlls(_moveControlls, _actionControlls);
        }

        private void Update()
        {
            Execute();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (_hp <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                _hp--;
            }
        }

        public void Execute()
            {
            _keyControlls.Execute();
            }
        }
}
