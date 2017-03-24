using System;
using System.Collections.Generic;
using UnityEngine;

public class UImanager : MonoBehaviour
{
    public GameObject UICamera;

    public Transform UIRoot;

    static public UImanager Instance;

    void Awake()
    {
        Instance = this;
    }

    private Dictionary<string, GameObject> mPanelPool = new Dictionary<string, GameObject>();

    private List<string> topPanelName = new List<string>();

    public void AddUIPanel(string name, GameObject panel)
    {
        if (!mPanelPool.ContainsKey(name))
        {
            mPanelPool.Add(name, panel);
            panel.SetActive(false);
        }
        else
        {
            Debug.Log("UIPanel " + name + "is Exsit!");
        }
    }

    public void ShowPanel(string name)
    {
        if (!mPanelPool.ContainsKey(name))
        {
            Debug.Log("UIPanel " + name + "is Not Exsit!");
            return;
        }

        topPanelName.Add(name);

        mPanelPool[name].SetActive(true);

    }

    public void HidePanel(string name)
    {
        if (!mPanelPool.ContainsKey(name))
        {
            Debug.Log("UIPanel " + name + "is Not Exsit!");
            return;
        }

        mPanelPool[name].SetActive(false);

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

        return mPanelPool[topPanelName[topPanelName.Count - 1]];
    }

    public bool PanelIsShow(string name)
    {
        if (mPanelPool.ContainsKey(name))
        {
            return mPanelPool[name].activeSelf;
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