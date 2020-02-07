using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBrain : MonoBehaviour
{
    public float speed;
    public bool alive;

    private Vector3 direction;
    private float rayDistance = 5f;
    private GameEvent GameEvent;

    private void Awake()
    {
        alive = false;
    }

    private void Start()
    {
        direction = Vector3.right; //startMoveDir
        GameEvent = GameObject.Find("GameEvent").GetComponent<GameEvent>();
    }

    private void Update()
    {
        if (alive)
        {
            InputManager();

            MoveInDirection();
        }
    }

    private void InputManager()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeMoveDirection();
        }
    }

    private void MoveInDirection()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void ChangeMoveDirection()
    {
        direction = direction.x == 1 ? Vector3.forward : Vector3.right;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Crystal"))
        {
            GameEvent.Score(1);
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Floor"))
        {
            GameEvent.Score(1);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (!Physics.Raycast(transform.position, transform.up * -1, rayDistance))
        {
            GameEvent.GameOver();
        }

        if (collision.gameObject.CompareTag("Floor"))
        {
            FloorFall floorFall = collision.gameObject.GetComponent<FloorFall>();

            floorFall.DeleteFloor();
            floorFall.playerDroveThrough = true;
        }
    }
}
