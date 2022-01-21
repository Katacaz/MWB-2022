using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PromptUI : MonoBehaviour
{
    public Player player;
    public GameObject promptUI;
    public TextMeshProUGUI promptText;
    public TextMeshProUGUI interactKeyText;
    public string defaultPromt = "Interact";
    public string defaultPromptError = "Missing Item";

    // Start is called before the first frame update
    void Start()
    {
        interactKeyText.text = player.interactKey.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.playerInteraction.objectInSight != null)
        {
            promptUI.SetActive(true);
            if (player.playerInteraction.objectInSight.CanInteract())
            {
                promptText.color = Color.white;
                string pt = player.playerInteraction.objectInSight.interactPrompt;
                if (pt == null | pt == "")
                {
                    pt = defaultPromt;
                }
                promptText.text = pt;
            } else
            {
                promptText.color = Color.red;
                string pt = player.playerInteraction.objectInSight.missingItemPrompt;
                if (pt == null | pt == "")
                {
                    pt = defaultPromptError;
                }
                promptText.text = pt;
            }
        } else
        {
            promptUI.SetActive(false);
            promptText.text = "";
        }
    }
}
