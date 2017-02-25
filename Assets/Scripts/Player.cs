using System.Linq;
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
    public string pickUp;
    public Transform weaponMount;
    [Space]
    [SerializeField]
    private PartMove partMove;
    [SerializeField]
    private PartWeapon weapon;

    public float hp;

    [System.NonSerialized]
    public Rigidbody2D rigid;

    public CircleCollider2D col;

    public PartMove PartMove
    {
        get { return partMove; }
        set
        {
            Destroy(partMove);
            partMove = value;
            value.transform.SetParent(transform, false);
        }
    }

    public PartWeapon PartWeapon
    {
        get { return weapon; }
        set
        {
            Destroy(weapon);
            weapon = value;
            value.transform.SetParent(weaponMount, false);
        }
    }

    public Vector2 InputMove
    {
        get
        {
            return new Vector2(Input.GetAxisRaw(id + horizontal), Input.GetAxisRaw(id + vertical));
        }
    }

    public bool InputWeapon { get { return Input.GetButton(id + weaponButton); } }
    public bool InputPickUp { get { return Input.GetButtonDown(id + pickUp); } }

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
        hp = maxHp;
    }

    void Update()
    {
        if (InputPickUp)
        {
            PickUpPart[] pickUps = Physics2D.OverlapCircleAll((Vector2) transform.position + col.offset, col.radius)
                .Select(c => c.GetComponent<PickUpPart>())
                .Where(pUp => pUp != null)
                .ToArray();

            if (pickUps.Length > 0)
            {
                pickUps[Random.Range(0, pickUps.Length)].PickUp(this);
            }
        }

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
