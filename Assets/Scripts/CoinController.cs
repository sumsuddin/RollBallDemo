using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.Rotate(90, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, 0, 120) * Time.deltaTime);
	}
}
