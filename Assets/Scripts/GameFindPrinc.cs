using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFindPrinc : MonoBehaviour
{
    public bool isPrincess;//공주 클릭했는지
    public int clickNum;//클릭 횟수
    // Start is called before the first frame update
    void Start()
    {
        isPrincess = false;   
        clickNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){//마우스 클릭시
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Camera.main.transform.forward);
            if(hit.collider!=null){//클릭한 오브젝트 이름 가져옴
                GameObject click_obj = hit.transform.gameObject;
                //Debug.Log(click_obj.name);
                if(click_obj.name=="charc2"){//공주 클릭했을 때
                    isPrincess=true;
                }
            }
            clickNum++;
        }   
    }
}
