using System;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public BarType barType;
    public Player player;
    public RectTransform back;
    public RectTransform front;
    public Vector2 offset;
    public float scale;

    public enum BarType { Hp, Energy }

    private float Max
    {
        get
        {
            switch (barType)
            {
                case BarType.Hp: return player.maxHp;
                case BarType.Energy: return player.maxEnergy;
            }

            throw new Exception();
        }
    }

    private float Value
    {
        get
        {
            switch (barType)
            {
                case BarType.Hp: return player.hp;
                case BarType.Energy: return player.energy;
            }

            throw new Exception();
        }
    }

    void Update()
    {
        back.anchoredPosition = offset + (Vector2)Camera.main.WorldToScreenPoint(player.transform.position);
        back.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, scale * Max);
        front.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, scale * Value);
    }
}
