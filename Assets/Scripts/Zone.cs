using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    public List<Transform> roadsInZone;

    private void Start()
    {
        GetRoadsInZone();
    }

    private void Update()
    {
        
    }

    /// <summary>
    /// Gets all roads childed to the zone for use in navigation.
    /// </summary>
    private void GetRoadsInZone()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            roadsInZone.Add(transform.GetChild(i).transform);
        }
    }

    public Transform GetRandomRoadDestination()
    {
        int highestRoadNumber = roadsInZone.Count - 1;
        int randomArrayNum = Random.Range(0, highestRoadNumber);

        return roadsInZone[randomArrayNum];
    }
}
