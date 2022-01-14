using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Inventory inventory;
    public Flashlight flashlight;

    public PlayerInteraction playerInteraction;

    // Start is called before the first frame update
    void Start()
    {
        
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
        if (Input.GetKeyDown(KeyCode.E))
        {
            playerInteraction.InteractWithObject();
        }
    }
}
