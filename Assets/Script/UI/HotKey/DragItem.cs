using UnityEngine;
using UnityEngine.EventSystems;
public class DragItem : NewMonobehavior, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] protected Transform realParent;
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        this.realParent = transform.parent;
        transform.parent = UIHotKeyController._instance.transform;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");  
        Vector3 mousePos = InputManager.Instance.MouseWorldPos;
        mousePos.z = 0;
        transform.position = mousePos;  
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        transform.parent = this.realParent; 
    }
}