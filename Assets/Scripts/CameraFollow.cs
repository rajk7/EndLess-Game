using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform lookAt;
    private Vector3 cameraOffSet;
    private Vector3 moveVector;
    private float transition = 0.0f;
    private float animationDuration = 2.0f;
    private Vector3 animationOffSet= new Vector3(0,5,5);

    // Start is called before the first frame update
    void Start()
    {
        lookAt = GameObject.FindGameObjectWithTag ("Player").transform;
        cameraOffSet = transform.position - lookAt.position;
        //Debug.Log("cam1");
    }

    // Update is called once per frame
    void Update()
    {

        moveVector = lookAt.position + cameraOffSet;
        //X camera of x vector is 0
        moveVector.x = 0;
        
        //Y Mathf.clamp(xValue, xMin, xMax);
        moveVector.y = Mathf.Clamp(moveVector.y,3,5);
        //Debug.Log("cam4");


        if(transition > 1.0f)
        {
            transform.position = moveVector;
            //Debug.Log("cam2");
        }
        else
        {
            transform.position = Vector3.Lerp(moveVector + animationOffSet,moveVector,transition);
            transition +=Time.deltaTime * 1/animationDuration;
            transform.LookAt (lookAt.position + Vector3.up);
            //Debug.Log("cam3");


        }

    }
}
