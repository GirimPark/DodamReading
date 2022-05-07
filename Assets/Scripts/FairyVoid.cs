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
        //옷장 씬으로 이동하기
        if(Input.GetMouseButtonDown(0)){
            //fairyT.SetActive(true);
            closetTF = true;
            SceneManager.LoadScene("ClosetScene");
            DontDestroyOnLoad(Text1);
        }
    }
}
