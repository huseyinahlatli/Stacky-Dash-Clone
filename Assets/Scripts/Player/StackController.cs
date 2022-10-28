using DG.Tweening;
using Managers;
using Singleton;
using UnityEngine;

namespace Player
{
    public class StackController : Singleton<StackController>
    {
        public Material otherColor;
        private Vector3 _stackPosition;
        private readonly Vector3 _newPosition = new Vector3(0f, 1.20f, 0f);

        private void Start()
        {
            _stackPosition = Vector3.zero;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Stack"))
            {
                GameManager.Instance.SoundFX();
                _stackPosition += _newPosition;
                StackList.Instance.stack.Add(other.gameObject);

                other.gameObject.GetComponent<BoxCollider>().enabled = false;
                other.gameObject.transform.parent = GameObject.Find("Stack").transform;
                other.transform.DOLocalMove(_stackPosition, 0.1f);

                gameObject.transform.GetChild(1).transform.localPosition += _newPosition;
                UIManager.Instance.ScoreIncrease();
            }

            if (other.gameObject.CompareTag("ColorScore"))
                UIManager.Instance.ScoreIncrease();
        
            if (other.gameObject.CompareTag("UnStack"))
            {
                _stackPosition -= _newPosition;
                Destroy(StackList.Instance.stack[^1]);
                StackList.Instance.stack.RemoveAt(StackList.Instance.stack.Count - 1);

                gameObject.transform.GetChild(1).transform.localPosition -= _newPosition;
                other.gameObject.GetComponent<MeshRenderer>().enabled = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("UnStack"))
            {
                other.gameObject.transform.GetComponent<MeshRenderer>().material = otherColor;
                other.gameObject.GetComponent<BoxCollider>().enabled = false;
            }
        }
    }
}
