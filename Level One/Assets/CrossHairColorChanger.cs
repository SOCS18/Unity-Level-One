using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossHairColorChanger : MonoBehaviour
{
    Image crossHair;

    public EnemyDetector enemyDetector;

    // Start is called before the first frame update
    void Start()
    {
        crossHair = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyDetector.isColliding)
        {
            
            crossHair.color = new Color(0, 0, 0, 255);
        }
        else
        {
            
            crossHair.color = new Color(255, 255, 255, 255);
        }
    }
}
