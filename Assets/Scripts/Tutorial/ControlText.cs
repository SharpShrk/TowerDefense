using TMPro;
using UnityEngine;
using YG;

public class ControlText : TutorialText
{
    [SerializeField] private TMP_Text _mobileControlText;
    [SerializeField] private TMP_Text _desktopControlText;

    public override void Activate()
    {
        if (YandexGame.EnvironmentData.isMobile)
        {
            _mobileControlText.gameObject.SetActive(true);
        }
        else
        {
            _desktopControlText.gameObject.SetActive(true);
        }
    }
}
