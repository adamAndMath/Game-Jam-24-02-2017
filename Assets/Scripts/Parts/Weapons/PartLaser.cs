using UnityEngine;

public class PartLaser : PartWeapon
{
    public float damage = 0.1F;
    public float energy = 0.1F;
    public float width = 0.5F;
    public float maxLength = 20;
    public GameObject laser;
    private AudioSource audio;

    public void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    public override void UpdateWeapon(Player player)
    {
        bool button = player.InputWeapon && player.energy > 0;

        laser.SetActive(button);

        if (button)
        {
            if (!audio.isPlaying)
                audio.Play();

            float distance = CastLaser(player);

            player.energy = Mathf.Max(0, player.energy - energy*Time.deltaTime);
            laser.transform.localScale = new Vector3(1, distance, 1);
        }
        else if (audio.isPlaying)
            audio.Stop();
    }

    private float CastLaser(Player player)
    {
        foreach (var hit in Physics2D.CircleCastAll(laser.transform.position, width, transform.up, maxLength))
        {
            if (((1 << hit.collider.gameObject.layer) & player.weaponIgnore) != 0)
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
