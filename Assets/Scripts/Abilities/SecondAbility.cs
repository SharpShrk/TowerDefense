using UnityEngine;

namespace Abilities
{
    public class SecondAbility : Ability
    {
        public override void Activate()
        {
            base.Activate();
            Debug.Log("second ability");
        }
    }
}