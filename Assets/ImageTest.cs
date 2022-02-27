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

        //�摜���擾�ł���܂ő҂�
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            //�擾�����摜�̃e�N�X�`����RawImage�̃e�N�X�`���ɒ���t����
            _image.texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
        }
    }
}