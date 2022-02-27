using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ImageController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(HttpConnect());
    }

    IEnumerator HttpConnect() {
        string url = "https://joytas.net/php/man.jpg";
        UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(url);
        yield return uwr.SendWebRequest();
        if(uwr.isHttpError || uwr.isNetworkError) {
            Debug.Log(uwr.error);
        } else {
            //�_�E�����[�h���ꂽ�摜��Texture�^�Ŏ擾
            Texture texture = DownloadHandlerTexture.GetContent(uwr);
           
            //texture����X�v���C�g�ɕϊ�
            //Sprite.Create(texture2D,texture2D�̂ǂ����g����,�摜��pivot���w��)
            Sprite sp = Sprite.Create((Texture2D)texture,
                new Rect(0, 0, texture.width, texture.height),
                new Vector2(0.5f, 0.5f));

            //Image�R���|�[�l���g�擾
            Image image = GetComponent<Image>();

            //�擾�����摜�T�C�Y�����Ƃ�Image�R���|�[�l���g�̑傫���ݒ�
            image.rectTransform.sizeDelta = new Vector2(
               texture.width, texture.height);

            //�쐬�����X�v���C�g��ݒ�
            image.sprite = sp;
             
        }
    }
}
