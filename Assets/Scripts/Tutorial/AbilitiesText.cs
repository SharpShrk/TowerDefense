using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

public class AbilitiesText : TutorialText
{
    [SerializeField] private AbilitiesPanel _abilitiesPanel;

    public override void Activate()
    {
        _abilitiesPanel.gameObject.SetActive(true);
    }
}