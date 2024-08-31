using UnityEngine;

namespace EnemyLogic
{
    public class EnemyTargetHealth : HealthContainer
    {
        public void SetStartHealth(int startHealt)
        {
            Init(startHealt);
        }       
    }
}