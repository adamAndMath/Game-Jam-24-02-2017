using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public string horizontal;
    public string vertical;
    public PartMove partMove;

    private Rigidbody2D rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rigid.drag = partMove.drag;
        rigid.AddForce(partMove.acceleration * new Vector2(Input.GetAxis(horizontal), Input.GetAxis(vertical)), ForceMode2D.Force);
    }
}
