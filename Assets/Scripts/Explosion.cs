using UnityEngine;

public class Explosion : MonoBehaviour
{
    public AudioSource ExplosionSound;
    public float damage;
    public float explotionRadius;
    public float force;
    public float time;

	void Start ()
	{
        ExplosionSound.Play();

	    foreach (var col in Physics2D.OverlapCircleAll(transform.position, explotionRadius))
	    {
	        IDamageable hit = col.GetComponent<IDamageable>();

	        if (hit != null)
	        {
	            hit.Damage(damage);
	        }

	        Rigidbody2D rigid = col.GetComponent<Rigidbody2D>();

	        if (rigid)
	        {
	            rigid.AddForceAtPosition((col.transform.position - transform.position).normalized * force, transform.position, ForceMode2D.Impulse);
	        }
	    }

	    Destroy(gameObject, time);
	}
}
