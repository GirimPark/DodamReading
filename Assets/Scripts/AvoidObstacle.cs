using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AvoidObstacle : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    public Vector3 LoadedPos;
    float startPosx;
    float startPosY;
    bool isBeingHeld = false;
    public bool isInLine;
    float timelinePosY;

    private void Start() 
    {
        LoadedPos = this.transform.position; 
    }
    private void Update() 
    {
        if(isBeingHeld)
        {
            Vector2 mousePos;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            this.gameObject.transform.position = new Vector2(mousePos.x - startPosx, mousePos.y - startPosY);
        }
    }


    #region 마우스 드래그앤 드롭



    private void OnMouseDown() 
    {
        if(Input.GetMouseButtonDown(0))
        {

            spriteRenderer.color = new Color(1f, 1f, 1f, .5f);
            Vector3 mousePos;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);


            startPosx = mousePos.x - this.transform.position.x;
            startPosY = mousePos.y - this.transform.position.y;


            isBeingHeld = true;

        }
    }

    private void OnMouseUp() 
    {
        spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
        isBeingHeld = false;

        if(isInLine)
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.localPosition.x, timelinePosY, -1f);
        else 
            this.gameObject.transform.position = LoadedPos;
    }



    #endregion
    
    
    #region 타임라인이랑 맞는지
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("TimeLine"))
        {
            isInLine = true;
            timelinePosY = other.transform.position.y;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("TimeLine"))
        {
            isInLine = false;
        }
    }


    #endregion
}