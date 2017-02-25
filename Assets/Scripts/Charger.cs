using System;
using UnityEngine;

public class Charger : MonoBehaviour
{
    public BarType barType;
    public float speed;
    public Rect rect;

    public enum BarType { Hp, Energy }

    void Update()
    {
        Vector2 pos = transform.position;
        foreach (Collider2D col in Physics2D.OverlapAreaAll(pos + rect.position, pos + rect.position + rect.size))
        {
            Player player = col.GetComponent<Player>();
            if (player)
            {
                switch (barType)
                {
                    case BarType.Hp: player.hp = Mathf.Min(player.maxHp, player.hp + speed*Time.deltaTime);
                        break;
                    case BarType.Energy: player.energy = Mathf.Min(player.maxEnergy, player.energy + speed*Time.deltaTime);
                        break;
                    default:
                        throw new Exception();
                }
            }
        }
    }
}
