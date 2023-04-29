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
    void Start()
    {
        MouseHide();
    }
    // Update is called in every frame
    private void Update()
    {
        CheckLookDirection();
        CheckRotation();
    }
    //Esconde o mouse
    private void MouseHide()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    //Checa a rotação do personagem por dot product e rotaciona ele
    private void CheckRotation()
    {

        Vector3 dirToTarget = Vector3.Normalize(mouseWorldPosition - body.position);
        float dot = Vector3.Dot(body.forward, dirToTarget);

        Vector3 worldAimTarget = mouseWorldPosition;
        worldAimTarget.y = body.position.y;
        Vector3 aimDirection = Vector3.Normalize(worldAimTarget - body.position);


        //Debug.Log(dot);

        if (dot < 0.8 && dot > 0.35)
        {
            body.forward = Vector3.Lerp(body.forward, aimDirection, 3f * Time.deltaTime);
        }
        else if (dot < 0.35)
        {
            body.forward = Vector3.Lerp(body.forward, aimDirection, 7f * Time.deltaTime);
        }
    }
    //Checa a direção que a camera está apontando.
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
        debug.transform.position = Vector3.Lerp(debug.transform.position,mouseWorldPosition,0.1f);
    }
}
