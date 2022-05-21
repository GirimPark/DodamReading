using System.Collections;
using UnityEngine;

public class Game12_changeCalendar : MonoBehaviour
{
    public GameObject today;
    public GameObject today_;
    public GameObject tomorrow;

    public GameObject next;

    AudioSource boook;


    void Start()
    {
        this.gameObject.SetActive(true);
        boook = GetComponent<AudioSource>();
    }


    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            OnMouseDown();
        }
    }


    private void OnMouseDown()
    {
        today.GetComponent<SpriteRenderer>().enabled = false;
        boook.Play();
        today_.GetComponent<SpriteRenderer>().enabled = true;
        StartCoroutine(TearCanlendar());  
    }

    IEnumerator TearCanlendar()
    {
        yield return new WaitForSeconds(1.0f);
        Debug.Log("2초 기다리기");
        today_.GetComponent<SpriteRenderer>().enabled = false;
        tomorrow.GetComponent<SpriteRenderer>().enabled = true;
        Debug.Log("내일 활성화");

        if (this.tag != "Finish")
        {
            next.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
