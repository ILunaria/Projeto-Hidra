using UnityEngine;
using Debug = UnityEngine.Debug;

public class CameraControll : MonoBehaviour
{
    [SerializeField] private Transform body;
    [SerializeField] private float bodyRotationSpeed;
    [SerializeField] private LayerMask aimColliderMask;

    public GameObject debug;
    private Vector3 mouseWorldPosition;
    public Vector3 MouseWorldPostion => mouseWorldPosition;

    // Start is called before the first frame update
    void Awake()
    {
        MouseHide();
    }
    private void Update()
    {
        CheckLookDirection();
        CheckRotation();
    }

    private void MouseHide()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void CheckRotation()
    {

        Vector3 dirToTarget = Vector3.Normalize(mouseWorldPosition - body.position);

        float dot = Vector3.Dot(body.forward, dirToTarget);

        //Debug.Log(dot);

        if (dot < 0.8 && dot > 0.35)
        {
            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = body.position.y;
            Vector3 aimDirection = Vector3.Normalize(worldAimTarget - body.position);
            body.forward = Vector3.Lerp(body.forward, aimDirection, 2f * Time.deltaTime);
        }
        else if (dot < 0.35)
        {
            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = body.position.y;
            Vector3 aimDirection = Vector3.Normalize(worldAimTarget - body.position);
            body.forward = Vector3.Lerp(body.forward, aimDirection, 4f * Time.deltaTime);
        }
    }
    private void CheckLookDirection()
    {
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 100f, aimColliderMask))
        {
            mouseWorldPosition = raycastHit.point;
        }
        else
        {
            mouseWorldPosition = ray.GetPoint(100);
        }
        debug.transform.position = mouseWorldPosition;
    }
}
