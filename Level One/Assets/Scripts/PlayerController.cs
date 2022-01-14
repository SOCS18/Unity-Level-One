using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float playerMovement;
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private bool isGrounded;
    [SerializeField] private bool isTouchingWall;
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        if (!rb)
            rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("pew");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerMovement = Input.GetAxis("Horizontal");
        
        if (playerMovement > 0 && playerMovement < 1)
            playerMovement = 1;
        if (playerMovement < 0 && playerMovement > -1)
            playerMovement = -1;

        if (playerMovement < 0)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, 180, transform.rotation.z);
            transform.Translate(-playerMovement * Time.deltaTime * playerSpeed, 0, 0);
        }
        if (playerMovement > 0)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);
            transform.Translate(playerMovement * Time.deltaTime * playerSpeed, 0, 0);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = true;
        if (collision.gameObject.tag == "Wall")
            isTouchingWall = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = false;
        if (collision.gameObject.tag == "Wall")
            isTouchingWall = false;
    }
}
