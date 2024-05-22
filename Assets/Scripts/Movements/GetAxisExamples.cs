using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAxisExamples : MonoBehaviour
{
    public float speed;
    Vector2 movementVector;

  
    void Update()
    {
        GetInput();
        
    }

    private void FixedUpdate() //0.02sekunnin välein oletuksena = 50x sekunnissa
    {
        
    }
    void GetInput()
    {
        float xMovement = Input.GetAxisRaw("Horizontal"); //vain 0 tai 1 tai -1
        float yMovement = Input.GetAxisRaw("Vertical"); //kiihtyy 0:sta ykköseen tai -1 seen
        movementVector = new Vector2(xMovement, yMovement);

        if(movementVector.magnitude > 1)
        {
            //Normalisoidaan, mikäli nopeus viistoon liikuttaessa menee yli 1
            movementVector.Normalize();
            movementVector = movementVector.normalized;
        }

       transform.Translate(movementVector * speed * Time.deltaTime);
       Debug.Log(movementVector);
        
    }
}

