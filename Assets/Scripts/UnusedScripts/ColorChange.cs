using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour { 

    public Color[] ColorArray;
    public string[] StringArray;
    SpriteRenderer rendColor;
    private int hitCount = 0;
    public string startColor;


    // Start is called before the first frame update
    void Start()
    {
        rendColor = GetComponent<SpriteRenderer>();
        rendColor.enabled = true;
        rendColor.color= ColorArray[0];

    }

    private void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "BlockChange")
        {
            hitCount += 1;
            rendColor.color = ColorArray[hitCount % ColorArray.Length];
            gameObject.layer = LayerMask.NameToLayer(StringArray[hitCount % StringArray.Length]);
           
        }
    

    }
}
