using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject passenger;
    private GameObject spawnedPassenger;
    private float timer;
    private float timerTarget;
    // The minimum and maximum ranges for spawning times
    [SerializeField] private float minTimer = 10.0f;
    [SerializeField] private float maxTimer = 60.0f;

    // Start is called before the first frame update
    void Start()
    {
        timerTarget = Random.Range(minTimer, maxTimer);
    }

    // Update is called once per frame
    void Update()
    {
        // Constantly counts up when theres no passenger spawned here
        if(spawnedPassenger == null)
        {
            timer += Time.deltaTime;
        }

        // Spawns the passenger when the target is reached then sets a new target timer.
        if (timer >= timerTarget)
        {
            spawnedPassenger = Instantiate(passenger, transform.position, Quaternion.identity);
            timerTarget = Random.Range(minTimer, maxTimer);
        }
    }
}
