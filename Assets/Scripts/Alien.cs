using UnityEngine;

public class Alien : MonoBehaviour
{
    public Sprite[] sprites;

    SpriteRenderer rend;

    int currentSprite = 0;

    private void Awake()
    {
        rend = GetComponent<SpriteRenderer>();        
    }

    void Start()
    {
        //Invoke("ChangeSprite", 5f); //5 sekunnin kuluttua kutsuisi kerran ChangeSprite-metodia.   
        InvokeRepeating("ChangeSprite", 0.5f, 0.5f);
    }

    void ChangeSprite()
    {
        //if (rend.sprite = sprites[0])
        //     rend.sprite = sprites[1];
        //else 
        //    rend.sprite = sprites[0]
        currentSprite = (currentSprite + 1) % sprites.Length; //lähtee alusta viimeisen jälkeen
        rend.sprite = sprites[currentSprite];
    }


}
