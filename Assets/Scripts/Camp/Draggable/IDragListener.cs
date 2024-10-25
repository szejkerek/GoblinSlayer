using UnityEngine;

public interface IDragListener
{
    void OnDragStart(DraggableUnit unit);  // Wywoływana przy rozpoczęciu przeciągania
    void OnDragEnd(DraggableUnit unit);    // Wywoływana przy zakończeniu przeciągania
}
