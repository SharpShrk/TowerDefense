using UnityEngine;

namespace GameResources
{
    [RequireComponent(typeof(Animator))]
    public class ResourceAnimator : MonoBehaviour
    {
        private const string Hide = nameof(Hide);

        private readonly int _hideAnimationHash = Animator.StringToHash(nameof(Hide));
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void PlayHideAnimation()
        {
            _animator.SetTrigger(_hideAnimationHash);
        }
    }
}