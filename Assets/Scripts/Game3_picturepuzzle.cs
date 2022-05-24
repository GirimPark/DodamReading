using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game3_picturepuzzle : MonoBehaviour
{
    GameObject pass;
    bool pencilv;
    bool letterv;


    private void Start()
    {
        pass = transform.GetChild(1).gameObject;
    }


    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            OnMouseDown();
        }

        if (pencilv && letterv)
        {
            StartCoroutine(WaitAndLoadScene());
        }
    }


    private void OnMouseDown()
    {
        pass.GetComponent<SpriteRenderer>().enabled = true;
        pencilv = GameObject.Find("연필").transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().enabled;
        letterv = GameObject.Find("편지").transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().enabled;
        Debug.Log("pencilv : "+pencilv);
        Debug.Log("letterv : " + letterv);
    }


    IEnumerator WaitAndLoadScene()
    {
        yield return new WaitForSeconds(1.0f);

        SceneManager.LoadScene("M4_StoryScene");
    }
}
