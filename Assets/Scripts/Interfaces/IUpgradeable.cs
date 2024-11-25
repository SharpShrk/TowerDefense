using UnityEngine;

namespace Interfaces
{
    public interface IUpgradeable
    {
        GameObject gameObject { get; }

        void Upgrade();
    }
}