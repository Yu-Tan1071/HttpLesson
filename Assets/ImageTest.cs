using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ImageTest : MonoBehaviour
{
    private const string URI = "https://joytas.net/php/man.jpg";

    [SerializeField] private RawImage _image;

    IEnumerator Start()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(URI);

        //画像を取得できるまで待つ
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            //取得した画像のテクスチャをRawImageのテクスチャに張り付ける
            _image.texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
        }
    }
}