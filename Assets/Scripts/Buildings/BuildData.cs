using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildData : MonoBehaviour
{
    [SerializeField] protected int _level;
    [SerializeField] protected TMP_Text _label;
    //[SerializeField] private Image _icon;
    [SerializeField] protected BuildType _type;
    [SerializeField] protected GameObject _prefab;

    public int level => _level;
    public TMP_Text Label => _label;
    public BuildType Type => _type;
    public GameObject Prefab => _prefab;
    //public Image Icon => _icon;
}