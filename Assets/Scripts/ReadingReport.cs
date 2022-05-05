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

        //  ������ �����Ѵٸ�
        if(sprites.Length > 0)
            spriteR.sprite = sprites[num++];
        //  ���� �̹��� ������ ���ٸ�
        else
        {
            string path = PlayerPrefs.GetString("path");
            Debug.Log(path);

            byte[] imgBytes = System.IO.File.ReadAllBytes(path);
            if (imgBytes.Length > 0)
            {
                Debug.Log("imgBytes ����");
                Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
                texture.LoadImage(imgBytes);
                Rect rect = new Rect(0, 0, texture.width, texture.height);
                GetComponent<SpriteRenderer>().sprite = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));
            }
        }
    }


    private void Update()
    {
        if(Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            OnMouseDown();
        }
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
            string path = PlayerPrefs.GetString("path");
            Debug.Log(path);
     
            byte[] imgBytes = System.IO.File.ReadAllBytes(path);
            if (imgBytes.Length > 0)
            {
                Debug.Log("imgBytes ����");
                Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
                texture.LoadImage(imgBytes);
                Rect rect = new Rect(0, 0, texture.width, texture.height);
                GetComponent<SpriteRenderer>().sprite = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));
            }
            
        }
        
    }

    
}
