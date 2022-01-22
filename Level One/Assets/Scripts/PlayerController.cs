using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] GameObject projParent;
    [SerializeField] float projSpeed = 375f;
    [SerializeField] int projNumOnScreen;
    public Transform startProjectile;
    public GameObject projectile;

    [SerializeField] float playerMovement;
    [SerializeField] float playerSpeed = 5f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] bool isGrounded;
    [SerializeField] bool isTouchingWall;

    public Camera mainCam;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
        
        if (!rb)
            rb = GetComponent<Rigidbody>();

        projParent = GameObject.FindGameObjectWithTag("Projectile Parent");
        projNumOnScreen = 0;
    }
    
    void Update()
    {
        mainCam.transform.position = new Vector3(transform.position.x + offset.x, offset.y, transform.position.z + offset.z);

        projNumOnScreen = projParent.transform.childCount;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        if (Input.GetKeyDown(KeyCode.J))
        {
            
            Debug.Log("pew");

            GameObject bullet;
            bullet = Instantiate(projectile, startProjectile.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().AddForce(transform.right * projSpeed);
            bullet.transform.SetParent(projParent.transform);
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
