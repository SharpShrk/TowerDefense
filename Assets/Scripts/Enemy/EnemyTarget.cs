using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyLogic
{
    public class EnemyTarget : MonoBehaviour
    {
        [SerializeField] private Transform[] _pointsAttack;

        public Transform GetPoint()
        {
            int indexPoint = Random.Range(0, _pointsAttack.Length);
            return _pointsAttack[indexPoint];
        }
    }
}