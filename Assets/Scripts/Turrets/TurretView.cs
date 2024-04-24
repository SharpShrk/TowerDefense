using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretView : MonoBehaviour
{
    [SerializeField] private TurretPresenter _presenter;
    [SerializeField] private GameObject _upgradePanel;
    [SerializeField] private Button _upgradeButton;
    [SerializeField] private Button _closeButton;

    private Turret _turret;

    //конфликт с upgradeView

    private void OnEnable()
    {
        _closeButton.onClick.AddListener(OnCloseButtonClick);
        _upgradeButton.onClick.AddListener(OnUpgradeButtonClick);
        
    }

    private void OnDisable()
    {
        _closeButton.onClick.RemoveListener(OnCloseButtonClick);
        _upgradeButton.onClick.RemoveListener(OnUpgradeButtonClick);
    }

    public void OpenUpgradePanel(Turret turret)
    {
        _upgradePanel.SetActive(true);
        _turret = turret;
    }

    private void OnCloseButtonClick()
    {
        _upgradePanel.SetActive(false);
    }

    private void OnUpgradeButtonClick()
    {
        //логика апгрейда
        Debug.Log(_turret.name + " турель улучшена");
    }
}
