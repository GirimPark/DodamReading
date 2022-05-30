using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToClick : MonoBehaviour
{
    [SerializeField]float speed = 50f;
    Vector3 mousePos, transPos, targetPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform.position);
        if(Input.GetMouseButton(0))
            CalTargetPos();
            MoveToTarget();
    }
    void CalTargetPos(){
        mousePos = Input.mousePosition;
        transPos = Camera.main.ScreenToWorldPoint(mousePos);
        targetPos = new Vector3(transPos.x, transPos.y, 0);
    }
    void MoveToTarget(){
        //transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime*speed);
        transform.position = targetPos;
    }
}
