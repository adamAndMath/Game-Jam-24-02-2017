using UnityEngine;

public class PartRoundSaw : PartWeapon
{
    public float damage;
    public CircleCollider2D mesh;
    private Animator animator;

    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    public override void UpdateWeapon(Player player)
    {
        bool button = player.InputWeapon;
        
        mesh.gameObject.SetActive(button);

        animator.SetBool("WeaponActive", true);
       
        if (button)
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll((Vector2) mesh.transform.position + mesh.offset, mesh.radius);

            foreach (Collider2D hit in hits)
            {
                Player plr = hit.GetComponent<Player>();

                if (plr && plr != player)
                    plr.Damage(damage*Time.deltaTime);
            }
        }
    }
}
