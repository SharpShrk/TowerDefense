using UnityEngine;

namespace Abilities
{
    public class ThirdAbility : Ability
    {
        public override void Activate()
        {
            base.Activate();
            Debug.Log("third ability");
        }
    }
}