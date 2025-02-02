using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;
    [HideInInspector] public Transform parentAfterDrag;
    public void OnBeginDrag(PointerEventData eventData)
    {
        // throw new System.NotImplementedException();
        Debug.Log("OnBeginDrag");
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        //set at the very top
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // throw new System.NotImplementedException();
        Debug.Log("OnDrag");
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // throw new System.NotImplementedException();
        Debug.Log("OnEndDrag");
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
    }

    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    // void Update()
    // {
        
    // }
}
