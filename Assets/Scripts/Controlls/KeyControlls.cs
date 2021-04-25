using System.Collections;
using UnityEngine;

namespace Asteroids
    {
    public class KeyControlls : MonoBehaviour, IExecute , IMoveControlls, IActionControlls
        {
        private IMoveControlls _moveControlls;
        private IActionControlls _actionControlls;

        public KeyControlls(IMoveControlls moveControlls, IActionControlls actionControlls)
            {
            _moveControlls = moveControlls;
            _actionControlls = actionControlls;
            }

        public void Execute()
            {
            Moving();
            Action();
            }

        public void Moving()
            {
            _moveControlls.Moving();
            }

        public void Action()
            {
            _actionControlls.Action();
            }
        }
    }