using UnityEngine;

public class PartRoundSaw : PartWeapon
{
    public float damage;
    public float energy = 0.1F;
    public CircleCollider2D mesh;
    private Animator animator;
    private ParticleSystem particle;

    void Awake()
    {
        animator = GetComponent<Animator>();
        particle = GetComponentInChildren<ParticleSystem>();
    }

    public override void UpdateWeapon(Player player)
    {
        bool button = player.InputWeapon && player.energy > 0;

        mesh.gameObject.SetActive(button);
        animator.SetBool("WeaponActive", button);

        if (button)
        {
            player.energy = Mathf.Max(0, player.energy - energy * Time.deltaTime);
            Collider2D[] hits = Physics2D.OverlapCircleAll((Vector2) mesh.transform.position + mesh.offset, mesh.radius);

            foreach (Collider2D hit in hits)
            {
                IDamageable damageable = hit.GetComponent<IDamageable>();

                if (damageable != null && damageable != player)
                {
                    damageable.Damage(damage * Time.deltaTime);
                    particle.Play();
                }
            }
        }
        else
        {
            particle.Stop();
        }
    }
}
