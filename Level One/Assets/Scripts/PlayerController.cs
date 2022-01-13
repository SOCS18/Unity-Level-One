using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        if (!rb)
            rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float playerMovement = Input.GetAxis("Horizontal");

        transform.Translate(playerMovement * playerSpeed * Time.deltaTime, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space))
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
