using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class WorkWithBoxArray : MonoBehaviour
    {
        public static Action activeGameOver;

        [SerializeField] private GameObject _boxPrefab;

        [SerializeField] private List<GameObject> _arrayBox = new List<GameObject>();

        public void SpawnBox()
        {
            var newBox = Instantiate(_boxPrefab, new Vector3(0, -0.5f), Quaternion.identity, gameObject.transform);
            _arrayBox.Add(newBox);

            CorrectVerticalPosition();
           
        }

        private void CorrectVerticalPosition()
        {
            for(int i = 0; i < _arrayBox.Count; i++)
            {
                _arrayBox[i].transform.localPosition = new Vector3(0, _arrayBox[i].transform.position.y + 1, 0);
            }
        }
        public void RemoveBox(GameObject box)
        {
            for (int i = 0; i < _arrayBox.Count; i++)
            {
                if (_arrayBox[i] == box)
                {
                    box.transform.SetParent(null);
                    _arrayBox.Remove(_arrayBox[i].gameObject);
                }
            }
            if (_arrayBox.Count <= 1)
                StartCoroutine(CallGameOver());
                
        }
        IEnumerator CallGameOver()
        {
            yield return new WaitForSeconds(0.8f);
            if(_arrayBox.Count <= 1)
                activeGameOver?.Invoke();
        }
        
    }
}