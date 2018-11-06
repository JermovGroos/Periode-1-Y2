using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NewWaveActivator : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    Manager manager;
    WaveManager waveManager;
    bool isOver = false;
    RectTransform rect;
    WaveIndicator waveIndicator;

    void Start()
    {
        manager = FindObjectOfType<Manager>();
        waveManager = FindObjectOfType<WaveManager>();
        waveIndicator = FindObjectOfType<WaveIndicator>();
        rect = transform.GetComponent<RectTransform>();
        rect.rotation = Quaternion.Euler(0, 0, -90);
    }

    void Update()
    {
        if (waveManager.waveInProgress == false)
        {
            // rect.eulerAngles = Vector3.Lerp(rect.eulerAngles, new Vector3(rect.eulerAngles.x, rect.eulerAngles.y, 0), Time.deltaTime * 36);
            rect.rotation = Quaternion.Lerp(rect.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * 10);
            if (isOver == true)
            {
                if (Input.GetButtonDown("Fire1") == true)
                {
                    if (manager.SetMouseState(Manager.MouseState.Used) == true)
                    {
                        manager.PlayAudio(14);
                        waveIndicator.NewWave();
                        waveManager.NextWavey();
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
