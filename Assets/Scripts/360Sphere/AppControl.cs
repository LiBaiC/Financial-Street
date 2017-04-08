using UnityEngine;
using System.Collections;

public class AppControl : MonoBehaviour {

    public Transform target;

    public float rotationSpeed = 300;

	// Use this for initialization
	void Start () {

    }

    void OnEnable()
    {
        if (target != null)
        {
            target.transform.eulerAngles = Vector3.zero;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
#else
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
#endif
        {
            target.Rotate(new Vector3(0, 0, Input.GetAxis("Mouse Y") * Time.deltaTime * rotationSpeed), Space.World);
            target.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * Time.deltaTime * rotationSpeed, 0),Space.World);
        }

    }
}
