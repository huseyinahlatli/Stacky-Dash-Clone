using Singleton;
using UnityEngine;

namespace Player
{
    public class PlayerAnimations : Singleton<PlayerAnimations>
    {
        [SerializeField] private Animator animator;

        public void SetAnimation(string parameter ,bool state)
        {
            animator.SetBool(parameter, state);
        }
    }
}
