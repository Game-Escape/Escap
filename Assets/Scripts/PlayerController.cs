using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// ��Ҫ�õ�HealthBar�ű��е�ĳ�����ԣ�������Ϊ�ýű������ԡ����ڱ�֤���ݵİ�ȫ�ԣ�������������Ϊֻ����
    /// </summary>
    private HealthBar healthBarAttr;
    public HealthBar HealthBarAttr { get => healthBarAttr; }

    private CharacterController pCharacterController;
    private Vector3 dir;

    public float walkSpeed;
    public float sprintSpeed;
    public float jumpSpeed; 

    private float horizontalMove, verticalMove;

    public float gravity;

    private Vector3 velocity;

    public Transform groundCheck;
    public float checkRadius;
    public LayerMask groundLayer;
    public bool isGrounded = false;

    public Animator anim;

    public float currentSpeed;
    public Slider stamina;

    public GameObject stamina_Panel;
    // Start is called before the first frame update
    void Start()
    {
        pCharacterController= GetComponent<CharacterController>();
        healthBarAttr = stamina_Panel.GetComponent<HealthBar>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, checkRadius, groundLayer);
        if (isGrounded && velocity.y < 0)
            velocity.y = 0.0f;

        if (Input.GetButtonDown("Jump") && isGrounded)
            velocity.y = jumpSpeed;

        horizontalMove = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed * Input.GetAxis("Horizontal") : walkSpeed * Input.GetAxis("Horizontal");
        verticalMove = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed * Input.GetAxis("Vertical") : walkSpeed * Input.GetAxis("Vertical");

        dir = transform.forward * verticalMove +transform.right * horizontalMove;
        pCharacterController.Move(dir * Time.deltaTime);

        velocity.y -= gravity * Time.deltaTime;
        pCharacterController.Move(velocity * Time.deltaTime);
    
        dir.Normalize();

        //currentSpeed = Input.GetKey(KeyCode.LeftShift)? sprintSpeed * dir.magnitude : walkSpeed * dir.magnitude;

        if(Input.GetKey(KeyCode.LeftShift) && HealthBarAttr.canSprint)
        {
            currentSpeed = sprintSpeed * dir.magnitude;
        }
        else
        {
            currentSpeed = walkSpeed* dir.magnitude;
        }

        //Debug.Log("��ǰ�ٶ�: "+ currentSpeed);
        
        if(anim != null)
        {
            anim.SetFloat("Speed", currentSpeed);
        }
    }
}
