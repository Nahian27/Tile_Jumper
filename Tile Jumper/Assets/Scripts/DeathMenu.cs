using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using Chronos;

public class DeathMenu : MonoBehaviour
{
    public Transform panel;
    public CanvasGroup background;
    public Clock clock;
    public float Delay;
    public LeanTweenType Curve;

    // Start is called before the first frame update
    void OnEnable()
    {

        clock.localTimeScale = 0;

        background.alpha = 0;
        background.LeanAlpha(1, Delay);

        panel.localPosition = new Vector2(0, -Screen.height * 2);
        panel.LeanMoveLocalY(0, Delay).setEase(Curve);
    }

    // Update is called once per frame
    public void Restart()
    {
        background.LeanAlpha(0, Delay);
        panel.LeanMoveLocalY(-Screen.height * 2, Delay).setEase(Curve).setOnComplete(OnRestart);
    }
    private void OnRestart()
    {
        // clock.localTimeScale = 1;
        // gameObject.SetActive(false);
        SceneManager.LoadScene(0);
    }

    public void Rewind()
    {
        background.LeanAlpha(0, Delay);
        panel.LeanMoveLocalY(-Screen.height * 2, Delay).setEase(Curve).setOnComplete(OnRewind);
    }

    private void OnRewind()
    {
        StartCoroutine(RewindCR());
    }

    public IEnumerator RewindCR()
    {
        //Cube.enabled = false;
        clock.localTimeScale = -1;

        yield return new WaitForSeconds(2f);
        clock.localTimeScale = 1;
        gameObject.SetActive(false);
    }
}

