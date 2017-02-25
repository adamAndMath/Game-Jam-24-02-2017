using UnityEngine;

public class PartLaser : PartWeapon
{
    public float damage = 0.1F;
    public float width = 0.5F;
    public float maxLength = 20;
    public GameObject laser;
    private AudioSource audio;
    private bool audioIsOn;

    public void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public override void UpdateWeapon(Player player)
    {
        bool button = player.InputWeapon;

        laser.SetActive(button);

        if (button)
        {
            if (!audioIsOn)
            {
                audio.Play();
                audioIsOn = true;
            }

            float distance = CastLaser(player);

            laser.transform.localScale = new Vector3(1, distance, 1);
        }
        else if (!button && audioIsOn)
        {
            audio.Stop();
            audioIsOn = false;
        }
    }

    private float CastLaser(Player player)
    {
        foreach (var hit in Physics2D.CircleCastAll(laser.transform.position, width, transform.up, maxLength))
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Pick Up"))
                continue;

            IDamageable other = hit.collider.GetComponent<IDamageable>();

            if (other == null)
                return hit.distance + width;

            if (other != player)
            {
                other.Damage(damage * Time.deltaTime);
                return hit.distance + width;
            }
        }

        return maxLength;
    }
}
