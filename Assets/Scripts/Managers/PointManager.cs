using Singleton;
using UnityEngine;

namespace Managers
{
    public class PointManager : Singleton<PointManager>
    {
        public float multiplier = 1f;
        private const float Factor = .1f;
        private int _count;
    
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Color"))
            {
                _count++;
                multiplier += Factor;
                if (_count > 37) { multiplier = 5f; }
            
                GameManager.Instance.SoundFX();
                UIManager.Instance.ScoreIncrease();
            }

            if (other.gameObject.CompareTag("FinishGame"))
            {
                UIManager.Instance.GameOver();
            }
        }
    }
}
