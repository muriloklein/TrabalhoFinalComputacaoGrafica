using UnityEngine;

public class CreditsFromMenu : MonoBehaviour
{
    public MenuController menuController;

    public void ReturnToMenuFromCredits()
    {
        if (menuController != null)
            menuController.ReturnToMenuFromCredits();
    }
}
