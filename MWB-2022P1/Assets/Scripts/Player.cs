using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Inventory inventory;
    public Flashlight flashlight;

    public PlayerInteraction playerInteraction;

    public FirstPersonMovement fPM;
    [Header("Stamina")]
    public float maxStamina = 100f;
    public float stamina { get; private set; }
    public float staminaUseAmount = 10f;
    public float rechargeAmount = 5f;
    private float staminaRechargeDelay = 1.0f;
    private float staminaRechargeTime;
    public bool outOfStamina;

    [Header("Inputs")]
    public KeyCode interactKey = KeyCode.E;

    // Start is called before the first frame update
    void Start()
    {
        stamina = maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            flashlight.ToggleFlashlight();
        }
        if (Input.GetMouseButtonDown(1))
        {
            flashlight.ToggleRecharge();
        }
        if (Input.GetKeyDown(interactKey))
        {
            playerInteraction.InteractWithObject();
        }

        //Stamina Check
        // First check if out of stamina (prevent running)
        if (outOfStamina)
        {
            fPM.canRun = false;
        } else
        {
            fPM.canRun = true;
        }
        // Then Check if you are running
        if (fPM.IsRunning)
        {
            staminaRechargeTime = 0.0f;
            if (stamina > 0)
            {
                stamina -= staminaUseAmount * Time.deltaTime;
            } else
            {
                outOfStamina = true;
            }

        } else
        {
            if (staminaRechargeTime > staminaRechargeDelay)
            {
                if (stamina < maxStamina)
                {
                    stamina += rechargeAmount * Time.deltaTime;
                } else
                {
                    outOfStamina = false;
                }
                Mathf.Clamp(stamina, 0, maxStamina);
            } else
            {
                staminaRechargeTime += Time.deltaTime;
            }
        }
    }
}
