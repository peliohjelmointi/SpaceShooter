using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed;

    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * bulletSpeed);

        //Luo tarkistus; kun bulletin y-position >= kuin spacen GAME-näkymän yläreuna,niin tuhotaan bullet:
        if (transform.position.y >= 6)
            Destroy(gameObject);
    }
}
