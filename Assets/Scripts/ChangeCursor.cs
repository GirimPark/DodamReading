using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCursor : MonoBehaviour
{
    [SerializeField] Texture2D cursorImg;
    // Start is called before the first frame update
    void Start()
    {
        //커서 이미지 크기 조정
        //cursorImg = new Texture2D(200,200);
        //커서를 화면에 표시한다
        Cursor.SetCursor(cursorImg, Vector2.zero, CursorMode.ForceSoftware);
    }

}
