using UnityEngine;

public class ErrorVideoEventText : MonoBehaviour
{
    private int _duration = 3;

    private void OnEnable()
    {
        Invoke(nameof(Hide), _duration);
    }
    
    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
