using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;

public class MovementController : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    public float moveSpeed = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = Vector2.zero;

        float horInput = CnInputManager.GetAxis("Horizontal");
        float vertInput = CnInputManager.GetAxis("Vertical");

        if (horInput != 0 || vertInput != 0)
        {
            movement.x = horInput * moveSpeed;
            movement.y = vertInput * moveSpeed;

            movement = Vector2.ClampMagnitude(movement, moveSpeed);
        }

        movement *= Time.deltaTime;
        _rigidBody.MovePosition(_rigidBody.position + movement);
    }
}
