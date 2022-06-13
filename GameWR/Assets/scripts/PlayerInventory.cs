using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
  
    public static int NumberOfDiamonds { get; set; }
    public  UnityEvent<PlayerInventory> onDiamondCollected;

    public  void DiamondsCollected() 
    {
            NumberOfDiamonds++;
            onDiamondCollected.Invoke(this);
    }

    public int GetNumberOfDiamonds() 
    {
        return NumberOfDiamonds;
    }

    public void SetNumberOfDiamonds() 
    {
        NumberOfDiamonds = 0;
    }

}
