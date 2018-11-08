using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CamBack : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    bool isOver = false;
    Cam cam;
    RectTransform rect;
    Transition transition;
    Image img;
    Color startColor;
    void Start()
    {
        cam = FindObjectOfType<Cam>();
        rect = transform.parent.GetComponent<RectTransform>();
        transition = FindObjectOfType<Transition>();
        img = GetComponent<Image>();
        startColor = img.color;
    }

    void Update()
    {
        if (cam.curCamPos != 0)
        {
            rect.anchoredPosition = Vector3.Lerp(rect.anchoredPosition, Vector3.zero, Time.deltaTime * 10);
            if (Input.GetButtonDown("Fire1") == true)
            {
                if (isOver == true)
                {
                    cam.curCamPos = 0;
                    FindObjectOfType<Manager>().PlayAudio(4);
                    transition.rect.anchoredPosition = Vector3.zero;
                    
                }
            }
        }
        else
        {
            rect.anchoredPosition = Vector3.Lerp(rect.anchoredPosition, new Vector3(1920, 0, 0), Time.deltaTime * 10);
        }

        if (isOver == false)
        {
            img.color = startColor;
        }
        else
        {
            img.color =  Color.yellow;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isOver = false;
    }
}
