using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Player player;
    public RectTransform back;
    public RectTransform front;
    public float scale;

    void Update()
    {
        back.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, scale * player.maxHp);
        front.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, scale * player.hp);
    }
}
