using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;
using UnityStandardAssets.Cameras;

public class GettingInAndOutOfCars : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField] AutoCam mCamera = null;


    [Header("Human")]
    [SerializeField] GameObject human = null;

    [SerializeField] float closeDistance = 15f;

    [Header("Vehicle")]
    [SerializeField] GameObject car = null;
    [SerializeField] CarUserControl carController = null;
    [SerializeField] CarController carEngine = null;    // dostep do funckji move pojazdu 


    [Header("Input")]
    [SerializeField] KeyCode enterExitKey = KeyCode.E;

    // Start is called before the first frame update
    public bool inCar = false;

    private void Start()
    {
        inCar = !car.activeSelf;
        carEngine.Move(0f, 0f, 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(enterExitKey)) // po nacisnieciu E
        {
            if (inCar)
                GetOutOfCar();
            else if (Vector3.Distance(car.transform.position, human.transform.position) < closeDistance)// sprawdzenie czy jestesmy przy samochodzie
                GetIntoCar();

            
        }

        void GetOutOfCar()
        {
            inCar = false;
            human.SetActive(true);

            human.transform.position = car.transform.position + car.transform.TransformDirection(Vector3.left + Vector3.left + Vector3.up);//umnieszczenie FPS obok auta

            mCamera.SetTarget(human.transform);

            carController.enabled = false; // zalezalo zmienic z false na true

            carEngine.Move(0, 0, 1, 1); // natychmiastowe zatrzymywanie pojazdu

        }

        void GetIntoCar()
        {
            inCar = true;

            human.SetActive(false);

            mCamera.SetTarget(car.transform);

            carController.enabled = true;
        }

    }
}