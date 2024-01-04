using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class DynamicCamera : MonoBehaviour
{
    public GameObject cameras;
    public RawImage mainView;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < cameras.transform.childCount; i++)
        {
            Vector2 size = new Vector2(4.8f, 2.7f);
            GameObject obj = new GameObject();
            obj.transform.localScale = size;
            obj.transform.name = "CameraView" + i.ToString();
           obj.AddComponent<RawImage>();
            obj.AddComponent<Button>();
            RenderTexture tex = new RenderTexture(1920,1080,32);
            cameras.transform.GetChild(i).GetComponent<Camera>().targetTexture = tex;
            obj.GetComponent<RawImage>().texture = tex;
            obj.GetComponent<Button>().onClick.AddListener(() => changeView(tex));
            obj.transform.parent = transform;
        }
        changeView(cameras.transform.GetChild(0).GetComponent<Camera>().targetTexture);
    }


    private void changeView(RenderTexture tex)
    {
        mainView.texture = tex;
    }
};