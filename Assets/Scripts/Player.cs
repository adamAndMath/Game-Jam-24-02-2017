using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public int id;
    public float maxHp;
    [Space]
    public string horizontal;
    public string vertical;
    public string weaponButton;
    [Space]
    public PartMove partMove;
    public PartWeapon weapon;
    public float hp;

    [NonSerialized]
    public Rigidbody2D rigid;

    public Vector2 InputMove
    {
        get
        {
            return new Vector2(Input.GetAxisRaw(id + horizontal), Input.GetAxisRaw(id + vertical));
        }
    }

    public bool InputWeapon { get { return Input.GetButton(id + weaponButton); } }

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        hp = maxHp;
    }

    void Update()
    {
        if (weapon) weapon.UpdateWeapon(this);
    }

    void FixedUpdate()
    {
        partMove.MoveFixed(this);
    }

    public void Damage(float damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
