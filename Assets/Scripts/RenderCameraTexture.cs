using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RenderCameraTexture : MonoBehaviour
{
    public GameObject cameras;
    public GameObject mainViewCamera;
    

    // Start is called before the first frame update
    void Start()
    {
        
        for (int i = 0; i<cameras.transform.childCount; i++)
        {
            GameObject tmp = new GameObject();
            tmp.name = "image"+i.ToString();
            tmp.transform.parent = transform.GetChild(0).GetChild(0);
            RenderTexture ren = new RenderTexture(960, 540, 24);
            ren.name = "texture" + i.ToString();
            cameras.transform.GetChild(i).GetComponent<Camera>().targetTexture = ren;
            cameras.transform.GetChild(i).GetComponent<AudioListener>().enabled = false;
            tmp.AddComponent<RawImage>();
            tmp.GetComponent<RectTransform>().sizeDelta = new Vector2(480, 270);
            tmp.AddComponent<Button>();
            tmp.GetComponent<Button>().onClick.AddListener(()=>SetMainTexture(ren));
            Debug.Log(tmp.GetComponent<RectTransform>().rect);
            tmp.GetComponent<RawImage>().texture = ren;  
        }
        SetMainTexture(cameras.transform.GetChild(0).GetComponent<Camera>().targetTexture);
    }

    private void SetMainTexture(RenderTexture tex)
    {
        mainViewCamera.GetComponent<RawImage>().texture = tex;
    }

 

    // Update is called once per frame
    void Update()
    {
        
    }
}
