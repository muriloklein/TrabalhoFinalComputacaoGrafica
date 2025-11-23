using UnityEngine;

public class PlayerBoost : MonoBehaviour
{
    [Header("Configuração do Turbo")]
    public float boostMultiplier = 2f;
    public float maxFuel = 100f;
    public float fuelDrainRate = 25f;
    public float fuelRegenRate = 10f;
    public KeyCode boostKey = KeyCode.Return;

    [Header("Estado")]
    public float currentFuel;
    public bool isBoosting;

    private PlayerController2D controller;

    void Start()
    {
        controller = GetComponent<PlayerController2D>();
        currentFuel = maxFuel;
    }

    void Update()
    {
        HandleBoost();
    }

    void HandleBoost()
    {
        bool keyPressed = Input.GetKey(boostKey);

        if (keyPressed && currentFuel > 0)
        {
            if (!isBoosting)
                ActivateBoost();

            currentFuel -= fuelDrainRate * Time.deltaTime;
            if (currentFuel <= 0)
            {
                currentFuel = 0;
                DeactivateBoost();
            }
        }
        else
        {
            if (currentFuel < maxFuel)
                currentFuel += fuelRegenRate * Time.deltaTime;

            if (isBoosting)
                DeactivateBoost();
        }
    }

    void ActivateBoost()
    {
        isBoosting = true;
        controller.moveSpeed *= boostMultiplier;
    }

    void DeactivateBoost()
    {
        if (!isBoosting) return;

        isBoosting = false;
        controller.moveSpeed /= boostMultiplier;
    }

    public float FuelPercent()
    {
        return currentFuel / maxFuel;
    }
}
