using UnityEngine;

public class Space : MonoBehaviour
{
    [Range(0.1f, 2.0f)]               //luo sliderin editoriin annetuilla min/max -arvoilla
    [SerializeField] float scrollSpeed; //SerializeField pit‰‰ muuttujan privatena,
                                        //mutta antaa asettaa arvon editorissa
    Renderer rend;
    float offset;
    //Rigidbody2D rb;

    private void Awake()
    {
        rend = GetComponent<Renderer>(); //haetaan referenssi vain kerran muistiin
        //rb = GetComponent<Rigidbody2D>();
        //rb.constraints = RigidbodyConstraints2D.FreezePosition;
        //rb.freezeRotation = true;
    }

    void Update() //kutsutaan joka framella
    {
        offset = Time.time * scrollSpeed; //kulunut aika * valittu nopeus
        rend.material.SetTextureOffset("_MainTex", new Vector2(0, offset));
    }
}
