using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoundaries : MonoBehaviour
{
    [SerializeField] private Camera mainCam;
    public Vector3 widthBoundary;
    public Vector3 heightBoundary;
    
    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPosition = mainCam.WorldToScreenPoint(transform.position);
        //Debug.Log(screenPosition);
    }
}
