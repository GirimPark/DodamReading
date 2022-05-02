using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FairyVoid : MonoBehaviour
{
    public GameObject Text1; //fairyT
    public bool closetTF;//옷장으로 이동했는지 확인
    // Start is called before the first frame update
    void Start()
    {
        closetTF = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*손가락 터치
        if(Input.touchCount>0){
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began://터치 시작했을 때
                    break;
                case TouchPhase.Moved://터치한 상태에서 운직였을 때
                    break;
                case TouchPhase.Stationary://움직이다가 가만히 있을 때
                    break;
                case TouchPhase.Ended://화면에서 손 뗐을 때
                    break;
                case TouchPhase.Canceled://시스템에 의해 터치 취소됐을 때
                    break;
            }
        }
        */
        //옷장 씬으로 이동하기
        if(Input.GetMouseButtonDown(0)){
            //fairyT.SetActive(true);
            closetTF = true;
            SceneManager.LoadScene("ClosetScene");
            DontDestroyOnLoad(Text1);
        }
    }
}
