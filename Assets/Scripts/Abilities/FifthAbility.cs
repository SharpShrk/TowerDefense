using UnityEngine;

namespace Abilities
{
    public class FifthAbility : Ability
    {
        public override void Activate()
        {
            base.Activate();
            Debug.Log("Fifth ability");
        }
    }
}