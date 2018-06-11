using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestVector3 : MonoBehaviour {

    public Transform A, B;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    [ContextMenu("Calculate")]
    public void calculate()
    {
        print(Vector3.Distance(A.position, B.position));
    } 
}
