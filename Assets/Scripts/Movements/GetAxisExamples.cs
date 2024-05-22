using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAxisExamples : MonoBehaviour
{
    public float speed;
    
    void Start()
    {
        
    }
  
    void Update()
    {
        GetInput();
        
    }
    void GetInput()
    {
        float xMovement = Input.GetAxisRaw("Horizontal"); //vain 0 tai 1 tai -1
        float yMovement = Input.GetAxis("Vertical"); //kiihtyy 0:sta ykköseen tai -1 seen
        transform.Translate(new Vector2(xMovement, yMovement) * speed * Time.deltaTime);
        Debug.Log(xMovement);

        if (Input.GetKeyDown(KeyCode.X)) //GetKey koko ajan, GetKeyDown painohetkellä vain kerran
        {
            Debug.Log("X painettiin");
        }
    }
}

