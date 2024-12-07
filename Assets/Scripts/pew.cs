using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Pew : MonoBehaviour
{
    public Transform spawnPoint;
    public float range = 15f;
    public int maxBullets = 10;
    // LineRenderer debugRay;

    Camera cam;
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    // cast a ray from the player's "pew" to whatever's in front of the player's crosshair
    private void Shoot()
    {
        RaycastHit temp;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out temp, Mathf.Infinity))
        {
            GameObject hitObj = temp.collider.gameObject;
            // if the ray hits a enemy destroy it
            if (hitObj.CompareTag("Enemy"))
            {
                hitObj.GetComponent<NavMeshAgent>().enabled = false;
                hitObj.transform.rotation = Quaternion.AngleAxis(90, Vector3.back);
                StartCoroutine(DeathSFX(hitObj));
            }

        }
    }

    IEnumerator DeathSFX(GameObject gameObj)
    {
        gameObj.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1.1f);
        gameObj.SetActive(false);
    }
}
