using UI;
using UnityEngine;

public class BuildingText : TutorialText
{
    [SerializeField] private TurretsPanel _turretsPanel;

    public override void Activate()
    {
        _turretsPanel.gameObject.SetActive(true);
    }
}