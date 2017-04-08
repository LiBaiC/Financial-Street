using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour, UIPanelInterface
{

    static public UIMainMenu Instance;

    static public string Name = UIPanelName.UIMainMenu;

    public ScrollRect ScrollRectcontent;

    //public List<Image> mImages;

    void Awake()
    {
        Instance = this;
    }

	// Use this for initialization
	void Start () {

        UIManager.Instance.AddUIPanel(Name, this.gameObject);
        //ShowPanel();
    }

    void OnEnable()
    {
        SetPictureResert();
    }
	
	// Update is called once per frame
	void Update () {
	
        if((Input.GetKeyDown(KeyCode.Escape))&& (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer))
        {
            Application.Quit();
        }
	}

    public void ShowPanel()
    {
        UIManager.Instance.ShowPanel(Name);
    }

    public void HidePanel()
    {
        UIManager.Instance.HidePanel(Name);
    }

    public void ResertMainMenuPanel()
    {
        SetPictureResert();
        //Debug.Log("如果切换了主页图片，则复原");
    }

    public void ShowSandTabelPanel()
    {
        UIManager.Instance.ShowPanel(UIPanelName.UISandTable,-100f);
        HidePanel();
    }

    public void ShowPropertyPanel()
    {
        UIManager.Instance.ShowPanel(UIPanelName.UIProperty);
        HidePanel();
    }

    public void ShowAreaPanel()
    {
        UIManager.Instance.ShowPanel(UIPanelName.UIArea);
        HidePanel();
    }

    public void ShowRongFuPanel()
    {
        UIManager.Instance.ShowPanel(UIPanelName.UIRongFu);
        HidePanel();
    }

    public void ShowBrandPanel()
    {
        UIManager.Instance.ShowPanel(UIPanelName.UIBrand);
        HidePanel();
    }

    private void SetPictureResert()
    {
        ScrollRectcontent.content.localPosition = Vector3.zero;
    }
}
