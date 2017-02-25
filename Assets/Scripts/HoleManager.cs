using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleManager : MonoBehaviour {
    private float StickThreshold = 1.2F;
    public RuntimeAnimatorController controller;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Why is this happening?");
        if (collision.gameObject.tag == "Hole")
        {
            Debug.Log(Vector2.Distance(gameObject.transform.position, collision.gameObject.transform.position));
            Debug.Log("Why is this happening?");
            if (Vector2.Distance(gameObject.transform.position, collision.gameObject.transform.position) < StickThreshold)
            {
                Animator anim = GetComponent<Animator>();

                if (anim == null)
                    anim = gameObject.AddComponent<Animator>();

                anim.runtimeAnimatorController = controller;
                gameObject.GetComponent<Player>().enabled = false;
                gameObject.transform.position = collision.gameObject.transform.position;
            }
        }
    }
}
