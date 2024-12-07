using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Open_Door : MonoBehaviour
{
    public GameObject door;
    [SerializeField] private float openSpeed;

    [SerializeField] private ParticleSystem sparks;
    [SerializeField] private GameObject sparkLight;
    

    // open door on in-game button press
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            
            if (Input.GetButton("Interact"))
            {
                OpeningDoor();
                // only used on the final button
                if (sparks != null && sparkLight != null)
                {
                    sparks.Play();
                    StartCoroutine(FlashLight());
                }
            }
        }
    }
    // placeholder for an animation of the door opening
    void OpeningDoor()
    {
        door.GetComponent<Animator>().Play("Door Open");
        door.GetComponent<AudioSource>().Play();
    }
    // prompt the player to press f once close enough to the attached button
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerManager.instance.promptPlayer = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerManager.instance.promptPlayer = false;
        }
    }
    
    private IEnumerator FlashLight()
    {
        sparkLight.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        sparkLight.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        sparkLight.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        sparkLight.SetActive(false);
    }
}
