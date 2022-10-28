using PathCreation;
using UnityEngine;

namespace Player
{
    public class PathFollower : MonoBehaviour
    {
        [Header ("PathCreator Variables")]
        [SerializeField] private PathCreator pathCreatorFirst;
        [SerializeField] private PathCreator pathCreatorSecond;
        [SerializeField] private PathCreator pathCreatorFinish;
        [Space]
        [SerializeField] private float moveSpeed;

        private float _firstRoadTaken;
        private float _secondRoadTaken;
        private float _lastRoadTaken;

        private void Update()
        {
            if (PathController.Instance.pathCreatorActive)
            {
                _firstRoadTaken -= moveSpeed * Time.deltaTime;
                transform.position = pathCreatorFirst.path.GetPointAtDistance(_firstRoadTaken);
            }

            if (PathController.Instance.pathCreatorBackActive)
            {
                _firstRoadTaken += moveSpeed * Time.deltaTime;
                transform.position = pathCreatorFirst.path.GetPointAtDistance(_firstRoadTaken);
            }

            if (PathController.Instance.pathCreatorSecondActive)
            {
                _secondRoadTaken -= moveSpeed * Time.deltaTime;
                transform.position = pathCreatorSecond.path.GetPointAtDistance(_secondRoadTaken);
            }

            if (PathController.Instance.pathCreatorBackSecondActive)
            {
                _secondRoadTaken += moveSpeed * Time.deltaTime;
                transform.position = pathCreatorSecond.path.GetPointAtDistance(_secondRoadTaken);
            }

            if (PathController.Instance.pathCreatorFinish)
            {
                _lastRoadTaken -= moveSpeed * Time.deltaTime;
                transform.position = pathCreatorFinish.path.GetPointAtDistance(_lastRoadTaken);
            }
        }

        private void TakenTheRoad(float way, PathCreator pathCreator, bool direction)
        {
            if (direction)
                way -= moveSpeed * Time.deltaTime;
            else
                way += moveSpeed * Time.deltaTime;

            var distance = way;
            transform.position = pathCreator.path.GetPointAtDistance(distance);
        }
    }
}
