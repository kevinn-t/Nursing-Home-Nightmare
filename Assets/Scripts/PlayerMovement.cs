using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class FPSController : MonoBehaviour
{   
    #region Variables
    [Header("References")]
    public Transform orientation;
    public Camera playerCamera;

    [Header("Movement Speeds")]
    public float crouchSpeed = 3f;
    public float walkSpeed = 3f;
    public float runSpeed = 5f;
    public float jumpPower = 4.67f;
    public float gravity = 10f;
    
    [Header("Camera Control")]
    public float lookSpeed = 2f;
    public float lookXLimit = 45f;
    Vector3 camPosition = new Vector3(0, 0.9f, 0); // original cam position
    Vector3 crouchCamPosition = new Vector3(0, 0.6f, 0);

    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    CharacterController characterController;
    #endregion

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        #region Handle Movement0u
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        // Press LControl to run & Lshift to crouch
        bool isCrouched = Input.GetButton("Crouch");
        bool isRunning = Input.GetButton("Sprint");
        float curSpeedX;
        float curSpeedY;
        
        if (PlayerManager.instance.canMove)
        {
            if (isRunning)
            {
                PlayerManager.instance.isCroutching = false;
                playerCamera.transform.localPosition = camPosition;
                curSpeedX = runSpeed * Input.GetAxis("Vertical");
                curSpeedY = runSpeed * Input.GetAxis("Horizontal");
            }
            else if (isCrouched)
            {
                PlayerManager.instance.isCroutching = true;
                playerCamera.transform.localPosition = crouchCamPosition;
                curSpeedX = crouchSpeed * Input.GetAxis("Vertical");
                curSpeedY = crouchSpeed * Input.GetAxis("Horizontal");
            }
            else
            {
                PlayerManager.instance.isCroutching = false;
                playerCamera.transform.localPosition = camPosition;
                curSpeedX = walkSpeed * Input.GetAxis("Vertical");
                curSpeedY = walkSpeed * Input.GetAxis("Horizontal");
            }
        }
        else
        {
            playerCamera.transform.localPosition = camPosition;
            curSpeedX = 0;
            curSpeedY = 0;
        }
        
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);
        #endregion

        #region Handle Jumping
        if (Input.GetButton("Jump") && PlayerManager.instance.canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        #endregion

        #region Handle Camera Movement
        characterController.Move(moveDirection * Time.deltaTime);

        if (PlayerManager.instance.canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
        #endregion
    }


}
