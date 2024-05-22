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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Vaihtoehto: tagien avulla:
        //if (collision.gameObject.CompareTag("Enemy"))       //suositeltava tapa, jos käyttää tageja
        //{
        //    print("osuttiin!");
        //}

        //Älä käytä, vaikka tämäkin toimii, CompareTag kevyempi
        //if(collision.gameObject.tag =="Enemy")
        
        //tuhotaan jokainen objekti, johon bullet osuu:
        Destroy(collision.gameObject); //tuhoaa alienin
        Destroy(gameObject); //tuhoaa bulletin (itsensä)
    }
}
