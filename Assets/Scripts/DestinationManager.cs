using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationManager : MonoBehaviour
{
    private Zone currentDestinationZone;
    private Transform currentDestination;
    [SerializeField] private Zone beach;
    [SerializeField] private Zone city;
    [SerializeField] private Zone houses;
    [SerializeField] private Zone airport;

    [SerializeField] private GameObject indicator;

    private GameObject passengerGameObjectInRange;
    private bool passengerInCar = false;

    float distanceFromDestination;

    private void GetNewDestination()
    {
        int chosenZoneNum = Random.Range(1, 4);
        switch (chosenZoneNum)
        {
            case 1:
                currentDestinationZone = beach;
                break;
            case 2:
                currentDestinationZone = city;
                break;
            case 3:
                currentDestinationZone = houses;
                break;
            case 4:
                currentDestinationZone = airport;
                break;
        }

        currentDestination = currentDestinationZone.GetRandomRoadDestination();
        indicator.SetActive(true);
        indicator.transform.position = currentDestination.position;
    }

    private bool CheckDistanceFromDestination()
    {
        distanceFromDestination = Vector3.Distance(currentDestination.position, transform.position);
        if (distanceFromDestination < 10.0f)
            return true;
        else
            return false;
    }

    private void Start()
    {
        indicator.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (passengerGameObjectInRange != null && passengerInCar == false)
            {
                Destroy(passengerGameObjectInRange);
                GetNewDestination();
                passengerInCar = true;
            }
        }

        if (passengerInCar)
        {
            bool passengerDroppedOf = CheckDistanceFromDestination();
            if (passengerDroppedOf)
            {
                passengerInCar = false;
                indicator.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Passenger")
        {
            passengerGameObjectInRange = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Passenger")
        {
            passengerGameObjectInRange = null;
        }
    }
}
