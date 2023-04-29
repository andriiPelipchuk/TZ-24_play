using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class CameraMove : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        private void FixedUpdate()
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, _player.position.z - 9);
        }
    }
}