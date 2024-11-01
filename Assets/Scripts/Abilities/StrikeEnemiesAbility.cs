using System;

namespace Abilities
{
    public class StrikeEnemiesAbility : Ability
    {
        public event Action Striked;

        public override void Activate()
        {
            base.Activate();
            Striked?.Invoke();
        }
    }
}