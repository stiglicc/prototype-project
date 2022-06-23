using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public Vector3 offset;

    public float zoomSpeed = 4f;

    public float minZoom = 5f;

    public float maxZoom = 15f;

    public float pitch = 2f;

    public float cameraRotation = 100f;

    private float currentCamera = 0f;
    private float currentZoom = 10f;

    private void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

       currentCamera -= Input.GetAxis("Horizontal") * cameraRotation * Time.deltaTime;
    }
    private void LateUpdate()
    {
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);

        transform.RotateAround(target.position, Vector3.up, currentCamera);
    }
}
