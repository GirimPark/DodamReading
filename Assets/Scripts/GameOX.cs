using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOX : MonoBehaviour
{
    Vector2 carPos, lovePos, newCarPos, newlovePos;
    bool isDrag, carPosTF, lovePosTF;
    // Start is called before the first frame update
    void Start()
    {
        isDrag = false;
        carPosTF = false;
        lovePosTF = false;
        carPos =  transform.position;//자동차 시작위치
        lovePos = transform.position;//사랑 시작위치
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.CompareTag("negative") ){//부정단어
            newCarPos = transform.position;
            if(isDrag==true&&transform.position.x>-3.5&&transform.position.x<-1.5&&transform.position.y>-0.5&&transform.position.y<2.0)
            {
                transform.position = new Vector2(-3,1);
                carPosTF = true;
            }
            //Debug.Log(transform.position);
        }
        else if(gameObject.CompareTag("positive")){//긍정단어
            newlovePos = transform.position;
            if(isDrag==true&&transform.position.x>1.8&&transform.position.x<4.5&&transform.position.y>-0.5&&transform.position.y<2.0)
            {
                transform.position = new Vector2(3,1);
                lovePosTF = true;
            }
        }
    }

    void OnMouseDrag() 
    {
        if (carPosTF==true || lovePosTF==true) return;

        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;

        isDrag = true; 
    }
}
