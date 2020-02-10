using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector3 moveVector;
    private CharacterController controller;
    private float speed = 5.0f;
    private float verticalVelocity = 0.0f;
    private float animationDuration = 2.0f;
   
    private bool isDead = false;
    private float startTime;

    


    // Start is called before the first frame update
    void Start()
    {
        //moveVector.y = 2f;
        controller = GetComponent<CharacterController>();
        startTime = Time.time;
        //Debug.Log("1");

    }

    // Update is called once per frame
    void Update()
    {
        moveVector.y = 2f;
        if (isDead)
            return;

        Debug.Log("2");
        
        if(Time.time - startTime < animationDuration)
        {
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }
        moveVector = Vector3.zero;
        //X
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
        if(Input.mousePosition.x >Screen.width / 2)
            moveVector.x = 3;
        else
            moveVector.x = -3;
        //Y
        moveVector.y = verticalVelocity;
        //Z
        moveVector.z = speed;

        controller.Move(moveVector * Time.deltaTime);
        Debug.Log("3");
        
    }
    public void setSpeed(float modifer)
    {
        speed = 5.0f * modifer;
    }
    
    private void OnControllerColliderHit(ControllerColliderHit hit) {
        if(hit.point.z > transform.position.z + 0.1f && hit.gameObject.tag == "Enemy")
        Death();
        Debug.Log("dead");
    }
    
    private void Death()
    {
        isDead = true;
        GetComponent<ScoreCount> ().onDeath();
        Debug.Log("4");
    }
    
}
