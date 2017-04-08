using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourceLoad : MonoBehaviour {

    [SerializeField]
    private List<Texture2DPackage> texture2DList;

    void Awake()
    {

    }
}

[System.Serializable]
public class Texture2DPackage
{
    public string TextureDir;

    public List<Texture2D> TexturePag;
}