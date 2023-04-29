using System.Collections;
using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class RemoveBoxArray : MonoBehaviour
    {
        public static Action<GameObject> removeBox;
        public static Action gameOver;
        public LayerMask layerMask;

        private bool _isActive = false;
        private void OnCollisionEnter(Collision collision)
        {
            if (_isActive)
                return;

            if (!_isActive && collision.gameObject.layer == 6)
            {

                gameOver?.Invoke();
                return;
            }

            _isActive = true;

            removeBox?.Invoke(collision.gameObject);
            
        }

    }
}