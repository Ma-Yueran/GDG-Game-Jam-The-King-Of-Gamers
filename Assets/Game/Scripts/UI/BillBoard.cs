using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    private Transform cameraTransform;

    private void Start()
    {
        cameraTransform = ThirdPersonCamera.instance.cameraTransform;
    }

    private void Update()
    {
        transform.LookAt(cameraTransform);
    }
}
