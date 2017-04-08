using UnityEngine;
using System.Collections;

public class PanoramaCameraControl : MonoBehaviour
{
    public Camera camera;

    public float xSpeed = 10.0f;//X（左右旋转速度）  
    public float ySpeed = 10.0f;//（上下旋转速度）  
    public float yMinLimit = -20;//旋转上下角度最小限制  
    public float yMaxLimit = 80;
    float X = 0.0f;
    float Y = 0.0f;


    //摄像机视距相关
    public float cameraFieldOfView = 60.0f;
    private float curCameraFieldOfView;
    public float cameraMaxFieldOfView = 90.0f;
    public float cameraMinFieldOfView = 40.0f;
    public float cameraFieldOfViewSpeed = 1.0f;
    private Vector2 fingerPoint1;
    private Vector2 fingerPoint2;

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        X = angles.y;
        Y = angles.x;
    }

    void OnEnable()
    {
        fingerPoint1 = new Vector2(0, 0);
        fingerPoint2 = new Vector2(0, 0);
        camera.fieldOfView = cameraFieldOfView;
        curCameraFieldOfView = cameraFieldOfView;
    }

    void Update()
    {

    }

    void LateUpdate()
    {
        if (Input.touchCount > 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(1).phase == TouchPhase.Moved)
            {
                AdjustFieldOfView();
            }
            else
            {
                fingerPoint1 = new Vector2(0, 0);
                fingerPoint2 = new Vector2(0, 0);
            }
        }
        else
        {

#if UNITY_EDITOR
            if (Input.GetMouseButton(0))
#endif

#if UNITY_IPHONE || UNITY_ANDROID
                if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
#endif
                {
                    X -= Input.GetAxis("Mouse X") * xSpeed;
                    Y += Input.GetAxis("Mouse Y") * ySpeed;
                    Y = ClampAngle(Y, yMinLimit, yMaxLimit);
                    //摄像机偏转角度  
                    Quaternion rotateAngle = Quaternion.Euler(Y, X, 0);
                    transform.rotation = rotateAngle;

                }
        }
    }

    void AdjustFieldOfView()
    {
        //上次两个手指之间的距离和这次的距离相比
        Vector2 tmpFingerPoint1 = Input.GetTouch(0).position;
        Vector2 tmpFingerPoint2 = Input.GetTouch(1).position;
        float curFingerDistance = Mathf.Sqrt(Mathf.Pow((fingerPoint1.x - fingerPoint2.x),2)
                                            + Mathf.Pow((fingerPoint1.y - fingerPoint2.y), 2));

        float tmpFingerDistance = Mathf.Sqrt(Mathf.Pow((tmpFingerPoint1.x - tmpFingerPoint2.x), 2)
                                            + Mathf.Pow((tmpFingerPoint1.y - tmpFingerPoint2.y), 2));


        float fovValue = curCameraFieldOfView + (curFingerDistance-tmpFingerDistance) * cameraFieldOfViewSpeed;
        camera.fieldOfView = Mathf.Clamp(fovValue, cameraMinFieldOfView, cameraMaxFieldOfView);

        curCameraFieldOfView = camera.fieldOfView;
        fingerPoint1 = tmpFingerPoint1;
        fingerPoint2 = tmpFingerPoint2;
    }

    static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }

}