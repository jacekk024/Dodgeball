using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    float throwForce = 600f;
    Vector3 objectPosition;
    float distance;


    public bool canHold = true;
    public GameObject item;
    public GameObject tempParent;
    public bool isHolding = false;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {

        distance = Vector3.Distance(item.transform.position, tempParent.transform.position);
        if (distance >= 3f) { //sprawdzanie odleglosci od przedmiotu
            isHolding = false;
        }

        if (isHolding == true)// sprawdzenie czy przycisk jest przytrzymany
        {

            item.GetComponent<Rigidbody>().velocity = Vector3.zero;
            item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            item.transform.SetParent(tempParent.transform);

            if (Input.GetMouseButtonDown(1)) //rzucanie
            {
                item.GetComponent<Rigidbody>().AddForce(tempParent.transform.forward * throwForce);
                isHolding = false;
            }
        }
        else 
        {

            objectPosition = item.transform.position;
            item.transform.SetParent(null);
            item.GetComponent<Rigidbody>().useGravity = true;
            item.transform.position = objectPosition;


        }
    }

    void OnMouseDown()
    {
        if (distance <= 3f) //sprawdzanie odleglosci od przedmiotu
        {
            isHolding = true;
            item.GetComponent<Rigidbody>().useGravity = false;
            item.GetComponent<Rigidbody>().detectCollisions = true;
        }
    }

    void OnMouseUp()
    {
        isHolding = false;
    }


}
