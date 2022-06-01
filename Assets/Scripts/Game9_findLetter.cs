using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game9_findLetter : MonoBehaviour
{
    GameObject drawer;
    GameObject window;
    GameObject desk;
    GameObject letter;
    GameObject text;

    public int where;
    
    void Start()
    {
        drawer = GameObject.Find("서랍장");
        window = GameObject.Find("창문");
        desk = GameObject.Find("책상");
        letter = desk.transform.GetChild(1).gameObject;
        text = GameObject.Find("말풍선");

        GetComponent<SpriteRenderer>().enabled = true;
        transform.position = drawer.transform.position;
        where = 1;
    }

    
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            OnMouseDown();
        }
    }


    private void OnMouseDown()
    {
        //  case마다 오디오 플레이 넣어주면 됨
        switch (where)
        {
            case 1:
                drawer.transform.GetChild(0).gameObject.SetActive(true);
                transform.position = window.transform.position;
                
                where++;
                break;
            case 2:
                window.transform.GetChild(0).gameObject.SetActive(true);
                transform.position = desk.transform.position;

                where++;
                break;
            case 3:
                desk.transform.GetChild(0).gameObject.SetActive(true);
                GetComponent<SpriteRenderer>().enabled = false;
                letter.GetComponent<SpriteRenderer>().enabled = true;
                text.transform.GetChild(0).gameObject.SetActive(false);
                text.transform.GetChild(1).gameObject.SetActive(true);

                where++;
                StartCoroutine(WaitAndLoadScene());
                break;
        }
    }


    IEnumerator WaitAndLoadScene()
    {
        yield return new WaitForSeconds(1.0f);

        SceneManager.LoadScene("P4_StoryScene");
    }
}
