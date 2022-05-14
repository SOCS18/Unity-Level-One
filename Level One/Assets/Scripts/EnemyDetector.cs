using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDetector : MonoBehaviour
{
    

    [SerializeField] private GameObject enemyWarningText;
    [SerializeField] private GameObject wallWarningText;

    [SerializeField] public bool isColliding = false;

    // Start is called before the first frame update
    void Start()
    {
        enemyWarningText.SetActive(false);
        wallWarningText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemyWarningText.SetActive(true);
            isColliding = true;
            // crossHair.color = new Color(0, 0, 0, 255);
        }

        if (other.gameObject.tag == "Wall")
        {
            wallWarningText.SetActive(true);
            isColliding = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemyWarningText.SetActive(false);
            isColliding = false;
        }

        if (other.gameObject.tag == "Wall")
        {
            wallWarningText.SetActive(false);
            isColliding = false;
        }
    }
}
