using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game9_findLetter : MonoBehaviour
{
    GameObject bed;
    GameObject window;
    GameObject drawer; 
    GameObject letter;
    GameObject text;

    public int where;
    
    void Start()
    {
        bed = GameObject.Find("침대");
        window = GameObject.Find("창문");
        drawer = GameObject.Find("서랍장");
        letter = drawer.transform.GetChild(1).gameObject;
        text = GameObject.Find("말풍선");

        GetComponent<SpriteRenderer>().enabled = true;
        transform.position = bed.transform.position;
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
                bed.transform.GetChild(0).gameObject.SetActive(true);
                transform.position = window.transform.position;
                Invoke("Invisible", 1);
                break;
            case 2:
                window.transform.GetChild(0).gameObject.SetActive(true);
                transform.position = drawer.transform.position;
                Invoke("Invisible", 1);
                break;
            case 3:
                drawer.transform.GetChild(0).gameObject.SetActive(true);
                GetComponent<SpriteRenderer>().enabled = false;
                letter.GetComponent<SpriteRenderer>().enabled = true;
                text.transform.GetChild(0).gameObject.SetActive(false);
                text.transform.GetChild(1).gameObject.SetActive(true);
                Invoke("Invisible", 1);
                break;
        }
    }


    private void Invisible()
    {
        Debug.Log("Invisible() 호출됐음 & " + where);
        switch (where)
        {
            case 1:
                bed.transform.GetChild(0).gameObject.SetActive(false);
                where++;
                break;
            case 2:
                window.transform.GetChild(0).gameObject.SetActive(false);
                where++;
                break;
            case 3:
                drawer.transform.GetChild(0).gameObject.SetActive(false);
                where++;
                break;
        }
    }
}
