using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private float sensitivity;
    [SerializeField] private Transform playerTransform;

    [SerializeField] private float verticalRotMin = 0, verticalRotMax = 75;

    [SerializeField] private float cameraZoom = 20;
    [SerializeField] private LayerMask avoidLayer;

    private float idealCameraZoom;
    private float currentCameraZoom;

    private Transform cameraTransform, boomTransform;
    private float currentHorizontalRotation, currentVerticalRotation;

    void Start()
    {
        boomTransform = transform.GetChild(0);
        cameraTransform = boomTransform.GetChild(0);

        currentHorizontalRotation = transform.localEulerAngles.y;
        currentVerticalRotation = transform.localEulerAngles.x;
    }

    void Update()
    {
        if (GameManager.gameOver) return;

        currentHorizontalRotation += Input.GetAxis("Mouse X") * sensitivity;
        currentVerticalRotation -= Input.GetAxis("Mouse Y") * sensitivity;

        currentVerticalRotation = Mathf.Clamp(currentVerticalRotation, verticalRotMin, verticalRotMax);

        transform.localEulerAngles = new Vector3(0, currentHorizontalRotation);
        boomTransform.localEulerAngles = new Vector3(currentVerticalRotation, 0);

        transform.position = playerTransform.position;

        // direction from a to b = b - a
        Vector3 directionToCamera = cameraTransform.position - playerTransform.position;
        directionToCamera.Normalize();

        if (Physics.Raycast(transform.position, directionToCamera, out RaycastHit hit, cameraZoom, avoidLayer))
        {
            currentCameraZoom = hit.distance;
        }
        else
        {
            currentCameraZoom = cameraZoom;
        }

        cameraTransform.localPosition = new Vector3(0, 0, -currentCameraZoom);
    }
}