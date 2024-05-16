using UnityEngine;

public class Alien : MonoBehaviour
{
    public Sprite[] sprites;

    SpriteRenderer rend;

    int currentSprite = 0;

    private void Awake()
    {
        rend = GetComponent<SpriteRenderer>();
        //SetRedColor();
        SetRandomColor();
    }

    void SetRedColor()
    {
        rend.color = Color.red; //Color-luokasta löytyy monta valmista väriä
    }

    void SetRandomColor()
    {
        Color randomRGBColor = new Color32( //Color32-luokka hyväksyy skaalan 0-255 byte-muodossa
            (byte)Random.Range(0, 255), //voisi asettaa muuttujaan
            (byte)Random.Range(0, 255),
            (byte)Random.Range(0, 255),
            255);
        Color randomHSVColor = Random.ColorHSV( //HSV-skaala 0-1
            0f, //min hue value
            1f, //max hue value
            1f, //min saturation value
            1f,  //max saturation value
            0.5f,  //min visibility (0=full transparency)
            1f); // max visibility
        
        rend.color = randomRGBColor;         
    }


    void Start()
    {
        //Invoke("ChangeSprite", 5f); //5 sekunnin kuluttua kutsuisi kerran ChangeSprite-metodia.   
        InvokeRepeating("ChangeSprite", 0.5f, 0.5f);
    }

    void ChangeSprite()
    {
        //tapa 1:
        //if (rend.sprite = sprites[0])
        //     rend.sprite = sprites[1];
        //else 
        //    rend.sprite = sprites[0]

        //tapa 2: (ei väliä kuinka monta indeksipaikkaa arrayssa on)
        currentSprite = (currentSprite + 1) % sprites.Length; //lähtee alusta viimeisen jälkeen
        rend.sprite = sprites[currentSprite];
    }


}
