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
        PlayerPrefs.DeleteKey("key");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("key", 10);
        //옷장 씬으로 이동하기
        if(Input.GetMouseButtonDown(0)){
            //fairyT.SetActive(true);
            closetTF = true;
            //DontDestroyOnLoad(Text1);
            /*if(SceneManager.GetActiveScene().name=="FairyStoryScene"){
                PlayerPrefs.SetInt("key", 10);
            }else {
                //PlayerPrefs.DeleteAll();
                if(SceneManager.GetActiveScene().name=="ClosetScene"){
                    //PlayerPrefs.DeleteKey("key");
                    PlayerPrefs.SetInt("key0", 20);
                }
            }*/
            //PlayerPrefs.SetInt("key", 10);
            Debug.Log(PlayerPrefs.HasKey("key"));
            SceneManager.LoadScene("ClosetScene");
        }
    }
}
