using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class game8_heart : MonoBehaviour
{
    bool isPlay;
    float distance;

    GameObject heart1;
    GameObject heart2;
    GameObject heartMold;
    Vector2 moldPos;
    Vector2 shapePos;

    AudioSource dalkac;

    void Start()
    {
        heartMold = GameObject.FindGameObjectWithTag(this.tag);
        dalkac = GetComponent<AudioSource>();
        isPlay = false;

        heart1 = GameObject.Find("Dragheart_prince");
        heart2 = GameObject.Find("Dragheart_princess");
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
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            OnMouseDrag();
        }

        if(heart1.transform.position == GameObject.FindGameObjectWithTag(heart1.tag).transform.position
            && heart2.transform.position == GameObject.FindGameObjectWithTag(heart2.tag).transform.position)
        {
            StartCoroutine(WaitAndLoadScene());
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
