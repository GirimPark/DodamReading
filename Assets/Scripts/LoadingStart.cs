using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //3초 기다렸다가 다음 신으로 이동하기
            StartCoroutine(WaitAndLoadScene()); 
            IEnumerator WaitAndLoadScene()
            {
            yield return new WaitForSeconds(3.0f);

            SceneManager.LoadScene("MainLibraryScene");//신 변경
            }
    }
}
