using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    void Awake()
    {
        instance = this;
    }

    public GameObject player;
    public bool isCroutching; // was used for a sneaking mechanic but nah
    public bool promptPlayer; // toggles when entering an interactable's trigger volume
    public bool canMove = true;

    public int health = 100;
    void Update()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    
}
