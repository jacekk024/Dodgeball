using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null) { // sprawdznie kolizji z diamentem

            playerInventory.DiamondsCollected(); // zwieksza liczbe diamentow
            gameObject.SetActive(false); // usun diament
        
        }

    }
}
