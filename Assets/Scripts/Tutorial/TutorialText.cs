using UnityEngine;

public abstract class TutorialText : MonoBehaviour
{
    private void OnEnable()
    {
        Activate();
    }

    public virtual void Activate()
    {
    }
}