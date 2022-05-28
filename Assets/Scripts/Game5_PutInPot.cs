using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game5_PutInPot : MonoBehaviour
{
    GameObject pot;
    public GameObject pass;
    public GameObject next;
    public string nextScene;

    Vector2 sourcePos;
    Vector2 potPos;

    public float distance;


    void Start()
    {
        pot = GameObject.Find("가마솥").transform.gameObject;

        GetComponent<CircleCollider2D>().enabled = true;

        potPos = pot.transform.position;
    }

  
    void Update()
    {
        sourcePos = transform.position;
        distance = Vector2.Distance(potPos, sourcePos);

        if (distance <= 2f)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
            pass.SetActive(true);

            if (next)
            {
                next.GetComponent<Game5_PutInPot>().enabled = true;
                GetComponent<Game5_PutInPot>().enabled = false;
            }
            else
            {
                SceneManager.LoadScene(nextScene);
            }
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            OnMouseDrag();
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
