using Singleton;
using UnityEngine;

namespace Player
{
    public class PlayerController : Singleton<PlayerController>
    {
        private Vector3 _startTouchPosition;
        private Vector3 _currentPosition;
        private Vector3 _endTouchPosition;
    
        public bool swipeRight;
        public bool swipeLeft;
        public bool swipeForward; 
        public bool swipeBack;
        private bool _isMove;
        private bool _isCollision;

        public LayerMask layer;
        public float swipeRange;
        public float swipeSpeed;

        private void Start()
        {
            _isMove = true;
            _isCollision = false;
        }

        private void Update()
        {
            Swipe();
        
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out var hit, 0.55f, layer))
            {
                _isMove = false;
                _isCollision = true;
                PlayerAnimations.Instance.SetAnimation("Surf", false);
                Debug.DrawRay(this.transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
            }
            else
            {
                _isCollision = false;
                PlayerAnimations.Instance.SetAnimation("Surf", true);
            }

            switch (_isMove)
            {
                case true:
                {
                    if (swipeForward) { PlayerAct(Vector3.forward); }
                    if (swipeBack) { PlayerAct(Vector3.back); }
                    if (swipeRight) { PlayerAct(Vector3.right); }
                    if (swipeLeft) { PlayerAct(Vector3.left); }
                    break;
                }
            }
        }

        private void PlayerAct(Vector3 position)
        {
            transform.position += position * (swipeSpeed * Time.deltaTime);
        }

        private void Swipe()
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                _startTouchPosition = Input.GetTouch(0).position;
            }

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                _currentPosition = Input.GetTouch(0).position;
                var distance = _currentPosition - _startTouchPosition;
            
                if (_isCollision)
                {
                    if (distance.x < -swipeRange)
                    {
                        _isMove = swipeLeft = true;
                        transform.rotation = Quaternion.Euler(0,-90,0);
                        swipeRight = swipeForward = swipeBack = false;
                    }
                    else if (distance.x > swipeRange)
                    {
                        _isMove = swipeRight = true;
                        transform.rotation = Quaternion.Euler(0,90,0);
                        swipeLeft = swipeBack = swipeForward = false;
                    }
                    else if (distance.y > swipeRange)
                    {                   
                        _isMove = swipeForward = true;
                        transform.rotation = Quaternion.Euler(0,360,0);
                        swipeBack = swipeLeft = swipeRight = false;
                    }
                    else if (distance.y < -swipeRange)
                    {                   
                        _isMove = swipeBack = true;
                        transform.rotation = Quaternion.Euler(0,-180,0);
                        swipeForward = swipeLeft = swipeRight = false;
                    }
                }
            }
        }
    }
}
