using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Range(1,20)]
    [SerializeField] float moveSpeed;

    void Update()
    {
    if (Input.GetKey(KeyCode.A)) //jatkuva "luku"
        {
            //Debug.Log("A");
            transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);
        }
    
    if (Input.GetKey(KeyCode.D)) //vain painettu frame luetaan
        {
            //Debug.Log("D");
            transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
        }
        //rajoitetaan pelaajan liikkuminen x-koordinaatein välille -2 ja 2
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -2, 2),transform.position.y);
    }
    



}
