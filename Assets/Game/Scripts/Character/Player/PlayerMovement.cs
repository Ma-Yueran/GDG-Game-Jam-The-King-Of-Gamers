using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public float rotationSpeed;

    private float inputH;
    private float inputV;

    private Animator animator;
    private ThirdPersonCamera thirdPersonCamera;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        thirdPersonCamera = ThirdPersonCamera.instance;
    }

    private void Update()
    {
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");

        if (inputH != 0 || inputV != 0)
        {
            animator.SetBool("Walking", true);
        }
        else
        {
            animator.SetBool("Walking", false);
            return;
        }

        transform.position += transform.forward * movementSpeed * Time.deltaTime;

        Vector3 targetDirection = GetTargetDirection();
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.1f);
    }

    private Vector3 GetTargetDirection()
    {
        Vector3 targetDirection = thirdPersonCamera.cameraTransform.forward * inputV;
        targetDirection += thirdPersonCamera.cameraTransform.right * inputH;
        targetDirection.y = 0;
        targetDirection.Normalize();

        return targetDirection;
    }
}
