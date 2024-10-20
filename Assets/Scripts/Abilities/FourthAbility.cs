using UnityEngine;

namespace Abilities
{
    public class FourthAbility : Ability
    {
        public override void Activate()
        {
            base.Activate();
            Debug.Log("Fourth ability");
        }
    }
}