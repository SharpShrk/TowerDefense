using System;

namespace Abilities
{
    public class DestroyEnemiesAbility : Ability
    {
        public event Action EnemiesDestroyed;

        public override void Activate()
        {
            base.Activate();
            EnemiesDestroyed?.Invoke();
        }
    }
}