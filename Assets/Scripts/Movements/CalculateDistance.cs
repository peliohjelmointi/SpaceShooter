using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateDistance : MonoBehaviour
{
    [SerializeField] GameObject enemy;

    Vector3 offset;

    float range = 3f;

    void Start()
    {
        offset = transform.position - enemy.transform.position;
    }


    void Update()
    {
        //ManualRangeCheck();
        RangeCheckUsingDistance();
    }
    void RangeCheckUsingDistance()
    {
        float distance = Vector2.Distance(transform.position, enemy.transform.position);
        print(distance);
    }

    void ManualRangeCheck()
    {
        offset = transform.position - enemy.transform.position;
        //Debug.Log(offset); // x:n ja y:n  etäisyys enemyn x:stä ja y:stä
        float distance = offset.magnitude;
        Debug.Log(distance);

        if (distance <= range) //player on 3m alueella enemystä
        {
            Debug.Log("PLAYER IN RANGE (3m)!");
        }
    }
}
