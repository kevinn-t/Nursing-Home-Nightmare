using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PromptPlayer : MonoBehaviour
{
    // once the player enters & exits a button's trigger collision,
    // PlayerManager.instance.promptPlayer gets toggled
    // this is reflecting that in the HUD
    void Update()
    {
        if (PlayerManager.instance.promptPlayer)
        {
            GetComponent<TextMeshProUGUI>().text = "Press f to Interact";
        }
        else{
            GetComponent<TextMeshProUGUI>().text = "";
        }
    }
    
}
