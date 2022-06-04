using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class game8_heart : MonoBehaviour
{
    bool isPlay;
    float distance;

    GameObject dragHeart;
    GameObject heartMold;

    Vector2 moldPos;
    Vector2 shapePos;

    AudioSource dalkac;

    void Start()
    {
        dragHeart = GameObject.Find("dragHeart");
        heartMold = GameObject.Find("heart");

        dalkac = GetComponent<AudioSource>();
        isPlay = false;
    }

    void Update()
    {
        moldPos = heartMold.transform.position;
        shapePos = transform.position;

        distance = Vector2.Distance(shapePos, moldPos);

        if (isPlay==false && distance<=0.5f)
        {
            transform.position = moldPos;;

            dalkac.Play();
            isPlay = true;

            StartCoroutine(WaitAndLoadScene());
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            OnMouseDrag();
        }
    }

    void OnMouseDrag() 
    {
        if (distance <= 0.5f)   return;
        

        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
    }

    IEnumerator WaitAndLoadScene()
    {
        yield return new WaitForSeconds(1.0f);

        SceneManager.LoadScene("P3_StoryScene");
    }
}
