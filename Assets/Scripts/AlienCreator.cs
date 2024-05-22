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

    //(Jos listaa ei löydy, klikkaa Alt+Enter)
    //public, jotta päästään listaan käsiksi GameManagerista
    public List<GameObject> aliens = new List<GameObject>(); //luodaan tyhjä lista(johon voi lisätä gameobjekteja)

    private void Awake()
    {
        //Montako alienia mahtuu, niin että oikeaan ja vasempaan reunaan jää alienin leveyden verran tilaa?
        spaceWidth = space.GetComponent<Renderer>().bounds.size.x;
        alienWidth = alienPrefab.GetComponent<Renderer>().bounds.size.x;    
        alienMaxCount = Mathf.FloorToInt(spaceWidth / alienWidth) - (int)(2 * alienWidth); //pyöristys alaspäin kokonaislukuun     
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
            //for (int j = 0; j < alienMaxCount; j++) // i ja j muutettu rows & columns, jotka määritetään inspectorissa
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
