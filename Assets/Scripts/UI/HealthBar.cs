using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Player player;
    public RectTransform back;
    public RectTransform front;
    public Vector2 offset;
    public float scale;

    void Update()
    {
        back.anchoredPosition = offset + (Vector2)Camera.main.WorldToScreenPoint(player.transform.position);
        back.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, scale * player.maxHp);
        front.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, scale * player.hp);
    }
}
