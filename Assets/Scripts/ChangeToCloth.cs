using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeToCloth : MonoBehaviour
{
    public bool closetTF;
    public int closetN;
    // Start is called before the first frame update
    void Start()
    {
        closetN = 0;
        //closetTF = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){//마우스 클릭시
            closetTF = true;
            closetN++;
            Debug.Log(closetTF);
            //옷장 씬으로 이동하기
            SceneManager.LoadScene("ClosetScene");
        }
    }
}
