using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartMine : MonoBehaviour {
    public float ArmingTime;
    private float ArmingTimeLeft;
    private bool ReadyToExplode;
    private Animator animator;

    public Player player;
    public float ExplosionRadius;
    public Explosion explosion;
    


	// Use this for initialization
	void Start ()
    {
        ArmingTimeLeft = ArmingTime;
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        ArmingTimeLeft = ArmingTimeLeft - Time.deltaTime;
        if (ArmingTimeLeft <= 0)
        {
            ReadyToExplode = true;
            animator.SetBool("Armed", true);
        }

	}
    private void OnTriggerEnter2D(Collider2D collider)
    {
        player = collider.gameObject.GetComponent<Player>();

       if (player != null && ReadyToExplode)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
