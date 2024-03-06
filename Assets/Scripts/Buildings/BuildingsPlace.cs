using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsPlace : MonoBehaviour
{
    [SerializeField] private GameObject _cellImage;
    private bool _isCellFree;

    public bool IsCellFree => _isCellFree;

    private void Start()
    {
        OpenCell();
    }

    public void OpenCell()
    {
        _isCellFree = true;
        _cellImage.SetActive(true);
    }

    public void CloseCell()
    {
        _isCellFree = false;
        _cellImage.SetActive(false);
    }
}