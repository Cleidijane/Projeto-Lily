using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentar : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void MoverUI(){
		this.transform.position = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0);
	}
}
