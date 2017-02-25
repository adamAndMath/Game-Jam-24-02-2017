using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour, IDamageable
{
    public int id;
    public float maxHp;
    public float maxEnergy;
    public float rotationSpeed = 360;
    [Space]
    public string horizontal;
    public string vertical;
    public string rotateHorizontal;
    public string rotateVertical;
    public string weaponButton;
    public string pickUp;
    [Space]
    [SerializeField]
    private PartMove partMove;
    [SerializeField]
    private PartWeapon weapon;

    public LayerMask weaponIgnore;
    public float hp;
    public float energy;

    [System.NonSerialized]
    public Rigidbody2D rigid;

    public CircleCollider2D col;

    public PartMove PartMove
    {
        get { return partMove; }
        set
        {
            if (partMove) Destroy(partMove);
            partMove = value;
            if (value) value.transform.SetParent(transform, false);
        }
    }

    public PartWeapon PartWeapon
    {
        get { return weapon; }
        set
        {
            if (weapon) Destroy(weapon.gameObject);
            weapon = value;
            if (value) value.transform.SetParent(transform, false);
        }
    }

    public Vector2 InputMove
    {
        get
        {
            return new Vector2(Input.GetAxisRaw(id + horizontal), Input.GetAxisRaw(id + vertical));
        }
    }

    public Vector2 InputRotate
    {
        get
        {
            return new Vector2(Input.GetAxisRaw(id + rotateHorizontal), Input.GetAxisRaw(id + rotateVertical));
        }
    }

    public bool InputWeapon { get { return Input.GetButton(id + weaponButton); } }
    public bool InputPickUp { get { return Input.GetButtonDown(id + pickUp); } }

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
        hp = maxHp;
        energy = maxEnergy;
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

        if (weapon)
        {
            RotationWeapon(InputRotate);
            weapon.UpdateWeapon(this);
        }
    }

    private void RotationWeapon(Vector2 movement)
    {
        movement = transform.worldToLocalMatrix*movement;
        float angle = Mathf.Rad2Deg * Mathf.Atan2(-movement.x, movement.y);
        float rot = weapon.transform.localRotation.eulerAngles.z;

        float delta = angle - rot;
        if (delta < -180) delta += 360;
        if (delta > 180) delta -= 360;

        if (Mathf.Abs(delta) > rotationSpeed * Time.fixedDeltaTime)
            rot += Mathf.Sign(delta) * rotationSpeed * Time.fixedDeltaTime;
        else
            rot = angle;

        weapon.transform.localRotation = Quaternion.Euler(0, 0, rot);
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
