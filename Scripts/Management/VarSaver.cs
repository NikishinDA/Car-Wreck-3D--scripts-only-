using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VarSaver : MonoBehaviour
{
    public static float LevelLength { get; set; }
public static float CurrentPlayerProgress { get; set; }
    public static int MoneyCollected { get; set; } = 0;
public static int StarsNum{ get; set; } = 1;
    public static float Multiplier { get; set; } = 1f;
    public static int SectionNumber { get; set; }
    public static int AmbienceNumber { get; set; }
    public static bool Bin { get; set; }
}
