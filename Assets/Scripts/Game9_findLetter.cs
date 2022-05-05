using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game9_findLetter : MonoBehaviour
{
    public GameObject closet; // 1
    public GameObject bed; // 2
    public GameObject drawer; // 3
    public GameObject letter; // 4
    public GameObject closetText;
    public GameObject bedText;
    public GameObject drawerText;
    public GameObject letterText;

    public int where;
    
    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        transform.position = closet.transform.position;
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
        switch (where)
        {
            case 1:
                closetText.SetActive(true);
                transform.position = bed.transform.position;
                Invoke("Invisible", 2);
                break;
            case 2:
                bedText.SetActive(true);
                transform.position = drawer.transform.position;
                Invoke("Invisible", 2);
                break;
            case 3:
                drawerText.SetActive(true);
                transform.position = letter.transform.position;
                Invoke("Invisible", 2);
                break;
            case 4:
                letterText.SetActive(true);
                Invoke("Invisible", 2);
                break;
        }
    }


    private void Invisible()
    {
        Debug.Log("Invisible() »£√‚µ∆¿Ω & " + where);
        switch (where)
        {
            case 1:
                closetText.SetActive(false);
                where++;
                break;
            case 2:
                bedText.SetActive(false);
                where++;
                break;
            case 3:
                drawerText.SetActive(false);
                where++;
                break;
            case 4:
                letterText.SetActive(false);
                where++;
                break;
        }
    }
}
