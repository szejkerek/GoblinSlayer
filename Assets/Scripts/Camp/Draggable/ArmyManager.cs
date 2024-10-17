using System.Collections.Generic;
using UnityEngine;

public class ArmyManager : MonoBehaviour
{
    public static ArmyManager Instance;

    public List<CampArmySlot> armyList = new List<CampArmySlot>();
    private void Awake()
    {
        // Upewniamy si�, �e mamy tylko jedn� instancj� UnityDraggingManager
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
