using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Range(5,15)]
    [SerializeField] float moveSpeed;

    public GameObject space; //kun inspectorista raahataan Space-Gameobject, päästään käsiksi Space-gameobjektiin (esim. GetComponent<Renderer>() )
    [SerializeField] GameObject bulletPrefab;

    Transform bulletSpawnPoint;

    float spaceMaxX;
    float width;

    int bulletNr=0;

    private void Awake()
    {                
        width = GetComponent<Renderer>().bounds.size.x; //pelaajan leveys koordinaatistossa       
        bulletSpawnPoint = transform.GetChild(0); //vain 1 child, indeksipaikassa 0
    }

    private void Start()
    {
        spaceMaxX = space.GetComponent<Space>().rightX; //avaruuden oikean laidan x-koordinaatti  

        //älä käytä, ellet keksi muuta ratkaisua (koska raskas operaatio)
        //GameObject a = GameObject.Find("Alien");
        //print(a.GetComponent<SpriteRenderer>().sprite.name);
    }

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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Luodaan uusi bullet (prefabista)
            //mikä synnytetään /mihin positioon /rotaatio (oletuksena Quaternion.identity)
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
            
            //annetaan nimi, jotta siihen tarvittaessa saadaan pääsy nimellä
            bullet.name = $"Bullet numero {bulletNr}"; //uusi tapa
            // tai sama:
            //bullet.name = "Bullet " + bulletNr.ToString(); //vanha tapa            
            bulletNr += 1; // sama kuin bulletNr++; tai bulletNr = bulletNr + 1;
        }
        //rajoitetaan pelaajan liikkuminen x-koordinaatein avaruuden reunojen mukaan
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -spaceMaxX+width/2, spaceMaxX-width/2),transform.position.y);
    }
    



}













// print(GetComponent<Renderer>().bounds.size.x);