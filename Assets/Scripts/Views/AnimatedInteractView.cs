using UnityEngine;

namespace HyperCasualTest
{
    internal class AnimatedInteractView : InteractObjectView
    {
        internal Animator animator;
        internal  override void Awake()
        {
            base.Awake();
            animator = GetComponent<Animator>();
            if (!animator)
            {
                animator = GetComponentInChildren<Animator>();
            }
        }
    }
}
