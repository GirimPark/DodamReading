using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorShow : MonoBehaviour
{
    [SerializeField] Texture2D cursorImg;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        //커서 이미지 크기 조정
        cursorImg = ScaleTexture(cursorImg, 100 , 100);
        
        //커서를 화면에 표시한다
        Cursor.SetCursor(cursorImg, Vector2.zero, CursorMode.ForceSoftware);
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = true;
    }
    //커서 이미지 크기 조정 함수
    Texture2D ScaleTexture(Texture2D source, int targetWidth, int targetHeight)
    {
        Texture2D source2 = duplicateTexture(source);
        Texture2D result = new Texture2D(targetWidth, targetHeight, source2.format, true);
        Color[] rpixels = result.GetPixels(0);
        float incX = (1.0f / (float)targetWidth);
        float incY = (1.0f / (float)targetHeight);
        for (int px = 0; px < rpixels.Length; px++)
        {
            rpixels[px] = source2.GetPixelBilinear(incX * ((float)px % targetWidth), incY * ((float)Mathf.Floor(px / targetWidth)));
        }
        result.SetPixels(rpixels, 0);
        result.Apply();
        return result;
    }
    
    //텍스처 읽을 수 있도록 해주는 기능 함수
    Texture2D duplicateTexture(Texture2D source)
    {
        RenderTexture renderTex = RenderTexture.GetTemporary(
                    source.width,
                    source.height,
                    0,
                    RenderTextureFormat.Default,
                    RenderTextureReadWrite.Linear);

        Graphics.Blit(source, renderTex);
        RenderTexture previous = RenderTexture.active;
        RenderTexture.active = renderTex;
        Texture2D readableText = new Texture2D(source.width, source.height);
        readableText.ReadPixels(new Rect(0, 0, renderTex.width, renderTex.height), 0, 0);
        readableText.Apply();
        RenderTexture.active = previous;
        RenderTexture.ReleaseTemporary(renderTex);
        return readableText;
    }
}
