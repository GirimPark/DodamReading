using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            OnMouseDown();
        }
    }

    private void OnMouseDown()
    {
        SceneManager.LoadScene("MainLibraryScene");
    }
}
