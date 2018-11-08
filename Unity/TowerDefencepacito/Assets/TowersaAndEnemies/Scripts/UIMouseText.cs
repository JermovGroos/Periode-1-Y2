using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class UIMouseText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    Manager manager;

    void Start()
    {
        manager = FindObjectOfType<Manager>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        manager.SetMouseState(Manager.MouseState.OverUI);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        manager.SetMouseState(Manager.MouseState.Unused);
		//manager.mouseState = Manager.MouseState.Unused;
    }
}
