using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launchers : MonoBehaviour {
    public float PushForce;
    public Vector2 direction;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(PushForce * direction, ForceMode2D.Impulse);
    }
}
