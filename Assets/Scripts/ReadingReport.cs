using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReadingReport : MonoBehaviour
{
    SpriteRenderer spriteR;
    Sprite[] sprites;
    int num = 0;

    void Start()
    {
        spriteR = this.GetComponent<SpriteRenderer>();
        sprites = Resources.LoadAll<Sprite>("Reports");
        spriteR.sprite = sprites[num++];
    }

    private void OnMouseDown()
    {
        Debug.Log(num);
        if (num < sprites.Length)
        {
            spriteR.sprite = sprites[num++];
        }
        else
        {

            /*WritingReport_RayCast ray = new WritingReport_RayCast();
            string path = ray.getPath();
            Debug.Log(path);
            byte[] imgBytes = System.IO.File.ReadAllBytes(path);
            Texture2D texture = new Texture2D(0, 0);
            texture.LoadImage(imgBytes);*/
        }
        
    }

    
}
