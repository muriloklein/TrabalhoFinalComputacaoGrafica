using UnityEngine;
using UnityEngine.UI;

public class UIFuelBar : MonoBehaviour
{
    public PlayerBoost boost;
    public Image fill;

    void Update()
    {
        fill.fillAmount = boost.currentFuel / boost.maxFuel;  
    }
}
