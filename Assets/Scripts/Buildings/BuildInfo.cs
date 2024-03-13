using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuildInfo : MonoBehaviour
{
    private int _level;
    private TMP_Text _label;

    public int level => _level;
    public TMP_Text Label => _label;

    public void Init(int level, string label)
    {
        _level = level;
        _label.text = label;
    }
}