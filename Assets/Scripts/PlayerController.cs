using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

// ****************** Player 3D Movement ****************** 

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    public float DeathDistance;

    private Vector3 StartPos;
    private bool endGame = false;
    private CharacterController controller;
    private float horizontalInput;
    private float verticalInput;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        StartPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < DeathDistance)
        {
            transform.position = StartPos;
        }
        if (!endGame)
        {
            GetInputs();
            MovePlayer();
        }
        
    }

    void GetInputs()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");  
    }

    void MovePlayer()
    {
        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * playerSpeed;
        movementDirection.Normalize();

        transform.Translate(movementDirection * magnitude * Time.deltaTime, Space.World);
    }

    public void EndGame()
    {
        endGame = true;
    }

}
