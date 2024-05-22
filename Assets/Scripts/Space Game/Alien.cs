using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class Alien : MonoBehaviour
{
    public Sprite[] sprites;

    public GameObject space;

    SpriteRenderer rend;

    int currentSprite=0;

    float spaceMaxX;

    bool isCoroutineRunning; //oletusarvona false

    private void Awake()
    {
        rend = GetComponent<SpriteRenderer>();                
        //SetRedColor();
        SetRandomColor();
    }

    void SetRedColor()
    {
        rend.color = Color.red; //Color-luokasta l�ytyy monta valmista v�ri�
    }

    void SetRandomColor()
    {
        Color randomRGBColor = new Color32( //Color32-luokka hyv�ksyy skaalan 0-255 byte-muodossa
            (byte)Random.Range(0, 255), //Red-arvo,(voisi asettaa muuttujaan)
            (byte)Random.Range(0, 255), //Green-arvo
            (byte)Random.Range(0, 255), //Blue-arvo
            255); //alpha-kanava (l�pin�kyvyys (0=l�pin�kyv�, 1=n�kyy) )
        Color randomHSVColor = Random.ColorHSV( //HSV-skaala 0-1
            0f, //min hue value
            1f, //max hue value
            1f, //min saturation value
            1f,  //max saturation value
            0.5f,  //min visibility (0=full transparency)
            1f); // max visibility
        
        rend.color = randomRGBColor;         
    }

    void ChangeSprite()
    {
        //tapa 1:
        //if (rend.sprite = sprites[0])
        //     rend.sprite = sprites[1];
        //else 
        //    rend.sprite = sprites[0]

        //tapa 2: (ei v�li� kuinka monta indeksipaikkaa arrayssa on)
        currentSprite = (currentSprite + 1) % sprites.Length; //l�htee alusta viimeisen j�lkeen
        rend.sprite = sprites[currentSprite];
    }
    void Start()
    {
        //Invoke("ChangeSprite", 5f); //5 sekunnin kuluttua kutsuisi kerran ChangeSprite-metodia.   
        InvokeRepeating("ChangeSprite", 0.5f, 0.5f);
        //Haetaan space-gameobjektin Space-skripist� rightX-arvo
        spaceMaxX = GameManager.Instance.space.GetComponent<Space>().rightX;
    }

    private void Update()
    {
        transform.Translate(new Vector2(
            GameManager.Instance.fleetDirection, 0) *
            GameManager.Instance.fleetSpeed *
            Time.deltaTime);
                
        // Tee if-lauseella tarkistukset, ylitt��k�/matchaako alienin maksimi x-arvo
        // spacen oikeaan reunaan (rightX-arvoon) TAI alittaako/matchaako alienin 
        // minimi x-arvo rightX:n k��nteisseen arvoon (-rightX) 
        
        // Mik�li if toteutuu (alus osuu reunaan)
        // Muuta GameManagerin fleetDirection -muuttujan arvo vastakkaiseksi luvuksi
        // (kerro se -1:ll�)

        if(rend.bounds.max.x >= spaceMaxX || //oikeaan reunaan osutaan
            rend.bounds.min.x <= -spaceMaxX) //vasempaan reunaan osutaan
        {
            if (isCoroutineRunning == false)
            {
                StartCoroutine(ChangeDirection());
            }            
        }              
       
    }
    IEnumerator ChangeDirection()
    {
        isCoroutineRunning = true;
        GameManager.Instance.fleetDirection *= -1;
        GameManager.Instance.DropFleet(); //Siirr� DropFleet vaikka t�h�n tiedostoon
        yield return new WaitForSeconds(1);
        isCoroutineRunning = false;
    }

}
