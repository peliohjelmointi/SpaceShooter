using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed;

    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * bulletSpeed);

        //Luo tarkistus; kun bulletin y-position >= kuin spacen GAME-n�kym�n yl�reuna,niin tuhotaan bullet:
        if (transform.position.y >= 6)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Vaihtoehto: tagien avulla:
        //if (collision.gameObject.CompareTag("Enemy"))       //suositeltava tapa, jos k�ytt�� tageja
        //{
        //    print("osuttiin!");
        //}

        //�l� k�yt�, vaikka t�m�kin toimii, CompareTag kevyempi
        //if(collision.gameObject.tag =="Enemy")
        
        //tuhotaan jokainen objekti, johon bullet osuu:
        Destroy(collision.gameObject); //tuhoaa alienin
        Destroy(gameObject); //tuhoaa bulletin (itsens�)
    }
}
