﻿using UnityEngine;

public class PartWheel : PartMove
{
    public float rotationSpeed;

    public override void MoveFixed(Player player)
    {
        Vector2 movement = player.InputMove;
        player.rigid.drag = drag;

        if (movement.sqrMagnitude < 0.01F) return;

        UpdateRotation(player, movement);

        player.rigid.AddForce(acceleration * player.transform.up * movement.magnitude, ForceMode2D.Force);
    }

    private void UpdateRotation(Player player, Vector2 movement)
    {
        float angle = Mathf.Rad2Deg*Mathf.Atan2(-movement.x, movement.y);
        float rot = player.transform.rotation.eulerAngles.z;

        float delta = angle - rot;
        if (delta < -180) delta += 360;
        if (delta > 180) delta -= 360;

        if (Mathf.Abs(delta) > rotationSpeed*Time.fixedDeltaTime)
            rot += Mathf.Sign(delta)*rotationSpeed*Time.fixedDeltaTime;
        else
            rot = angle;

        player.transform.rotation = Quaternion.Euler(0, 0, rot);
    }
}
