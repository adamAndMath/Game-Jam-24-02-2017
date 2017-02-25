using UnityEngine;

public class Explosion : MonoBehaviour
{
    public AudioSource ExplosionSound;
    public float damage;
    public float explotionRadius;
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
	    }

	    Destroy(gameObject, time);
	}
}
