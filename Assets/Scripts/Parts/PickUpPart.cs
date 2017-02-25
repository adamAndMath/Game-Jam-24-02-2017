using System;
using UnityEngine;

public class PickUpPart : MonoBehaviour
{
    public PartBase part;

    public void PickUp(Player player)
    {
        if (part is PartMove)
            Instantiate(player.PartMove.pickUp, transform.position, player.transform.rotation);
        else if (part is PartWeapon) {
            if (player.PartWeapon) Instantiate(player.PartWeapon.pickUp, transform.position, player.transform.rotation);
        } else throw new Exception();

        if (part is PartMove)
            player.PartMove = Instantiate((PartMove) part);
        else if (part is PartWeapon)
            player.PartWeapon = Instantiate((PartWeapon) part);
        else throw new Exception();

        Destroy(gameObject);
    }
}
