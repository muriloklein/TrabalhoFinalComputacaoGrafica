using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject menuOptions;
    public GameObject introScreen;
    public GameObject gameLevels;
    public GameObject gameRanking;
    public GameObject gameCredits;
    public AudioSource selectSound;

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

            if (introScreen != null)
                introScreen.SetActive(false);

            menuOptions.SetActive(true);
            hasStarted = true;
        }
    }

    public void OnNewGameClicked()
    {
        selectSound.Play();

        if (menuOptions != null)
            menuOptions.SetActive(false);

        if (gameLevels != null)
            gameLevels.SetActive(true);
    }

    public void LoadLevel01()
    {
        selectSound.Play();
        SceneManager.LoadScene("Level_1");
    }


    public void OnLeaderboardClicked()
    {
        selectSound.Play();

        if (menuOptions != null)
            menuOptions.SetActive(false);

        if (gameRanking != null)
            gameRanking.SetActive(true);
    }

        public void OnCreditsClicked()
    {
        selectSound.Play();

        if (menuOptions != null)
            menuOptions.SetActive(false);

        if (gameCredits != null)
            gameCredits.SetActive(true);
    }

    public void OnBackClicked()
    {
        selectSound.Play();

        if (gameCredits != null)
            gameCredits.SetActive(false);

        if (gameRanking != null)
            gameRanking.SetActive(false);

        if (gameLevels != null)
            gameLevels.SetActive(false);

        if (menuOptions != null)
            menuOptions.SetActive(true);
    }

    public void ReturnToMenuFromCredits()
    {
        if (gameCredits != null)
            gameCredits.SetActive(false);

        if (menuOptions != null)
            menuOptions.SetActive(true);

        selectSound.Play();
    }


    public void OnExitClicked()
    {
        selectSound.Play();
        Debug.Log("Saindo do jogo...");

        Application.Quit();

    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #endif
    }
    

}
