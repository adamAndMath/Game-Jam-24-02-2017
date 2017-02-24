using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    public float acceleration;
    public string horizontal;
    public string vertical;

    private Rigidbody2D rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rigid.AddForce(acceleration*new Vector2(Input.GetAxis(horizontal), Input.GetAxis(vertical)), ForceMode2D.Force);
    }
}
