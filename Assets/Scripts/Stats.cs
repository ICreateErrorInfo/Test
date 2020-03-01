using UnityEngine;

public class Stats {

    public Stats() {
        Reset();
    }

    public static int    DefaultMaxSauerstoff => 100;
    public static int    DefaultSauerstoff    => DefaultMaxSauerstoff;
    public static int    DefaultGemes         => 0;
    public static int    DefaultJumps         => 1;
    public static float  DefaultMaxGameTime   => 3 * 60;
    public static float  DefaultGameTime      => 0;
    public static int    DefaultHealth        => 100;
    public static string DefaultLevel         => SceneNames.Level1;

    public int     Sauerstoff    { get; set; }
    public int     MaxSauerstoff { get; set; }
    public int     Gemes         { get; set; }
    public int     Jumps         { get; set; }
    public float   MaxGameTime   { get; set; }
    public float   GameTime      { get; set; }
    public int     Health        { get; set; }
    public Vector3 StartPos      { get; set; }
    public string  Level         { get; set; }

    public float PercentageTimeUsed => GameTime / MaxGameTime;

    public static readonly Stats Instance = new Stats();

    public void Reset() {

        MaxSauerstoff = DefaultMaxSauerstoff;
        Sauerstoff    = DefaultSauerstoff;
        Gemes         = DefaultGemes;
        Jumps         = DefaultJumps;
        MaxGameTime   = DefaultMaxGameTime;
        GameTime      = DefaultGameTime;
        Health        = DefaultHealth;
        Level         = DefaultLevel;

    }

    public void Load() {
        Health     = PlayerPrefs.GetInt(nameof(Health),     DefaultHealth);
        Sauerstoff = PlayerPrefs.GetInt(nameof(Sauerstoff), DefaultSauerstoff);
        Level      = PlayerPrefs.GetString(nameof(Level), DefaultLevel);
        Gemes      = PlayerPrefs.GetInt(nameof(Gemes), DefaultGemes);
        Jumps      = PlayerPrefs.GetInt(nameof(Jumps), DefaultJumps);
        GameTime   = PlayerPrefs.GetFloat(nameof(GameTime), DefaultGameTime);

    }

    public void Save() {
        PlayerPrefs.SetInt(nameof(Health),     Health);
        PlayerPrefs.SetInt(nameof(Sauerstoff), Sauerstoff);
        PlayerPrefs.SetString(nameof(Level), Level);
        PlayerPrefs.SetInt(nameof(Gemes), Gemes);
        PlayerPrefs.SetInt(nameof(Jumps), Jumps);
        PlayerPrefs.SetFloat(nameof(GameTime), GameTime);
        PlayerPrefs.Save();
    }

}