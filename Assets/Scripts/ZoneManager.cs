using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneManager : MonoBehaviour
{
    // Reference to prefab. Drag Prefab into the field in Inspector
    public GameObject zonePrefab;
    private int numZones = 0;


    public void SpawnZone()
    {
        GameObject newZone = Instantiate(zonePrefab) as GameObject;
        newZone.transform.position = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10,10));
        numZones += 1;
    }

    public int getNumZones() { return numZones; }
}
