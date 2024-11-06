using System;
using UnityEngine;

namespace EnemyLogic
{
    [RequireComponent(typeof(EnemyHealth))]
    public class EnemyPointer : MonoBehaviour
    {
        private PointerHandler _pointerHandler;

        public void Init(PointerHandler pointerHandler)
        {
            _pointerHandler = pointerHandler;
        }

        public void Destroy()
        {
            _pointerHandler.RemoveFromList(this);
        }
    }
}