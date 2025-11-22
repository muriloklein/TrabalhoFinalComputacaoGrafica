using UnityEngine;

public class KillRequirementUI : MonoBehaviour
{
    public static KillRequirementUI Instance;

     private void Awake()
     {
          Instance = this;
     }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void ShowMessage()
    {
        gameObject.SetActive(true);
    }

    public void HideMessage()
    {
        gameObject.SetActive(false);
    }
}
