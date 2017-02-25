using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioStarterMoving : StateMachineBehaviour {

	 
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<AudioSource>().Play();
	}


	
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<AudioSource>().Stop();
    }


}
