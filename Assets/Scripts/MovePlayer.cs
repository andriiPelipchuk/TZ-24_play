using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts 
{
    public class MovePlayer : MonoBehaviour
    {
        private int _speed = 3; 
        private Vector2 _touchOrigin = -Vector2.one;

        private void FixedUpdate()
        {
            float moveHorizontal = 0f;

            if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0)
            {
                Move(Input.GetAxis("Horizontal"));
            }
            else if(Input.touchCount > 0)
            {
                Touch touch = Input.touches[0];

                if (touch.phase == TouchPhase.Began)
                {
                    _touchOrigin = touch.position;
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    float delta = touch.position.x - _touchOrigin.x;
                    moveHorizontal = delta / Screen.width * 2f;
                }
                else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                {
                    _touchOrigin = -Vector2.one;
                }
                Move(moveHorizontal);
            }
            MoveForvard();
        }

        public void SetSpeed(int speed)
        {
            _speed = speed;
        }

        private void Move(float directionValue)
        {
            float moveHorizontal = directionValue * _speed * Time.fixedDeltaTime;

            transform.Translate(moveHorizontal, 0, 0);
            
        }
        private void MoveForvard()
        {
            transform.Translate(0, 0, 1 * _speed * Time.fixedDeltaTime);
        }

    }
}

