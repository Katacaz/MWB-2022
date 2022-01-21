using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TorchUI : MonoBehaviour
{
    public Player player;
    private Flashlight fl;
    public GameObject flashlightUI;

    [Header("UI References")]
    public TextMeshProUGUI percentText;
    public Image torchBackground;
    public Image torchForeground;
    public GameObject chargingIcon;

    public float uiHideDelay = 3.0f;
    private float uiHideTime;

    private float torchPercent;

    void Start()
    {
        fl = player.flashlight;
        
    }

    // Update is called once per frame
    void Update()
    {
        chargingIcon.SetActive(fl.recharging);
        //Check if Flashlight is On or being Recharged
        if (fl.flEnabled | fl.recharging)
        {
            //Reset Hide time
            uiHideTime = 0;
        } else
        {
            //Let it count up
            uiHideTime += Time.deltaTime;
        }
        //Hide or Show UI if long enough delay
        if (uiHideTime > uiHideDelay)
        {
            flashlightUI.SetActive(false);
        } else
        {
            flashlightUI.SetActive(true);
        }

        //Update UI Percentage and UI Elements
        UpdateUI();
    }

    public void UpdateUI()
    {
        torchPercent = fl.battery / fl.maxBattery;
        Mathf.Clamp01(torchPercent);
        int percentStep = Mathf.RoundToInt(torchPercent * 10.0f);

        torchBackground.fillAmount = percentStep / 10f;
        //color bgColor = new Color(255, Mathf.RoundToInt(255 * torchPercent), 0);
        //torchBackground.color = bgColor;

        percentText.text = Mathf.RoundToInt(percentStep * 10) + "%";

    }
}
