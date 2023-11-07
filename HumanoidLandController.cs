using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanoidLandController : MonoBehaviour
{

    [SerializeField] private float _speed = 5; // Set the speed for the user


    void Update()
    {
    
        var dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); // Collect input for horizontal (left/right) and vertical (foward/backward) movement
        transform.Translate(dir * _speed * Time.deltaTime); // Move the user in the specified direction, scaled by the speed and the frame rate (makes the game frame-independent)
    }
}
