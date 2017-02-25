using UnityEngine;

public class KillAble : MonoBehaviour, IDamageable
{
    public float hp;
    public void Damage(float damage)
    {
        hp -= damage;
        
        if (hp < 0) Destroy(gameObject);
    }
}
