using UnityEngine;

public class PartLaser : PartWeapon
{
    public float width = 0.5F;
    public float maxLength = 20;
    public GameObject laser;

    public override void Update(Player player)
    {
        bool button = Input.GetButton(player.weaponButton);

        if (button)
        {
            RaycastHit2D hit = Physics2D.CircleCast(laser.transform.position, width, transform.up, maxLength);

            laser.transform.localScale = new Vector3(1, hit ? hit.distance + width : maxLength, 1);
        }

        laser.SetActive(button);
        
    }
}
