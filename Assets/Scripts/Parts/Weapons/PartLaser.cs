using UnityEngine;

public class PartLaser : PartWeapon
{
    public float damage = 0.1F;
    public float width = 0.5F;
    public float maxLength = 20;
    public GameObject laser;

    public override void UpdateWeapon(Player player)
    {
        bool button = player.InputWeapon;

        if (button)
        {
            RaycastHit2D hit = Physics2D.CircleCast(laser.transform.position, width, transform.up, maxLength);

            laser.transform.localScale = new Vector3(1, hit ? hit.distance + width : maxLength, 1);

            if (hit)
            {
                Player other = hit.collider.GetComponent<Player>();
                if (other) other.Damage(damage);
            }
        }

        laser.SetActive(button);
        
    }
}
