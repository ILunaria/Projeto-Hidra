using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraControll : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Transform body;
    [SerializeField] private float bodyRotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        MouseHide();
    }
    private void Update()
    {
        CheckRotation();
    }

    private void MouseHide()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void CheckRotation()
    {

    }
}
