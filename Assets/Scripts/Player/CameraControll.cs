using UnityEngine;

public class CameraControll : MonoBehaviour
{
    private Transform cam;
    [SerializeField] private Transform body;
    [SerializeField] private float bodyRotationSpeed;

    // Start is called before the first frame update
    void Awake()
    {
        MouseHide();
        cam = Camera.main.transform;
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
        var lookDirection = cam.forward;
        lookDirection.y = 0;

        body.forward = lookDirection;
    }
}
