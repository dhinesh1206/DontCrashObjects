using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomSize : MonoBehaviour {

    public float sizeTime, mininterval, maxinterval;
    public Vector3 minSize, maxSize;
    bool maxvalue, minvalue;
	// Use this for initialization
	void Start () {
        StartCoroutine(randomsize(Random.Range(mininterval,maxinterval)));
        maxvalue = true;
	}
	
    IEnumerator randomsize(float time)
    {
        yield return new WaitForSeconds(time);

        if (minvalue)
        {
            iTween.ScaleTo(gameObject, maxSize, sizeTime);
            maxvalue = true;
        } else if (maxvalue)
        {
            iTween.ScaleTo(gameObject, minSize, sizeTime);
            minvalue = true;
        }
        StartCoroutine(randomsize(Random.Range(mininterval, maxinterval)));
    }
}
