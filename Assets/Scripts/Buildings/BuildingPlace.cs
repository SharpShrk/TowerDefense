using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlace : MonoBehaviour
{
    [SerializeField] private GameObject _cellImage;
    [SerializeField] private Transform _installationPoint;
    [SerializeField] private bool _isTurretPlace;

    private bool _isCellFree;

    public bool IsTurretPlace => _isTurretPlace;

    public Transform InstallationPoint => _installationPoint;

    public bool IsCellFree => _isCellFree;

    private void Start()
    {
        OpenCell();
    }

    public void OpenCell()
    {
        _isCellFree = true;
    }

    public void CloseCell()
    {
        _isCellFree = false;
    }

    public void Highlight()
    {
        _cellImage.SetActive(true);
    }

    public void ClearHighlight()
    {
        _cellImage.SetActive(false);
    }
}