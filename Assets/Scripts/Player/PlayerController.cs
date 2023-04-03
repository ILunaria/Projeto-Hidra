using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    #region PLAYER STATS
    [Header("Player Status")]
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float maxSpeed = 25;
    [SerializeField] private float sprintAddSpeed = 10;
    [SerializeField] private float jumpForce = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;
    [Range(0.5f,0.999f)][SerializeField] private float breakSmooth = 0.99f;
    #endregion
    #region PLAYER COMPONENTS
    private Rigidbody rbPlayer;
    private Vector3 playerVelocity;
    private InputActions inputs;
    private Transform cameraTransform;
    private Vector2 moveDirection;
    #endregion

    #region GROUNDED
    [Header("Player Ground")]
    [SerializeField] private bool isGrounded;
    [SerializeField] private float checkerOffset;
    [SerializeField] private float checkerRadius;
    [SerializeField] private LayerMask ground;
    #endregion

    private Animator anim;

    private void Awake()
    {
        inputs = new InputActions();
        rbPlayer = GetComponent<Rigidbody>();
        cameraTransform = Camera.main.transform;
        anim = GetComponent<Animator>();

        inputs.Enable();
        inputs.Player.Jump.performed += Jump_Input;
        inputs.Player.Sprint.performed += Sprint_Input;
        inputs.Player.Sprint.canceled += Sprint_Input;
    }

    private void Sprint_Input(InputAction.CallbackContext obj)
    {
        if(obj.performed)
        {
            maxSpeed += sprintAddSpeed;
            playerSpeed += sprintAddSpeed;
            anim.speed += 1;
        }
        if(obj.canceled)
        {
            maxSpeed-= sprintAddSpeed;
            playerSpeed-= sprintAddSpeed;
            anim.speed -= 1;
        }
    }

    private void Jump_Input(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        JumpAction();
    }

    void Update()
    {
        moveDirection = inputs.Player.Movement.ReadValue<Vector2>();
        GroundCheck();
    }

    private void FixedUpdate()
    {
        MoveAction();
    }

    private void MoveAction()
    {
        Vector3 move = new Vector3(moveDirection.x, 0, moveDirection.y);

        move = cameraTransform.forward * move.z + cameraTransform.right * move.x;
        float origMagnitude = move.magnitude;
        move.y = 0;
        move = move.normalized * origMagnitude;
        rbPlayer.AddForce(move * playerSpeed, ForceMode.Force);

        var lookDirection = cameraTransform.forward;
        lookDirection.y = 0;

        if (move != Vector3.zero)
        {
            transform.forward = Vector3.Lerp(transform.forward, lookDirection, 20 * Time.deltaTime);
            anim.SetBool("isWalking", true);
        }
        else anim.SetBool("isWalking", false);

        if (rbPlayer.velocity.sqrMagnitude > maxSpeed)
        {
            //smoothness of the slowdown is controlled by the 0.99f, 
            //0.5f is less smooth, 0.9999f is more smooth
            rbPlayer.velocity *= breakSmooth;
        }
    }

    private void GroundCheck()
    {
        Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - checkerOffset, transform.position.z);
        isGrounded = Physics.CheckSphere(spherePosition, checkerRadius, ground);
    }

    private void JumpAction()
    {
        if (isGrounded) rbPlayer.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(new Vector3(transform.position.x, transform.position.y - checkerOffset, transform.position.z), checkerRadius);
    }
}
