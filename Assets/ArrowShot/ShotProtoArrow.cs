using UnityEngine;
using System.Collections;

public class ShotProtoArrow : MonoBehaviour 
{
    public Transform arrow;
    public float power;

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
            var obj = (Transform)Instantiate(arrow, parent.position + Quaternion.Euler(0, parentEuler.y,0) * new Vector3(0.3f, 1, 0) , Quaternion.Euler(90, 0, -parentEuler.y));
            obj.GetComponent<Rigidbody>().AddForce(Quaternion.Euler(0, parentEuler.y,0) * new Vector3(0, 0, power), ForceMode.Impulse);
        }
	}
}
