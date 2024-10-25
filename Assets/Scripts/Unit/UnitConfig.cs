using UnityEngine;

[CreateAssetMenu(fileName = "UnitConfig", menuName = "Scriptable Objects/UnitConfig")]
public class UnitConfig : ScriptableObject
{
    
    [Header("Walk")]
    public float height = 1.5f;
    public float walkSpeed = 5f;
    [Header("Attack")]
    public float range = 5f;
    public int damage = 5;
    public float cooldown = 2f;
    [Header("Health")]
    public float health = 100f;
    [Header("NavMesh")]
    [Tooltip("Time in seconds to consider being stuck")]
    public float stuckThreshold = 2f; 

    [Header("Price")]
    public int price = 5;
    [Header("UnlockTime")]
    public int unlockStage = 1;
    public int unlockRound = 1;
}
