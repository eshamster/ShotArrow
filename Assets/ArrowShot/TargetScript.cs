using UnityEngine;
using System.Collections;

public class TargetScript : MonoBehaviour {
    public float shrinkSpeed = 1;
    private bool hasColled = false;

    private const float DESTROY_SIZE = 0.001f;
    private Vector3 baseScale;
    private float nowScale = 1f;

	void Start () 
    {
        this.baseScale = gameObject.transform.localScale;
	}

    void FixedUpdate()
    {
        gameObject.transform.localScale = this.baseScale * this.nowScale;

        if (hasColled)
        {
            float shrinkThisFrame = 0.9f / shrinkSpeed;
            this.nowScale *= shrinkThisFrame;

            if (nowScale < DESTROY_SIZE)
            {
                Destroy(gameObject);
            }
        }
	}
    
    void OnCollisionEnter(Collision col)
    {
        var obj = col.gameObject;
        if (obj.tag == "Arrow")
        {
            hasColled = true;
        }
    }

    void OnCollisionExit(Collision col)
    {
        var obj = col.gameObject;
        if (obj.tag == "Arrow")
        {
            var thisCol = gameObject.GetComponent<Collider>();
            thisCol.enabled = false;
        }
    }
}
