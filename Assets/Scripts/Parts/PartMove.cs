using UnityEngine;

public class PartMove : MonoBehaviour
{
    public float drag;
    public float acceleration;

    public virtual void MoveFixed(Player player)
    {
        Vector2 movement = new Vector2(Input.GetAxisRaw(player.horizontal), Input.GetAxisRaw(player.vertical));

        if (movement.sqrMagnitude < 0.1F) return;

        player.rigid.drag = drag;
        player.rigid.AddForce(acceleration * movement, ForceMode2D.Force);

        player.transform.rotation = Quaternion.LookRotation(Vector3.forward, movement);
    }
}
