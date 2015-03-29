using UnityEngine;
using System.Collections;

public class ShotProtoArrow : MonoBehaviour 
{
    public Transform arrow;
    public float power;
    public Vector3 targetPnt = new Vector3(0, 0, 1);
    public Vector3 startPnt;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            var parent = gameObject.transform;
            var parentEuler = parent.rotation.eulerAngles;
            var shotAngle = 
                Quaternion.Euler(0, parentEuler.y, 0) * 
                Quaternion.Euler(Quaternion.LookRotation(targetPnt - startPnt).eulerAngles + new Vector3(90, 0, 0));

            var obj = (Transform)Instantiate(arrow, parent.position + Quaternion.Euler(0, parentEuler.y, 0) * startPnt, shotAngle);
            obj.GetComponent<Rigidbody>().AddForce(Quaternion.Euler(0, parentEuler.y, 0) * (targetPnt - startPnt).normalized * power, ForceMode.Impulse);
        }
	}
}
