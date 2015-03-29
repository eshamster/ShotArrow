using UnityEngine;
using System.Collections;

public class ArrowMover : MonoBehaviour
{
    public float rotateThreshold = 0.3f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameObject.GetComponent<Rigidbody>().velocity.magnitude > rotateThreshold)
        {
            gameObject.transform.up = Vector3.Slerp(gameObject.transform.up, gameObject.GetComponent<Rigidbody>().velocity.normalized, Time.deltaTime * 2);
        }
    }
}
