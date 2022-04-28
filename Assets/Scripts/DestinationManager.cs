using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationManager : MonoBehaviour
{
    // Stores the destination variables
    private Zone currentDestinationZone;
    private Transform currentDestination;

    /*
     * The different zones in the city which the passengers
     * will choose at random when boarding
     */
    [SerializeField] private Zone beach;
    [SerializeField] private Zone city;
    [SerializeField] private Zone houses;
    [SerializeField] private Zone airport;

    // Indicator for the currentDestination
    [SerializeField] private GameObject indicator;

    private GameObject passengerGameObjectInRange; // stores the passengers in pickup range of car
    private bool passengerInCar = false;

    float distanceFromDestination;

    // Stopwatch that counts the time taken to drop off passengers
    [SerializeField] private float currentDropOffTimer;

    [SerializeField] private ScoreManager scoreManager;

    /// <summary>
    /// Chooses a destination zone at random, then has the class for that Zone
    /// choose a random road in the script.
    /// </summary>
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

    /// <summary>
    /// Checks if the taxi is within range of the customers destination.
    /// </summary>
    /// <returns>True if within range of destination. Otherwise false.</returns>
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
        // Indicator is disables until a passenger is picked up
        indicator.SetActive(false);
    }

    private void Update()
    {
        /*
         * Picks up customers within the Trigger collider and
         * runs the function to choose a new destination.
         */
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (passengerGameObjectInRange != null && passengerInCar == false)
            {
                Destroy(passengerGameObjectInRange);
                GetNewDestination();
                passengerInCar = true;
            }
        }

        /*
         * Runs checks while the passenger is in the car for
         * distance between the destination
         */
        if (passengerInCar)
        {
            currentDropOffTimer += Time.deltaTime;
            bool passengerDroppedOf = CheckDistanceFromDestination();
            // Successful drop off and fare awarded
            if (passengerDroppedOf)
            {
                passengerInCar = false;
                indicator.SetActive(false);
                scoreManager.AddPoints(currentDropOffTimer);
                currentDropOffTimer = 0.0f;
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
