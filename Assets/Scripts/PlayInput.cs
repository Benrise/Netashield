using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayInput : MonoBehaviour
{
    private PlayerMovement _playerMovement;

    public Joystick joystick;


    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        float verticalMove = joystick.Vertical;
        float horizontalDirection = joystick.Horizontal;
        bool isJumpButtonPressed = verticalMove > 0.6f;
        _playerMovement.Move(horizontalDirection, isJumpButtonPressed);
    }
} 
