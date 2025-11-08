using UnityEngine;
using UnityEngine.InputSystem;

public class MenuController : MonoBehaviour
{
    public GameObject menuOptions;
    public GameObject introScreen;

    private bool hasStarted = false;

    void Start()
    {
        menuOptions.SetActive(false);
        if (introScreen != null)
            introScreen.SetActive(true);
    }

    void Update()
    {
        if (!hasStarted && Keyboard.current != null && Keyboard.current.anyKey.wasPressedThisFrame)
        {
            if (introScreen != null)
                introScreen.SetActive(false);

            menuOptions.SetActive(true);
            hasStarted = true;
        }
    }
}
