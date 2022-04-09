using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game8_heart : MonoBehaviour
{
    bool isPlay;
    float distance;

    public GameObject heartMold;
    public Vector2 moldPos;
    public Vector2 shapePos;

    AudioSource dalkac;

    void Start()
    {
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
            transform.position = moldPos;

            dalkac.Play();
            isPlay = true;
        }
    }

    void OnMouseDrag() 
    {
        if (distance <= 0.5f) return;

        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
    }
}
