using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class HealthDisplayTool
{
    // Add a menu item to the Tools menu to deal 10 damage
    [MenuItem("Tools/Deal 10 Damage")]
    public static void Deal10DamageFromMenu()
    {
        // Find the first HealthDisplay component in the scene
        IEnumerable<UnitHealth> units = Object.FindObjectsByType<UnitHealth>(FindObjectsSortMode.None);

        if (units != null)
        {
            foreach (var unitHealth in units)
            {
                unitHealth.DealDamage(10f);
            }
        }
        else
        {
            Debug.LogWarning("No HealthDisplay component found in the scene!");
        }
    }
}