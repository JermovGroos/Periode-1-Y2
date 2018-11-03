using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    bool isOver = false;
    RectTransform rect;
    bool holding = false;
    float scrollPercent = 0;
    float scrollCamStartY;
    public Transform scrollCam;
    Manager manager;
    float startY;
    Image img;
    Color startColor;
    void Start()
    {
        manager = FindObjectOfType<Manager>();
        rect = transform.GetComponent<RectTransform>();
        scrollCamStartY = scrollCam.position.y;
        startY = rect.anchoredPosition.y - (1080 / 2);
        img = GetComponent<Image>();
        startColor = img.color;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") == true)
        {
            if (isOver == true)
            {
                img.color = Color.Lerp(img.color, Color.yellow, Time.deltaTime * 5);
                if (manager.SetMouseState(Manager.MouseState.Used))
                {
                    if (holding == false)
                    {
                        manager.PlayAudio(10);
                        holding = true;
                    }
                }
            }
        }
        if (Input.GetButtonUp("Fire1"))
        {
            holding = false;
        }
        if (holding == true)
        {
            SetSliderPos(Input.mousePosition.y);
            img.color = Color.white;
        }
        else
        {
            // SetSliderPos(0);
        }
        scrollCam.position = new Vector3(scrollCam.position.x, scrollCamStartY + (scrollPercent * 12), scrollCam.position.z);


        if (isOver == true)
        {
            img.color = Color.Lerp(img.color, Color.yellow, Time.deltaTime * 5);
        }
        else
        {
            img.color = Color.Lerp(img.color, startColor, Time.deltaTime * 5);
        }
    }

    void SetSliderPos(float yPos)
    {
        yPos = Mathf.Clamp(yPos, Screen.height / 3, (Screen.height / 2) + (Screen.height / 6)) + startY;
        scrollPercent = (rect.anchoredPosition.y - 484) / 242;
        rect.localPosition = new Vector2(rect.localPosition.x, yPos);
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        isOver = true;
        //manager.SetMouseState(Manager.MouseState.OverUI);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isOver = false;
        // manager.SetMouseState(Manager.MouseState.Unused);
    }
}
