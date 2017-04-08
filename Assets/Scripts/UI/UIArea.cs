using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UIArea : MonoBehaviour,UIPanelInterface {

    static public UIArea Instance;

    public const string Name = UIPanelName.UIArea;

    public Image imgArea;

    [SerializeField]
    List<Sprite> mySprite;

    void Awake()
    {
        Instance = this;
    } 

	// Use this for initialization
	void Start () {
        //UIManager.Instance.AddUIPanel(Name, this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
        if ((Input.GetKeyDown(KeyCode.Escape)) && (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer))
        {
            UIManager.Instance.ShowPanel(UIPanelName.UIMainMenu);
            HidePanel();
        }
    }

    public void ShowPanel()
    {
        //UIManager.Instance.ShowPanel(UIPanelName.UIArea);
    }

    public void HidePanel()
    {
        UIManager.Instance.ShowPanel(UIPanelName.UIMainMenu);
        UIManager.Instance.HidePanel(Name);
    }

    /// <summary>
    /// 大区位
    /// </summary>
    public void BigAreaOnClick()
    {
        imgArea.sprite = mySprite[0];
    }

    /// <summary>
    /// 周边绿化
    /// </summary>
    public void SurroundingGreenOnClick()
    {
        imgArea.sprite = mySprite[1];

    }

    /// <summary>
    /// 周边配套
    /// </summary>
    public void PeripheralSupportOnClick()
    {
        imgArea.sprite = mySprite[2];
    }
}
