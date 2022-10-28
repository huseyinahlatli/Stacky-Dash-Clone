using Singleton;
using UnityEngine;

namespace Player
{
    public class PathController : Singleton<PathController>
    {
        public bool pathCreatorActive;
        public bool pathCreatorSecondActive;
        public bool pathCreatorBackActive;
        public bool pathCreatorBackSecondActive;
        public bool pathCreatorFinish;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("PathCreator"))
            {
                if (PlayerController.Instance.swipeForward) { pathCreatorActive = true; }
                if (PlayerController.Instance.swipeBack) { pathCreatorBackActive = false; }
            }

            if (other.gameObject.CompareTag("PathCreatorDisactive"))
            {
                if (PlayerController.Instance.swipeForward) { pathCreatorActive = false; }
                if (PlayerController.Instance.swipeBack) { pathCreatorBackActive = true; }
            }

            if (other.gameObject.CompareTag("PathCreatorSecond"))
            {
                if (PlayerController.Instance.swipeForward) { pathCreatorSecondActive = true; }
                if (PlayerController.Instance.swipeBack) { pathCreatorBackSecondActive = false; }
            }

            if (other.gameObject.CompareTag("PathCreatorDisactiveSecond"))
            {
                if (PlayerController.Instance.swipeForward) { pathCreatorSecondActive = false; }
                if (PlayerController.Instance.swipeBack) { pathCreatorBackSecondActive = true; }
            }

            if (other.gameObject.CompareTag("PathCreatorFinish"))
            {
                if (PlayerController.Instance.swipeForward) { pathCreatorFinish = true; }
            }

            if (other.gameObject.CompareTag("Disable") && PlayerController.Instance.swipeForward)
            {
                pathCreatorFinish = false;
                PlayerAnimations.Instance.SetAnimation("EndGame", true);
            }
        }
    }
}
