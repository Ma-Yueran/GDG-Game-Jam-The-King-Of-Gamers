using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// How to use?
/// 1. Create an empty GameObject as the camera holder;
/// 2. Attach this script onto the camera holder;
/// 3. Create an empty GameObject under the camera holder as the camera pivot;
/// 4. Put the Camera object under the camera pivot;
/// 5. Drag the camera pivot and the Camera object into public variables "cameraPivot", "cameraTransform";
/// 6. Drag the camera target into the public variable "target";
/// 7. Done!
/// </summary>
public class ThirdPersonCamera : MonoBehaviour
{
    public static ThirdPersonCamera instance;

    public Transform target;
    public Transform cameraPivot;
    public Transform cameraTransform;

    public float distanceToCamera = 3.5f;
    public float sensitivityX = 2;
    public float sensitivityY = 2;

    public LayerMask collisionLayerMask;

    public float smoothTime = 0.3f;

    private const float Y_MAX_ANGLE = 50;
    private const float Y_MIN_ANGLE = -50;
    private const float COLLISION_OFFSET = 0.2f;
    private const float MIN_DISTANCE = 0.3f;

    private float currentX;
    private float currentY;
    private float currentDistance;
    private Vector3 velocity = Vector3.zero;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }

    private void LateUpdate()
    {
        if (Time.timeScale == 0)
        {
            return;
        }
        UpdateCamera();
    }

    public void UpdateCamera()
    {
        currentX += Input.GetAxis("Mouse X") * sensitivityX;
        currentY -= Input.GetAxis("Mouse Y") * sensitivityY;
        currentY = Mathf.Clamp(currentY, Y_MIN_ANGLE, Y_MAX_ANGLE);
        HandleCameraRotation();
        HandleCameraCollision();
        FollowTarget();
    }

    private void FollowTarget()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, smoothTime);
    }

    private void HandleCameraRotation()
    {
        Vector3 targetPos;
        Vector3 dir = new Vector3(0, 0, -currentDistance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        targetPos = cameraPivot.position + rotation * dir;
        cameraTransform.position = Vector3.Slerp(cameraTransform.position, targetPos, 0.1f);
        cameraTransform.LookAt(cameraPivot);
    }

    private void HandleCameraCollision()
    {
        RaycastHit hit;
        Vector3 dir = cameraTransform.position - cameraPivot.position;

        if (Physics.Raycast(cameraPivot.position, dir, out hit, distanceToCamera, collisionLayerMask))
        {
            float dis = Vector3.Distance(hit.point, cameraPivot.position) - COLLISION_OFFSET;
            currentDistance = Mathf.Lerp(currentDistance, dis, 0.1f);

            if (currentDistance < MIN_DISTANCE)
            {
                currentDistance = MIN_DISTANCE;
            }
        }
        else
        {
            currentDistance = Mathf.Lerp(currentDistance, distanceToCamera, 0.1f);
        }
    }
}
