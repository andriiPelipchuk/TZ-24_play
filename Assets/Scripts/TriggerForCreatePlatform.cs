using System.Collections;
using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class TriggerForCreatePlatform : MonoBehaviour
    {

        public static Action triggerPlatform;

        private void OnTriggerExit(Collider other)
        {
            triggerPlatform?.Invoke();
        }
    }
}