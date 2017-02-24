using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public string horizontal;
    public string vertical;
    public string weaponButton;
    public PartMove partMove;
    public PartWeapon weapon;

    public Rigidbody2D rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (weapon) weapon.Update(this);
    }

    void FixedUpdate()
    {
        partMove.MoveFixed(this);
    }
}
