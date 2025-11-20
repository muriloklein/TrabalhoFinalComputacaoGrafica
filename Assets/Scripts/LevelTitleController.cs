using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelTitleController : MonoBehaviour
{
    public TMP_Text titleText;  
    public float displayTime = 2f;
    public float fadeTime = 0.5f;

    private CanvasGroup canvasGroup;

    void Awake()
    {
        canvasGroup = gameObject.AddComponent<CanvasGroup>();
        canvasGroup.alpha = 0f;
    }

    void Start()
    {
        StartCoroutine(ShowTitle());
    }

    private IEnumerator ShowTitle()
    {
        float timer = 0f;
        while (timer < fadeTime)
        {
            timer += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, timer / fadeTime);
            yield return null;
        }
        canvasGroup.alpha = 1f;

        yield return new WaitForSeconds(displayTime);

        timer = 0f;
        while (timer < fadeTime)
        {
            timer += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, timer / fadeTime);
            yield return null;
        }
        canvasGroup.alpha = 0f;

        gameObject.SetActive(false);
    }
}
