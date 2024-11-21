using UnityEngine;

public interface IUpgradeable
{
    GameObject gameObject { get; }

    void Upgrade();
}