using UnityEngine;
using TMPro;

public class KillUI : MonoBehaviour
{
    public TMP_Text killText;

    void Update()
    {
        killText.text = "Kills: " + GameManager.Instance.GetDestroyed();
    }
}
