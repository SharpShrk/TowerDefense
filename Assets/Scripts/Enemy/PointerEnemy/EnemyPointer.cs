using UnityEngine;

namespace EnemyLogic
{
    [RequireComponent(typeof(EnemyHealth))]
    public class EnemyPointer : MonoBehaviour
    {
        private EnemyHealth _enemyHealth;
        private PointerHandler _pointerHandler;

        private void Awake()
        {
            _enemyHealth = GetComponent<EnemyHealth>();
        }

        private void OnEnable()
        {
            _enemyHealth.Died += Destroy;
        }

        private void OnDisable()
        {
            _enemyHealth.Died -= Destroy;
        }

        public void Init(PointerHandler pointerHandler)
        {
            _pointerHandler = pointerHandler;
        }

        private void Destroy()
        {
            _pointerHandler.RemoveFromList(this);
        }
    }
}