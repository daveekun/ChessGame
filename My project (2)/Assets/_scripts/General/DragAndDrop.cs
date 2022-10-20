using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform rt;
    private CanvasGroup cg;
    [SerializeField] GameObject Description;
    void Awake()
    {
        canvas = GameObject.FindObjectOfType<Canvas>();
        rt = GetComponent<RectTransform>();
        cg = GetComponent<CanvasGroup>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Shit on");
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Description.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Description.SetActive(false);
    }
    public void OnDrag(PointerEventData eventData)
    {
        rt.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        cg.alpha = .6f;
        cg.blocksRaycasts = false;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        cg.alpha = 1f;
        cg.blocksRaycasts = true;
    }
}
