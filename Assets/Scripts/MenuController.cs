using UnityEngine;
using UnityEngine.InputSystem;

public class MenuController : MonoBehaviour
{
    public GameObject menuOptions;
    public GameObject introScreen;
    public GameObject gameLevels; // <-- Adicione esta referência
    public AudioSource selectSound;

    private bool hasStarted = false;

    void Start()
    {
        menuOptions.SetActive(false);

        if (introScreen != null)
            introScreen.SetActive(true);

        if (gameLevels != null)
            gameLevels.SetActive(false); // Garante que a tela de níveis começa oculta
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

    // Função chamada ao clicar em "New Game"
    public void OnNewGameClicked()
    {
        selectSound.Play();

        if (menuOptions != null)
            menuOptions.SetActive(false);

        if (gameLevels != null)
            gameLevels.SetActive(true);
    }

    // Função chamada ao clicar em "Back"
    public void OnBackClicked()
    {
        selectSound.Play();

        if (gameLevels != null)
            gameLevels.SetActive(false);

        if (menuOptions != null)
            menuOptions.SetActive(true);
    }

    public void OnExitClicked()
    {
        selectSound.Play();
        Debug.Log("Saindo do jogo...");

        // Sai do jogo (funciona apenas no build)
        Application.Quit();

        // Se estiver no editor, isso encerra o modo Play (só para testes)
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #endif
    }

}
