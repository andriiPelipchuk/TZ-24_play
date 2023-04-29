using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class DestroyMap : MonoBehaviour
    {

        [SerializeField] GameObject _allObject;

        public void Destroyer()
        {
            for(int i = 0; i < _allObject.transform.childCount; i++)
            {
                Destroy(_allObject.transform.GetChild(i).gameObject);
            }
        }
        public void AddBoxToAllObjects(GameObject box)
        {
            box.transform.SetParent(_allObject.transform);
        }
    }
}