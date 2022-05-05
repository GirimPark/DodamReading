using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadReadingReport : MonoBehaviour
{
    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            OnMouseDown();
        }
    }


    private void OnMouseDown()
    {
        StartCoroutine(LoadMyAsyncScene());
    }

    IEnumerator LoadMyAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("ReadingReport");

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
