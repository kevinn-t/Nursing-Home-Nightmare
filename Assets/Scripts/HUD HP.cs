using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDHP : MonoBehaviour
{
    TextMeshProUGUI healthLabel;
    void Start()
    {
        healthLabel = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        healthLabel.text = "Health: " + PlayerManager.instance.health.ToString();
    }
}
