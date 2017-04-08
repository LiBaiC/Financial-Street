using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 360Texture Control
/// </summary>
public class UIControl : MonoBehaviour {

    public Transform sphereWinTrans;

    public List<MyTextrue> myTextureList;

    [SerializeField]
    private int index;

    private Renderer render;

    // Use this for initialization
    void Start () {

        if (sphereWinTrans != null)
        {
            render = sphereWinTrans.GetComponent<Renderer>();
            render.materials[0].SetTexture("_MainTex", myTextureList[0].myTexture);
        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnProClick()
    {
        if (render!=null)
        {
            index--;
            if (index < 0)
            {
                index = myTextureList.Count - 1;
            }
            render.materials[0].SetTexture("_MainTex", myTextureList[index].myTexture);
        }

        SetDefultRotate(myTextureList[index]);
        MusicManager.Instance.PlayButtonClick();
    }

    public void OnNextClick()
    {
        if (render != null)
        {
            index++;
            if (index > myTextureList.Count - 1)
            {
                index = 0;
            }
            render.materials[0].SetTexture("_MainTex", myTextureList[index].myTexture);
        }

        SetDefultRotate(myTextureList[index]);
        MusicManager.Instance.PlayButtonClick();
    }

    public void SetDefultRotate(MyTextrue texture)
    {
        if (texture.angle == 0)
        {
            sphereWinTrans.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            sphereWinTrans.eulerAngles = new Vector3(0, texture.angle, 0);
        }
        MusicManager.Instance.PlayButtonClick();
       
    }

    public void OnResertRotate()
    {
        SetDefultRotate(myTextureList[index]);
    }
}

[System.Serializable]
public class MyTextrue
{
    public int angle = 0;

    public Texture myTexture;
}