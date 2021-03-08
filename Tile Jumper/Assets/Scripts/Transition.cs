using UnityEngine;

public class Transition : MonoBehaviour
{
    public CanvasGroup transition;
    public LeanTweenType TransitionCurve;
    public float Speed;
    void Start()
    {
        transition.alpha = 1;

        transition.LeanAlpha(0, Speed).setEase(TransitionCurve).setOnComplete(Enabled);

    }

    void Enabled()
    {
        gameObject.SetActive(false);
    }
}
