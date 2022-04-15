using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private Vector3 Rotation;
    [SerializeField] private float Speed; // szybkosc obracania sie

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Rotation * Speed * Time.deltaTime ); 
    }
}
