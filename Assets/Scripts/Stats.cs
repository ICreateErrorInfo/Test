public class Stats {

    public Stats() {
        Reset();
    }

    public int   Sauerstoff    { get; set; }
    public int   MaxSauerstoff { get; set; }
    public int   Leben         { get; set; }
    public int   Gemes         { get; set; }
    public int   Jumps         { get; set; }
    public float MaxGameTime   { get; set; }
    public float GameTime      { get; set; }

    public float PercentageTimeUsed => GameTime / MaxGameTime;

    public static readonly Stats Instance = new Stats();

    public void Reset() {

        MaxSauerstoff = 100;
        Sauerstoff    = MaxSauerstoff;

        Leben       = 3;
        Gemes       = 0;
        Jumps       = 1;
        MaxGameTime = 3 * 60;
        GameTime    = 0;
    }

}