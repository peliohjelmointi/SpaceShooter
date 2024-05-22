using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLookAt : MonoBehaviour
{
    public Transform playerTransform;

    Vector2 lastRotation;
   
    void Update()
    {
        Vector2 direction = playerTransform.transform.position - transform.position;
        if (lastRotation != direction)
        {
            transform.rotation = Quaternion.FromToRotation(Vector3.up, direction); //k��ntyy pelaajaa kohti
        }                                             //jos turret alussa muualle kuin yl�s, muuta Vector3.right esim.
        lastRotation = direction;
    }
}
