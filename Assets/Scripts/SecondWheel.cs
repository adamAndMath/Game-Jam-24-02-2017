using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondWheel : MonoBehaviour {

    private Animator animator;
    private Animator myAnimator;

	// Use this for initialization
	void Start ()
    {
        animator = gameObject.GetComponentInParent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (animator.GetBool("IsMoving") == true)
        {
            
        }
	}
}
