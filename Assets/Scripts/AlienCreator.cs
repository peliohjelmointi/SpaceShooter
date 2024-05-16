using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienCreator : MonoBehaviour
{
    [SerializeField] GameObject alienPrefab;
    [SerializeField] GameObject space;
    float spaceWidth;
    float alienWidth;
    int alienMaxCount;
    Vector3 firstAlienPosition;

    private void Awake()
    {        
        //Montako alienia mahtuu, niin että oikeaan ja vasempaan reunaan jää alienin leveyden verran tilaa?
        spaceWidth = space.GetComponent<Renderer>().bounds.size.x;
        alienWidth = alienPrefab.GetComponent<Renderer>().bounds.size.x;
        //print(spaceWidth / alienWidth); 
        alienMaxCount = Mathf.FloorToInt(spaceWidth / alienWidth) -(int)(2*alienWidth); //pyöristys alaspäin kokonaislukuun
        //print(alienMaxCount);
        firstAlienPosition = alienPrefab.transform.position;

    }

    void Start()
    {
        CreateAlienFleet();       
    }

    void CreateAlienFleet()
    {
        //Instantiate(alienPrefab); //luo parametrina saadun objektin transformin positioon
        //Instantiate(alienPrefab, gameObject.transform); //luo objektin määritetyn objektin childiksi
        for (int i = 0; i < alienMaxCount; i++)
        {
            GameObject go = Instantiate(
                alienPrefab, 
                new Vector3(firstAlienPosition.x + i * alienWidth, firstAlienPosition.y, 0),
                Quaternion.identity,
                gameObject.transform);

            go.name = "Alien nr." + i.ToString();
            //go.SetActive(false);
            //go.GetComponent<SpriteRenderer>().sprite = ...
        }
    }



}
