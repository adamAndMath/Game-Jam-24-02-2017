using UnityEngine;

public class PartMove : PartBase
{
    public float drag;
    public float acceleration;

    public virtual void MoveFixed(Player player)
    {
        Vector2 movement = player.InputMove;
        player.rigid.drag = drag;

        if (movement.sqrMagnitude < 0.01F) return;

        player.rigid.AddForce(acceleration * movement, ForceMode2D.Force);

        player.transform.rotation = Quaternion.LookRotation(Vector3.forward, movement);
    }
}
