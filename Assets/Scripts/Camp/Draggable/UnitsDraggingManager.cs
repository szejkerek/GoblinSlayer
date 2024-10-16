using System;
using UnityEngine;

public class UnityDraggingManager : MonoBehaviour
{
    public static UnityDraggingManager Instance;  // Singleton, aby mie� globalny dost�p

  
    public event Action<DraggableUnit> OnDragStart;
    public event Action<DraggableUnit> OnDragEnd;

    private DraggableUnit currentDraggedUnit;  // Obiekt, kt�ry jest aktualnie przeci�gany

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

    // Sprawdza, czy jaki� obiekt jest aktualnie przeci�gany
    public bool IsDragging()
    {
        return currentDraggedUnit != null;
    }

    // Zaczyna przeci�ganie obiektu
    public void StartDragging(DraggableUnit draggable)
    {
        if (!IsDragging())
        {
            currentDraggedUnit = draggable;
            OnDragStart?.Invoke(draggable);
        }
    }

    // Ko�czy przeci�ganie obiektu
    public void StopDragging()
    {
        if (IsDragging())
        {
            OnDragEnd?.Invoke(currentDraggedUnit);
            currentDraggedUnit = null;
        }
    }

    // Zwraca obiekt, kt�ry jest przeci�gany
    public DraggableUnit GetCurrentDraggedObject()
    {
        return currentDraggedUnit;
    }
}
