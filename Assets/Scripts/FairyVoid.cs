using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FairyVoid : MonoBehaviour
{
    public GameObject fairyT;
    public bool closetTF;//옷장으로 이동했는지 확인
    // Start is called before the first frame update
    void Start()
    {
        closetTF = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetMouseButtonDown(0)){
            Debug.Log("누름");
            fairyT.SetActive(true);
        }*/
        //옷장 씬으로 이동하기
        if(Input.GetMouseButtonDown(0)){
            SceneManager.LoadScene("ClosetScene");
            closetTF = true;
        }
    }
}
