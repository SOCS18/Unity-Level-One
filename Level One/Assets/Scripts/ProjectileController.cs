using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {   
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
            Destroy(gameObject);

        if (other.gameObject.tag == "Enemy")
            Destroy(gameObject);
    }
}
