using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform player;
    private Vector3 offset;

    private void Start()
    {
        offset = new Vector3(-5f, 4.5f, -5f);
    }

    private void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
