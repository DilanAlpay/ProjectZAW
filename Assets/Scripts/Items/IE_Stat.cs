[System.Serializable]
public class IE_Stat : ItemEffect
{
    public Stats stats;

    public override void Use(Item i, Player p)
    {
        base.Use(i, p);

        StatBoost boost = player.gameObject.AddComponent<StatBoost>();
        boost.Init(player, this, item.duration);    
    }
}
