using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TopDownMovement : MonoBehaviour
{
    float moveSpeed = 10f;
    float rotationSpeed = 200f;

    float rotationZ;

    void Update()
    {                                //or = ||
        if(Input.GetKey(KeyCode.W))  //     || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(new Vector2(0f, moveSpeed) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector2(0f, -moveSpeed) * Time.deltaTime);
        }

        //TopDown-pelaajan rotaatio:
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0f, 0f, -rotationSpeed) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0f, 0f, rotationSpeed) * Time.deltaTime);
        }

        Debug.Log(transform.rotation.z); //n‰ytt‰‰ radiaaneina (koko kierros = 2 * PI)
        //mutta halutaan asteet kuten editorissakin:
        Debug.Log(transform.rotation.eulerAngles.z); //-90 jos editorissa rotation z on -90        
    }

   

}
