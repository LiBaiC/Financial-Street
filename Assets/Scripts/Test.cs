using UnityEngine;
using System.Collections;

// 定义一个手势的枚举
public enum Dir : int
{
    Left = 0,
    Stop,
    Right
}

public class Test : MonoBehaviour
{

    public GameObject _plane;// 挂一个用来显示图片的plane对象
    public float Fps = 25f;

    public string TextureDir;

    public Texture2D[] _texAll; 

    Dir _touchDir;       // 当前的手势

    float curTime = 0;

    int _index = 0;

    //鼠标滑动相关
    private Vector2 first = Vector2.zero;

    private Vector2 second = Vector2.zero;


    void Awake()
    {
        SetMaterial();
        if (_texAll.Length>0)
        {
            _plane.GetComponent<Renderer>().material.mainTexture = _texAll[0];
        }
    }

    void OnEnable()
    {
        _touchDir = Dir.Stop;
    }

    [ContextMenu("加载材质")]
    public void SetMaterial()
    {
        _texAll = Resources.LoadAll<Texture2D>(TextureDir);
        //_texAll = LoadUtil.LoadAsset<Texture2D>(TextureDir, "jpg");
    }

#if UNITY_EDITOR
    void OnGUI()
    {
        if (Event.current.type == EventType.MouseDown)
        {
            //记录鼠标按下的位置 　　
            first = Event.current.mousePosition;
        }

        if (Event.current.type == EventType.MouseDrag)
        {
            //记录鼠标拖动的位置 　　
            second = Event.current.mousePosition;
            if (second.x < first.x)
            {
                //拖动的位置的x坐标比按下的位置的x坐标小时,响应向左事件 　　
                _touchDir = Dir.Left;
            }
            if (second.x > first.x)
            {
                //拖动的位置的x坐标比按下的位置的x坐标大时,响应向右事件 　　
                _touchDir = Dir.Right;
            }
            first = second;
        }
        else
        {
            _touchDir = Dir.Stop;
        }



    }
#endif
    void Update()
    {
#if UNITY_IPHONE || UNITY_ANDROID 
        // 当运行平台为IOS或Android时
        if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
        //if(1==1)
        {
            // 当输入的触点数量大于0，且手指移动时

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                if (Input.GetTouch(0).deltaPosition.x < 0 - Mathf.Epsilon)
                    _touchDir = Dir.Left;
                else
                    _touchDir = Dir.Right;
            }
            // 当输入的触点数量大于0，且手指不动时

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary)
            {
                _touchDir = Dir.Stop;
            }

            //当没有触摸时
            if (Input.touchCount < 1)
            {
                _touchDir = Dir.Stop;
            }
        }
#endif
        // 根据手势顺序或逆序换图

        if (_touchDir != Dir.Stop)
        {
            if (_touchDir == Dir.Left)
            {
                curTime += Time.deltaTime;
                if (curTime > 1/Fps)
                {
                    curTime = 0;
                    _index = _index == 0 ? _texAll.Length - 1 : _index;
                    _plane.GetComponent<Renderer>().material.mainTexture = _texAll[_index--];
                }
            }
            else
            {
                curTime += Time.deltaTime;
                if (curTime > 1/Fps)
                {
                    curTime = 0;
                    _index = _index == _texAll.Length - 1 ? 0 : _index;
                    _plane.GetComponent<Renderer>().material.mainTexture = _texAll[_index++];
                }
            }
        }
    }
}