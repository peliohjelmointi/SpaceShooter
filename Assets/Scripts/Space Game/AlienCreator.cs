using System.Collections.Generic; //jotta List toimii
using UnityEngine;

public class AlienCreator : MonoBehaviour
{
    [SerializeField] GameObject alienPrefab;
    [SerializeField] GameObject space;
    float spaceWidth;
    float alienWidth;
    int alienMaxCount;
    Vector3 firstAlienPosition;

    //(Jos listaa ei l�ydy, klikkaa Alt+Enter)
    //public, jotta p��st��n listaan k�siksi GameManagerista
    public List<GameObject> aliens = new List<GameObject>(); //luodaan tyhj� lista(johon voi lis�t� gameobjekteja)

    private void Awake()
    {
        //Montako alienia mahtuu, niin ett� oikeaan ja vasempaan reunaan j�� alienin leveyden verran tilaa?
        spaceWidth = space.GetComponent<Renderer>().bounds.size.x;
        alienWidth = alienPrefab.GetComponent<Renderer>().bounds.size.x;    
        alienMaxCount = Mathf.FloorToInt(spaceWidth / alienWidth) - (int)(2 * alienWidth); //py�ristys alasp�in kokonaislukuun     
        firstAlienPosition = alienPrefab.transform.position;
    }

    void Start()
    {
        CreateAlienFleet();
    }

    void CreateAlienFleet()
    {
        //Instantiate(alienPrefab); //luo parametrina saadun objektin transformin positioon
        //Instantiate(alienPrefab, gameObject.transform); //luo objektin m��ritetyn objektin childiksi
        for (int i = 0; i < alienMaxCount; i++)
        {
            for (int j = 0; j < alienMaxCount; j++)
            {
                GameObject go = Instantiate(alienPrefab, new Vector3
                    (firstAlienPosition.x + i * alienWidth,
                    firstAlienPosition.y - (alienWidth * j), 0),
                    Quaternion.identity,
                    gameObject.transform);
                go.name = $"Alien at {i}, {j}";
                aliens.Add(go);
            }

            //Oliverin ratkaisu:
            //for (int j = 0; j < alienMaxCount; j++) // i ja j muutettu rows & columns, jotka m��ritet��n inspectorissa
            //{
            //    GameObject go = Instantiate(alienPrefab, new Vector3(
            //        firstAlienPosition.x + j*alienWidth,
            //        firstAlienPosition.y,
            //        0),
            //        Quaternion.identity,
            //        gameObject.transform);
            //}
            //firstAlienPosition.y--;

        }
    }



}
