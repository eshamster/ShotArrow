using UnityEngine;
using System.Collections;

public class TargetMaker : MonoBehaviour
{
    public Transform player;
    public Transform target;
    public float minDist = 2;
    public float maxDist = 10;

    public int maxTarget = 100;

    private bool isReserved = false;

    void Start()
    {
    }

    void Update()
    {
        if (!isReserved && GameObject.FindGameObjectsWithTag("Target").Length < maxTarget)
        {
            isReserved = true;
            StartCoroutine(MakeTargetAfter(1f));
        }
    }

    IEnumerator MakeTargetAfter(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        float dist = Random.Range(minDist, maxDist);
        var quat = Quaternion.Euler(Random.Range(0, -180f), Random.Range(0, 360f), Random.Range(0, -180f));
        var obj = (Transform)Instantiate(this.target, player.transform.position + quat * new Vector3(0, 0, dist), quat * Quaternion.Euler(90, 0, 0));
        isReserved = false;
    }
}
