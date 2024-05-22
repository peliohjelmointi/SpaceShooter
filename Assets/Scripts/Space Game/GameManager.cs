using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject space;

    public GameObject alienCreator;

    //[HideInInspector]
    public int fleetDirection;

    public float fleetSpeed;

    List<GameObject> aliens;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        aliens = alienCreator.GetComponent<AlienCreator>().aliens;
    }

    //Ei hyv‰ paikka t‰lle funktiolle, muuta parempaan paikkaan!
    public void DropFleet()
    {
       foreach(GameObject alien in aliens) 
        {
            alien.transform.position += Vector3.down; //voi k‰ytt‰‰, koska korkeus = 1
        }
    }


}
