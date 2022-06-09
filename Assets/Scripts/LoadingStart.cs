using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteKey("prince");
        PlayerPrefs.DeleteKey("mermaid");
        PlayerPrefs.DeleteKey("sister");
        PlayerPrefs.DeleteKey("witch");
        PlayerPrefs.DeleteKey("nTHScene");
        PlayerPrefs.SetInt("startScene", 10);
        PlayerPrefs.SetInt("loadNum", 0);
    }

    // Update is called once per frame
    void Update()
    {
        //3초 기다렸다가 다음 신으로 이동하기
            StartCoroutine(WaitAndLoadScene()); 
            IEnumerator WaitAndLoadScene()
            {
            yield return new WaitForSeconds(1.0f);

            SceneManager.LoadScene("MainLibraryScene");//신 변경
            }
    }
}
