using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float bombActivateDelay = 3.0f;
    [SerializeField] private float bombExplodeDelay = 1.0f;

    private bool isBombActive = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isBombActive)
        {
            GameObject bombedObject = GameObject.Find(other.name);
            if (bombedObject != null)
            {
Debug.Log(other.name);
                bombedObject.SendMessage("BombExploded", SendMessageOptions.DontRequireReceiver);
            }

            StartCoroutine(BombExplode());
        }
        else
        {
            StartCoroutine(ActivateBombDelay());
        }
    }

    IEnumerator ActivateBombDelay()
    {
        yield return new WaitForSeconds(bombActivateDelay);

        isBombActive = true;
    }

    IEnumerator BombExplode()
    {
        yield return new WaitForSeconds(bombExplodeDelay);

        Destroy(this.gameObject);
    }
}
