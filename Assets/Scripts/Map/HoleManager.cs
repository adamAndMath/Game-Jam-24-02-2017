using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleManager : MonoBehaviour {
    private float StickThreshold = .4F;
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
        if (collision.gameObject.tag == "Hole")
        {
            if (Vector2.Distance(gameObject.transform.position, collision.gameObject.transform.position) < StickThreshold)
            {
                Animator anim = GetComponent<Animator>();

                if (anim == null)
                    anim = gameObject.AddComponent<Animator>();

                anim.runtimeAnimatorController = controller;
                Player player = gameObject.GetComponent<Player>();

                if (player) player.enabled = false;

                gameObject.transform.position = collision.gameObject.transform.position;
            }
        }
    }
}
