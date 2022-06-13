using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RndObjSpawner : MonoBehaviour
{

    public GameObject[] myObjects; // aby dodac obiekty musi publiczny 


    private float timeElapsed = 0f;
    private float timer = 15f;

    public int diamondCounter = 0;
    void Update()
    {

        timeElapsed -= 1 * Time.deltaTime;

        if (timeElapsed < 0)
        {
            generateObject();
            timeElapsed = timer;
        }


    }




    void generateObject() 
    {
            diamondCounter++;
        //    //int randomIndex = Random.Range(0, myObjects.Length);
            Vector3 randomSpawnPosition = new Vector3(Random.Range(39, 83), -4, Random.Range(10, 50));
            int i = 0;

            Instantiate(myObjects[i++], randomSpawnPosition, Quaternion.identity);
    }
}