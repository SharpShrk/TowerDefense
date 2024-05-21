using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPresenter : MonoBehaviour
{
    //конфликт с upgradePresenter

    [SerializeField] private TurretView _view;

    public void ShowTurretInfo(Turret turret)
    {
        _view.OpenUpgradePanel(turret);
    }
}