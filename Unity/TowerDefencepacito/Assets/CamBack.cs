using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CamBack : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    bool isOver = false;
    Cam cam;
	RectTransform rect;
    void Start()
    {
        cam = FindObjectOfType<Cam>();
		rect = transform.parent.GetComponent<RectTransform>();
    }

    void Update()
    {
        if (cam.curCamPos != 0)
        {
			rect.anchoredPosition = Vector3.Lerp(rect.anchoredPosition,Vector3.zero,Time.deltaTime * 10);
            if (Input.GetButtonDown("Fire1") == true)
            {
                if (isOver == true)
                {
                    cam.curCamPos = 0;
                }
            }
        } else {
			rect.anchoredPosition = Vector3.Lerp(rect.anchoredPosition,new Vector3(1920,0,0),Time.deltaTime * 10);
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
