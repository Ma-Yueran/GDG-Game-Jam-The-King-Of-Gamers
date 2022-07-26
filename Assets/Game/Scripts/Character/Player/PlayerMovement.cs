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

    private new Rigidbody rigidbody;
    private Animator animator;
    private ThirdPersonCamera thirdPersonCamera;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        thirdPersonCamera = ThirdPersonCamera.instance;
    }

    private void FixedUpdate()
    {
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");

        if (rigidbody.velocity.sqrMagnitude > 0.1f)
        {
            animator.SetBool("Walking", true);
        }
        else
        {
            animator.SetBool("Walking", false);
        }

        if (inputH != 0 || inputV != 0)
        {
            rigidbody.velocity = transform.forward * movementSpeed;

            Vector3 targetDirection = GetTargetDirection();
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.1f);
        }
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
