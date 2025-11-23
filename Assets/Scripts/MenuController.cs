using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuController : MonoBehaviour
{
    [Header("Menu Panels")]
    public GameObject menuOptions;
    public GameObject introScreen;
    public GameObject gameLevels;
    public GameObject gameRanking;
    public GameObject gameCredits;

    [Header("Audio")]
    public AudioSource selectSound;

    [Header("Navigation")]
    public GameObject defaultMenuButton;

    private bool hasStarted = false;

    void Start()
    {
        menuOptions.SetActive(false);

        if (introScreen != null)
            introScreen.SetActive(true);

        if (gameLevels != null)
            gameLevels.SetActive(false);

        if (gameRanking != null)
            gameRanking.SetActive(false);

        if (gameCredits != null)
            gameCredits.SetActive(false);
    }

    void Update()
    {
        if (!hasStarted && Keyboard.current != null && Keyboard.current.anyKey.wasPressedThisFrame)
        {
            selectSound.Play();

            introScreen?.SetActive(false);

            menuOptions.SetActive(true);
            SelectDefaultMenuButton();

            hasStarted = true;
        }
    }

    public void OnNewGameClicked()
    {
        PlayClick();
        menuOptions.SetActive(false);
        gameLevels.SetActive(true);
        DeselectUI();
    }

    public void OnLeaderboardClicked()
    {
        PlayClick();
        menuOptions.SetActive(false);
        gameRanking.SetActive(true);
        DeselectUI();
    }

    public void OnCreditsClicked()
    {
        PlayClick();
        menuOptions.SetActive(false);
        gameCredits.SetActive(true);
        DeselectUI();
    }

    public void OnBackClicked()
    {
        PlayClick();

        gameCredits?.SetActive(false);
        gameRanking?.SetActive(false);
        gameLevels?.SetActive(false);

        menuOptions.SetActive(true);
        SelectDefaultMenuButton();
    }

    public void ReturnToMenuFromCredits()
    {
        gameCredits?.SetActive(false);
        menuOptions.SetActive(true);

        PlayClick();
        SelectDefaultMenuButton();
    }

    public void LoadLevel01()
    {
        PlayClick();
        SceneManager.LoadScene("Level_1");
    }

    public void LoadLevel02()
    {
        PlayClick();
        SceneManager.LoadScene("Level_2");
    }

    public void LoadLevel03()
    {
        PlayClick();
        SceneManager.LoadScene("Level_3");
    }

    public void OnExitClicked()
    {
        PlayClick();
        Debug.Log("Saindo do jogo...");
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    void PlayClick()
    {
        if (selectSound != null)
            selectSound.Play();
    }

    void SelectDefaultMenuButton()
    {
        if (defaultMenuButton == null)
            return;

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(defaultMenuButton);
    }

    void DeselectUI()
    {
        EventSystem.current.SetSelectedGameObject(null);
    }
}
