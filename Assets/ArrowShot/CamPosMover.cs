using UnityEngine;
using System.Collections;

public class CamPosMover : MonoBehaviour 
{
    public float dist = 2f;
    public float minDist = 1f;
    public float maxDist = 5f;
    public float distChange = 1f;

    public float camSpeed = 4f;
    public Vector3 gazeOffset;
    public Vector3 euler;
    public bool reverseVertical;


	// Use this for initialization
	void Start () 
    {
    }
	
	// Update is called once per frame
	void Update () 
    {
        euler.y += camSpeed * Input.GetAxis("Mouse X");
        euler.x += camSpeed * Input.GetAxis("Mouse Y") * ((reverseVertical) ? 1 : -1);
        euler.x = InRange(euler.x, -89, 89);

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll < 0)
            dist += distChange;
        else if (scroll  > 0)
            dist -= distChange;
        dist = InRange(dist, minDist, maxDist);

        CamPosObj.transform.localEulerAngles = euler;
        CamPosObj.transform.localPosition = Quaternion.Euler(euler) * new Vector3(0, 0, -1) * dist + gazeOffset;
    }

    public void ResetRotate()
    {
        euler.y = 0;
    }

    private float InRange(float val, float min, float max)
    {
        if (val > max)
            return max;
        else if (val < min)
            return min;
        else
            return val;
    }

    private GameObject CamPosObj { get { return gameObject; } }
    public Vector3 CamPos { get { return CamPosObj.transform.localPosition;  } }
}
