public class Stats {

    public Stats() {
        Reset();
    }

    public int Sauerstoff { get; set; }
    public int Leben      { get; set; }
    public int Gemes      { get; set; }
    public int Jumps      { get; set; }

    public static readonly Stats Instance = new Stats();

    public void Reset() {
        Sauerstoff = 100;
        Leben = 3;
        Gemes = 0;
        Jumps = 1;
    }
}