using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game5_PutInPot : MonoBehaviour
{
    public GameObject wand;
    public GameObject pot;
    public GameObject check;

    public Vector2 sourcePos;
    public Vector2 potPos;

    float distance;

    public GameObject next;


    void Start()
    {
        potPos = pot.transform.position;
        wand.GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<CircleCollider2D>().enabled = true;
    }

  
    void Update()
    {
        sourcePos = transform.position;
        distance = Vector2.Distance(potPos, sourcePos);

        if (distance <= 0.5f)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
            // 이펙트 넣으면 좋을듯

            check.GetComponent<SpriteRenderer>().enabled = true;
            Debug.Log("check 활성화");

            wand.SetActive(false);
            if(this.tag != "Finish")
            {
                next.GetComponent<Game5_PutInPot>().enabled = true;
                GetComponent<Game5_PutInPot>().enabled = false;
            }
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
