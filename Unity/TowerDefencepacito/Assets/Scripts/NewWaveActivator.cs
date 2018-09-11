using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NewWaveActivator : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    Manager manager;
    bool isOver = false;
    RectTransform rect;

    void Start()
    {
        manager = FindObjectOfType<Manager>();
        rect = transform.GetComponent<RectTransform>();
        rect.rotation = Quaternion.Euler(0, 0, -90);
    }

    void Update()
    {
        if (manager.inBetweenWaves == true)
        {
            // rect.eulerAngles = Vector3.Lerp(rect.eulerAngles, new Vector3(rect.eulerAngles.x, rect.eulerAngles.y, 0), Time.deltaTime * 36);
            rect.rotation = Quaternion.Lerp(rect.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * 10);
            if (isOver == true)
            {
                if (Input.GetButtonDown("Fire1") == true)
                {
                    if (manager.SetMouseState(Manager.MouseState.Used) == true)
                    {
                        manager.inBetweenWaves = false;
                        manager.NewWave();
                    }
                }
            }
        }
        else
        {
            rect.rotation = Quaternion.Lerp(rect.rotation, Quaternion.Euler(0, 0, -90), Time.deltaTime * 10);
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
