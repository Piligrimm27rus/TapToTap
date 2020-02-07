using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorFall : MonoBehaviour
{
    private FillRoad fillRoad;

    private float speed = 1f;
    public bool playerDroveThrough = false;


    private void Start()
    {
        fillRoad = GameObject.Find("RoadStack").GetComponent<FillRoad>();
    }

    private void Update()
    {
        if (playerDroveThrough)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position - (Vector3.up * 2), Time.deltaTime * speed);
        }
    }

    public void DeleteFloor()
    {
        fillRoad.AddFloor();
        Destroy(gameObject, 2f);
    }
}
