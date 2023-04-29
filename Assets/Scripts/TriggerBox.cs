using System.Collections;
using UnityEngine;
using System;

namespace Assets.Scripts
{
    public class TriggerBox : MonoBehaviour
    {
        public static Action addBox;
        public LayerMask layerMask;

        private bool _isActive = false;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == 7 || other.gameObject.layer == 6)
            {
                if (!_isActive)
                {
                    _isActive = true;
                    addBox?.Invoke();
                    Destroy(gameObject);
                }
            }


        }
    }
}