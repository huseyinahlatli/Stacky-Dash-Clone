using Singleton;
using UnityEngine;

namespace Managers
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private AudioClip audioClip;
        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void SoundFX()
        {
            _audioSource.PlayOneShot(audioClip, 1.0f);
        }
    }
}
