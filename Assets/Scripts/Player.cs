using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public int id;
    public string horizontal;
    public string vertical;
    public string weaponButton;
    public PartMove partMove;
    public PartWeapon weapon;

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
