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
    public float duration = 0.5f; // 每0.5秒换一张图片

    public Texture2D[] _texAll;  // 挂30张图片

    Dir _touchDir;       // 当前的手势

    float curTime = 0;

    int _index = 0;

    void Update()
    {
        // 当运行平台为IOS或Android时

        if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
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
        }

        // 根据手势顺序或逆序换图

        if (_touchDir != Dir.Stop)
        {
            if (_touchDir == Dir.Left)
            {
                curTime += Time.deltaTime;
                if (curTime > duration)
                {
                    curTime = 0;
                    _index = _index == 0 ? _texAll.Length - 1 : _index;
                    _plane.GetComponent<Renderer>().material.mainTexture = _texAll[_index--];
                }
            }
            else
            {
                curTime += Time.deltaTime;
                if (curTime > duration)
                {
                    curTime = 0;
                    _index = _index == _texAll.Length - 1 ? 0 : _index;
                    _plane.GetComponent<Renderer>().material.mainTexture = _texAll[_index++];
                }
            }
        }
    }
}