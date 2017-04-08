using System;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject UICamera;

    public Transform UIRoot;

    static public UIManager Instance;

    private List<GameObject> UIGameobjects;

    public string UIPrefabDir = "Prefab/UI";

    void Awake()
    {
        Instance = this;
        LoadUIPrafab();
    }

    private Dictionary<string, GameObject> mCurrentPanelPool = new Dictionary<string, GameObject>();
  
    private List<string> topPanelName = new List<string>();

    public void LoadUIPrafab()
    {
        UIGameobjects = new List<GameObject>(Resources.LoadAll<GameObject>(UIPrefabDir));

        if(UIGameobjects.Count<1)
        {
            Debug.LogError("UI prefab doesn't existed!");
            return;
        }
        
    }

    public void AddUIPanel(string name, GameObject panel)
    {
        if (!mCurrentPanelPool.ContainsKey(name))
        {
            mCurrentPanelPool.Add(name, panel);
            //panel.SetActive(false);
        }
        else
        {
            mCurrentPanelPool.Remove(name);
            mCurrentPanelPool.Add(name, panel);
            Debug.Log("UIPanel " + name + "is Exsit!");
        }
    }

    public void ShowPanel(string name, float depthZ = 0)
    {
        if (!mCurrentPanelPool.ContainsKey(name))
        {
            
            //当前UI界面池内不包含要显示的UI界面
            GameObject obj = new GameObject();
            foreach (var item in UIGameobjects)
            {
                if(item.name == name)
                {
                    obj = (GameObject)Instantiate(item);
                    mCurrentPanelPool.Add(name, obj);
                    obj.transform.SetParent(UIRoot);
                    obj.transform.localPosition =new Vector3(0,0, depthZ);
                    obj.transform.localScale = Vector3.one;
                }
            }

            if (obj == null)
            {
                Debug.LogError("UIPanel " + name + "is Not Exsit!");
                return;
            }

        }

        topPanelName.Add(name);
        mCurrentPanelPool[name].transform.localPosition = new Vector3(0, 0, depthZ);
        mCurrentPanelPool[name].SetActive(true);

    }

    public void HidePanel(string name)
    {
        if (!mCurrentPanelPool.ContainsKey(name))
        {
            Debug.LogError("UIPanel " + name + "is Not Exsit!");
            return;
        }

        mCurrentPanelPool[name].SetActive(false);

        for (int i = 0; i < topPanelName.Count; i++)
        {
            if (topPanelName[i].Equals(name))
            {
                topPanelName.Remove(topPanelName[i]);
            }
        }

    }

    public GameObject GetTopPanel()
    {
        if (topPanelName.Count < 1)
        {
            return null;
        }

        return mCurrentPanelPool[topPanelName[topPanelName.Count - 1]];
    }

    public bool PanelIsShow(string name)
    {
        if (mCurrentPanelPool.ContainsKey(name))
        {
            return mCurrentPanelPool[name].activeSelf;
        }
        else
        {
            Debug.Log("UIPanel " + name + "is Not Exsit!");
            return false;
        }
    }

    public void ToggleShowUI(bool show)
    {
        UICamera.SetActive(show);
    }
}