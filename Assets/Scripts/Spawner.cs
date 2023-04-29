using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Spawner : MonoBehaviour
    {

        [SerializeField] private GameObject _platformPrefab;
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private GameObject[] _cubeWallPrefab;
        [SerializeField] private GameObject _allObjects;

        private int _numberPlatformOnTheSceen = 4;
        private Vector3 _lastPlatformPos = Vector3.zero;

        public void StartGame()
        {
            for(int i = 0; i <= _numberPlatformOnTheSceen; i++)
            {
                SpawnPlatform();
            }
        }

        public void SpawnPlatform()
        {
            var newPlatform = Instantiate(_platformPrefab, new Vector3(0, -0.5f, _lastPlatformPos.z + 15), Quaternion.identity);

            newPlatform.transform.SetParent(_allObjects.transform);

            var _randomIndex = Random.Range(0, 6);

            var wall = Instantiate(_cubeWallPrefab[_randomIndex]);
            wall.transform.SetParent(newPlatform.transform);
            wall.transform.localPosition = Vector3.zero;

            _lastPlatformPos = newPlatform.transform.position;
        }

        public void RestartPosition()
        {
            _lastPlatformPos = Vector3.zero;
            _playerPrefab.transform.position = new Vector3(0, 0, -5);
        }
    }
}