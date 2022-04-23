using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementComponent : MonoBehaviour
{

    [SerializeField]
    float runSpeed = 10;
    [SerializeField]
    float jumpForce = 5;
    [SerializeField]
    float aimSensitivity = 1;
    [SerializeField, Range(0, 1)]
    float jumpControl = 0.25f;

    int airJumps = 1;
    int jumpsleft;

    //components
    private Rigidbody rigidbody;
    private Animator animator;
    public GameObject followTarget;
    private PlayerController playerController;

    //animator hash values
    public readonly int MovementXHash = Animator.StringToHash("MoveX");
    public readonly int MovementYHash = Animator.StringToHash("MoveY");
    public readonly int isJumpingHash = Animator.StringToHash("isJumping");
   
    //references
    Vector2 inputVector = Vector2.zero;
    Vector3 moveDirection = Vector3.zero;
    Vector2 LookInput = Vector2.zero;

    public LayerMask toIgnore;
    public AudioClip jump;
    public void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        playerController = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
        if(animator == null)
            animator = GetComponentInChildren<Animator>();

        toIgnore = ~toIgnore;
    }


    // Update is called once per frame
    void Update()
    {

        if(playerController.isPaused) return;

        GroundCheck();

        //player movement
        if(playerController.isJumping == false) 
           AddMovement();
        else
            AddMovement(jumpControl);

        //camera movement
        followTarget.transform.rotation *= Quaternion.AngleAxis(LookInput.x * aimSensitivity, Vector3.up);

        followTarget.transform.rotation *= Quaternion.AngleAxis(LookInput.y * aimSensitivity, Vector3.left);

        var angles = followTarget.transform.localEulerAngles;
        angles.z = 0;

        var angle = followTarget.transform.localEulerAngles.x;
        if(angle > 180 && angle < 345)
        {
            angles.x = 345;
        }
        else if(angle < 180 && angle > 30)
        {
            angles.x = 30;
        }

        followTarget.transform.localEulerAngles = angles;

        //rotate character based on camera
        transform.rotation = Quaternion.Euler(0, followTarget.transform.rotation.eulerAngles.y, 0);
        followTarget.transform.localEulerAngles = new Vector3(angles.x, 0,0);
    }

    void AddMovement(float controlPercent = 1)
    {
        if (inputVector.magnitude > 0)
            moveDirection = transform.forward * inputVector.y + transform.right * inputVector.x;
        else
            moveDirection = Vector3.zero;

        Vector3 movementDirection = moveDirection * controlPercent * (runSpeed * Time.deltaTime);
        transform.position += movementDirection;
    }

    public void OnMovement(InputValue value)
    {
        if(playerController.isPaused) return;

        inputVector = value.Get<Vector2>();
        animator.SetFloat(MovementXHash, inputVector.x);
        animator.SetFloat(MovementYHash, inputVector.y);
    }

    public void OnLook(InputValue value)
    {
        LookInput = value.Get<Vector2>();
    }


    public void OnJump(InputValue value)
    {
        if(playerController.isPaused) return;

        if(playerController.isJumping && jumpsleft > 0)
        {
            jumpsleft--;
            Jump();
        }
        
        if(playerController.isJumping == false)
        {
            Jump();
        }
    }

    public void Jump()
    {
        playerController.isJumping = true;
        Vector3 stopY = new Vector3(rigidbody.velocity.x, 0, rigidbody.velocity.z);
        rigidbody.velocity = stopY;
        
        rigidbody.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        animator.SetBool(isJumpingHash, playerController.isJumping);
        PersistantBGMPlayer.PlaySFX(jump);
        transform.parent = null;
    }

    private void GroundCheck()
    {
       var overlapping = Physics.OverlapSphere(transform.position, 0.25f, toIgnore);
        if(overlapping.Length != 0)
        {
            playerController.isJumping = false;
            animator.SetBool(isJumpingHash, playerController.isJumping);

            transform.parent = overlapping[0].transform;

            jumpsleft = airJumps;
        }
        else
        { 
             animator.SetBool(isJumpingHash, playerController.isJumping);
            playerController.isJumping = true;
            transform.parent = null;
        }
            
    }

    
}
