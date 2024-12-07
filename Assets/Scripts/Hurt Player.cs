using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    // player takes damage once close enough to baby
    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("player hit by baby");
            PlayerManager.instance.health -= 10;
            StartCoroutine(hitPlayer());
        }
    }
    // limits how frequently the player gets 'hit'
    IEnumerator hitPlayer()
    {
        PlayerManager.instance.health -= 10;
        yield return new WaitForSeconds(0.5f);
    }
}
