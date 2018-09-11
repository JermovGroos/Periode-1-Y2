using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScrollUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    bool isOver = false;
    RectTransform rect;
    bool holding = false;
	float scrollPercent = 0;
	float scrollCamStartY;
	public Transform scrollCam;
    Manager manager;
    void Start()
    {
        rect = transform.GetComponent<RectTransform>();
		scrollCamStartY = scrollCam.position.y;
        SetSliderPos();
        manager = FindObjectOfType<Manager>();
    }

    void Update()
    {
        if (holding == true)
        {
            SetSliderPos();
        }
        if (Input.GetButtonDown("Fire1") == true)
        {
            if (isOver == true)
            {
                if(manager.SetMouseState(Manager.MouseState.Used)){
                    holding = true;
                }
            }
        }
        if (Input.GetButtonUp("Fire1"))
        {
            holding = false;
        }
		scrollCam.position = new Vector3(scrollCam.position.x,scrollCamStartY + (scrollPercent * 12),scrollCam.position.z);
    }

    void SetSliderPos()
    {
        float yPos = Input.mousePosition.y - 550;
        yPos = Mathf.Clamp(yPos, -121, 121) + (scrollCamStartY - 75);
		scrollPercent = (yPos + 121) / 242;
        rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, yPos);
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        isOver = true;
        manager.SetMouseState(Manager.MouseState.OverUI);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isOver = false;
        manager.SetMouseState(Manager.MouseState.Unused);
    }
}
