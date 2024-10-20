using UnityEngine;

namespace Abilities
{
    public class FirstAbility : Ability
    {
        public override void Activate()
        {
            base.Activate();
            Debug.Log("first ability");
        }
    }
}