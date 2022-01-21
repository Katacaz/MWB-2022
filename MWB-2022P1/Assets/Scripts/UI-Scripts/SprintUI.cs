using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SprintUI : MonoBehaviour
{
    public Player player;
    public GameObject sprintUI;

    [Header("UI References")]
    public TextMeshProUGUI percentText;
    public Image sprintBackground;
    public Image sprintForeground;
    public GameObject outOfStaminaIcon;

    public float uiHideDelay = 3.0f;
    private float uiHideTime;

    private float sprintPercent;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        outOfStaminaIcon.SetActive(player.outOfStamina);
        //Check if Flashlight is On or being Recharged
        if (player.stamina < player.maxStamina)
        {
            //Reset Hide time
            uiHideTime = 0;
        }
        else
        {
            //Let it count up
            uiHideTime += Time.deltaTime;
        }
        //Hide or Show UI if long enough delay
        if (uiHideTime > uiHideDelay)
        {
            sprintUI.SetActive(false);
        }
        else
        {
            sprintUI.SetActive(true);
        }

        //Update UI Percentage and UI Elements
        UpdateUI();
    }

    public void UpdateUI()
    {
        sprintPercent = player.stamina / player.maxStamina;
        Mathf.Clamp01(sprintPercent);
        int percentStep = Mathf.RoundToInt(sprintPercent * 10.0f);

        sprintBackground.fillAmount = percentStep / 10f;
        //Color bgColor = new Color(255, Mathf.RoundToInt(255 * sprintPercent), 0);
        //sprintBackground.color = bgColor;

        percentText.text = Mathf.RoundToInt(percentStep * 10) + "%";

    }
}
