using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class SpawnCubeObject : MonoBehaviour
    {
        [SerializeField] private GameObject _cubeGameObjectPrefab;
        private void Start()
        {
            for(int i = (int)transform.position.z -7; i <= (int)transform.position.z + 7; i++)
            {
                if (i == (int)transform.position.z)
                    continue;

                var numberCube = Random.value > 0.3;
                if (numberCube)
                    continue;

                var randomXPos = Random.Range(-2, 2);

                var newCube = Instantiate(_cubeGameObjectPrefab, new Vector3(randomXPos, 0.5f, i), Quaternion.identity);

                newCube.transform.SetParent(gameObject.transform);
            }
        }
    }
}