using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillRoad : MonoBehaviour
{
    [SerializeField] Transform lastFloor;
    [SerializeField] Transform floorInstance;
    
    private int randomValue;
    private int sizeOffset = 2;
    private Vector3 spawnFloorPos;

    public void AddFloor()
    {
        randomValue = Random.Range(0, 2);

        if (randomValue == 0)
        {
            spawnFloorPos = lastFloor.transform.position + Vector3.forward * sizeOffset;
        } 
        else
        {
            spawnFloorPos = lastFloor.transform.position + Vector3.right * sizeOffset;
        }
        
        lastFloor = Instantiate(floorInstance, spawnFloorPos, Quaternion.identity);
    }
}
