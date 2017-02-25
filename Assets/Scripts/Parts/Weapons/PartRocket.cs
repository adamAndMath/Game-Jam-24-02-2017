public class PartRocket : PartWeapon
{
    public Rocket rocketPrefab;

    public override void UpdateWeapon(Player player)
    {
        if (!player.InputWeapon) return;

        Rocket rocket = Instantiate(rocketPrefab, transform.position, transform.rotation);
        rocket.player = player;
        player.PartWeapon = null;
    }
}
