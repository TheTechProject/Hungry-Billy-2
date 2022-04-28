using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject passenger;
    private GameObject spawnedPassenger;
    private float timer;
    private float timerTarget;
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
        if(spawnedPassenger == null)
        {
            timer += Time.deltaTime;
        }
        if (timer >= timerTarget)
        {
            spawnedPassenger = Instantiate(passenger, transform.position, Quaternion.identity);
            timerTarget = Random.Range(minTimer, maxTimer);
        }
    }
}
