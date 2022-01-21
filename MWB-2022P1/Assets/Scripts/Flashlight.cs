using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    
    public bool flEnabled;
    public float battery { get; private set; }
    public float maxBattery = 100f;
    public float batteryDrain = 1f;
    [SerializeField] private GameObject lightObj;

    public bool recharging;
    public float rechargeAmount = 20f;
    // Start is called before the first frame update
    void Start()
    {
        battery = maxBattery;
    }

    // Update is called once per frame
    void Update()
    {
        lightObj.SetActive(flEnabled);

        if (battery <= 0)
        {
            SetFlashlight(false);
        }
        if (recharging)
        {
            SetFlashlight(false);
            if (battery < maxBattery)
            {
                battery += rechargeAmount * Time.deltaTime;
            } else
            {
                SetRecharge(false);
            }
        }
        if (flEnabled)
        {
            if (battery > 0)
            {
                battery -= batteryDrain * Time.deltaTime;
            }
        }
    }

    public void SetFlashlight(bool setting)
    {
        flEnabled = setting;
    }
    public void ToggleFlashlight()
    {
        flEnabled = !flEnabled;
    }

    public void ToggleRecharge()
    {
        recharging = !recharging;
    }
    public void SetRecharge(bool setting)
    {
        recharging = setting;
    }
}
