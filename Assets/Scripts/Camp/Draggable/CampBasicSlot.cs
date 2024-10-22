using UnityEngine;

public class CampBasicSlot : MonoBehaviour, IDragListener
{
    public Transform snapPoint;
    public DraggableUnit unitOnSlot;

    public Material slotEmptyMaterial;
    public Material slotFullMaterial;
    public Material slotHoverEmptyMaterial;
    public Material slotHoverFullMaterial;
    public MeshRenderer visualMeshRendere;

    private void Start()
    {
        UnityDraggingManager.Instance.OnDragStart += OnDragStart;
        UnityDraggingManager.Instance.OnDragEnd += OnDragEnd;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Draggable"))
        {
            DraggableUnit draggable = other.GetComponent<DraggableUnit>();
            if (UnityDraggingManager.Instance.IsDragging()) SetStateColor(draggable, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Draggable"))
        {
            DraggableUnit draggable = other.GetComponent<DraggableUnit>();
            if(UnityDraggingManager.Instance.IsDragging()) SetStateColor(draggable);
        }
    }

    public void SetUnitOnSlot(DraggableUnit unit)
    {
        unitOnSlot = unit;
        if(unit!=null) unit.SetCurrentSlot(this);
    }

    public bool IsSlotOccupied()
    {
        return unitOnSlot != null;
    }
    public virtual bool IsSlotUnLocked()
    {
        return true;
    }
    public DraggableUnit GetUnitOnSlot()
    {
        return unitOnSlot;
    }

    public void SetStateColor(DraggableUnit unit, bool inRange = false)
    {
        if (IsSlotUnLocked())
        {
            
            if (inRange)
            {
                if (unitOnSlot != null && unitOnSlot != unit)
                {
                    //naje�d�asz innym unitem i co� innego tu jest
                    visualMeshRendere.material = slotHoverFullMaterial;
                }
                else
                {
                    //naje�d�asz unitem a jest pusto
                    visualMeshRendere.material = slotHoverEmptyMaterial;
                }
            }
            else
            {
                if (unit != null)
                {
                    //podniesiony unit w oddali
                    visualMeshRendere.material = slotFullMaterial;
                }
                else
                {
                    //zako�czenie nic, nie jest przenoszone
                    visualMeshRendere.material = slotEmptyMaterial;
                }
            }

        }
        else
        {
            visualMeshRendere.material = slotHoverFullMaterial;
        }
    }

    public void OnDragStart(DraggableUnit unit)
    {
        SetStateColor(unit);
    }

    public void OnDragEnd(DraggableUnit unit)
    {
        SetStateColor(null);
    }
}
