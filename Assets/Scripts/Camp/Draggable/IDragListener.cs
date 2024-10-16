using UnityEngine;

public interface IDragListener
{
    void OnDragStart(DraggableUnit unit);  // Wywo�ywana przy rozpocz�ciu przeci�gania
    void OnDragEnd(DraggableUnit unit);    // Wywo�ywana przy zako�czeniu przeci�gania
}
