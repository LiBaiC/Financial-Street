using UnityEngine;
using System.Collections;

public class UIBrand : MonoBehaviour,UIPanelInterface {

    static public UIBrand Instance;

    public const string Name = UIPanelName.UIBrand;

    void Awake()
    {
        Instance = this;
    }

	// Use this for initialization
	void Start () {
        //UIManager.Instance.AddUIPanel(Name,this.gameObject);
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
       
    }

    public void HidePanel()
    {
        UIManager.Instance.ShowPanel(UIPanelName.UIMainMenu);
        UIManager.Instance.HidePanel(Name);
    }

}
