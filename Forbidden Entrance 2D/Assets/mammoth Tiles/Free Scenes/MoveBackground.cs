﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoveBackground_asset_test {
public class MoveBackground : MonoBehaviour {

	public float speed;
	private float x;
	public float PontoDeDestino;
	public float PontoOriginal;


	// Use this for initialization
	void Start () {
		//PontoOriginal = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {

		x = transform.position.x;
		x += speed * Time.deltaTime;
		transform.position = new Vector3 (x, transform.position.y, transform.position.z);

		if (PontoDeDestino <0){
			if (x <= PontoDeDestino){

			x = PontoOriginal;
			transform.position = new Vector3 (x, transform.position.y, transform.position.z);
		}
		}else{
			if (x >= PontoDeDestino){

			x = PontoOriginal;
			transform.position = new Vector3 (x, transform.position.y, transform.position.z);
		}
		}
		


	}
}
}