using UnityEngine;
using System.Collections;

public class UIRongFu : MonoBehaviour,UIPanelInterface
{

    static public UIRongFu Instance;

    public const string Name = UIPanelName.UIRongFu;

    private Camera Pic360Camera;

    void Awake()
    {
        Instance = this;
        Pic360Camera = GameObject.FindGameObjectWithTag("360Camera").GetComponent<Camera>();
    }

    // Use this for initialization
    void Start () {
    }

    void OnEnable()
    {
        Set360CameraActive(true);
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
        //UIManager.Instance.ShowPanel(UIPanelName.UIRongFu);
    }

    public void HidePanel()
    {
        UIManager.Instance.ShowPanel(UIPanelName.UIMainMenu);
        Set360CameraActive(false);
        UIManager.Instance.HidePanel(Name);
    }
    private void Set360CameraActive(bool isActive)
    {
        if (Pic360Camera != null)
        {
            Pic360Camera.enabled = isActive;
        }
    }
}
