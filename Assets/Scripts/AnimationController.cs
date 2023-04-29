using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class AnimationController : MonoBehaviour
    {

        private Animator _animator;

        private bool _animIsActive = false;
        private void Start()
        {
            _animator = GetComponent<Animator>();
        }
        private void Update()
        {
            Ray ray = new Ray(transform.position, new Vector3(transform.position.x, -5) - transform.position);
            Physics.Raycast(ray, out RaycastHit hit);
            if(hit.collider != null)
            {
                if(Mathf.Abs( hit.collider.transform.position.y - transform.position.y) < 0.6f)
                    if (!_animIsActive)
                    {
                        _animator.SetBool("Jump", true);
                        _animIsActive = true;
                        StartCoroutine(ChangeBoolData());
                    }
            }
        }

        IEnumerator ChangeBoolData()
        {
            yield return new WaitForSeconds(2);
            _animIsActive = false;
        }
    }
}