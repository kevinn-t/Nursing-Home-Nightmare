using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    private Light flashLight;
    // Start is called before the first frame update
    void Start()
    {
        flashLight = GetComponent<Light>();
        flashLight.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            flashLight.enabled = (flashLight.isActiveAndEnabled) ? false : true;
        }
    }
}
