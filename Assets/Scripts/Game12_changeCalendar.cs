using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game12_changeCalendar : MonoBehaviour
{
    public GameObject today;
    public GameObject tomorrow;

    public GameObject next;


    void Start()
    {
        this.gameObject.SetActive(true);
    }


    private void OnMouseDown()
    {
        today.GetComponent<SpriteRenderer>().enabled = false;
        tomorrow.GetComponent<SpriteRenderer>().enabled = true;

        if(this.tag != "Final")
        {
            next.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
