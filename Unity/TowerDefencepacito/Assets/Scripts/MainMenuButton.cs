using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.PostProcessing;

public class MainMenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    bool isOver = false;
    public enum Ev
    {
        StartGame,
        Options,
        QuitGame,
        FulScreen,
        Bloom,
        SSR,
        MotionBlur,
        AntiAliasing,
        Volume,
        SetResolution
    }
    public Ev clickEvent = Ev.StartGame;

    public int nextLevel = 0;
    public GameObject otherMenuParent;
    public GameObject menuParent;
    bool onOff = true;
    AutoRotate rend;
	Image rendImage;
    public PostProcessingBehaviour pp;
    public Vector2 newRes = new Vector2(1920, 1080);
    bool fullScreen = true;
	List<MainMenuButton> others = new List<MainMenuButton>();
	public Transform selecter;


    void Start()
    {
		others.Clear();
		others.AddRange(FindObjectsOfType<MainMenuButton>());
        if (transform.GetComponent<Image>() != null)
        {
            rend = transform.GetComponent<AutoRotate>();
			rendImage = transform.GetComponent<Image>();
        }
        fullScreen = Screen.fullScreen;
        if (clickEvent == Ev.FulScreen)
        {
            onOff = Screen.fullScreen;
        }
        if (clickEvent == Ev.Bloom)
        {
            onOff = pp.profile.bloom.enabled;
        }
        if (clickEvent == Ev.AntiAliasing)
        {
            onOff = pp.profile.antialiasing.enabled;
        }
        if (clickEvent == Ev.SSR)
        {
            onOff = pp.profile.screenSpaceReflection.enabled;
        }
        if (clickEvent == Ev.MotionBlur)
        {
            onOff = pp.profile.motionBlur.enabled;
        }
        if (rend != null)
        {
            if (onOff == true)
            {
                rendImage.color = Color.white;
            }
            else
            {
                rendImage.color = new Color(1,1,1,0.5f);
            }
			rend.enabled = onOff;
        }
    }

    void Update()
    {
		if(gameObject.activeSelf == false){
			isOver = false;
		}
        if (isOver == true)
        {
			if(selecter != null){
				selecter.position = transform.position;
			}
            if (Input.GetButtonDown("Fire1"))
            {
                switch (clickEvent)
                {
                    case Ev.StartGame:
                        StartGame();
                        break;
                    case Ev.Options:
                        Options();
                        break;
                    case Ev.QuitGame:
                        QuitGame();
                        break;
                    case Ev.SetResolution:
                        SetResolution();
                        break;
                    case Ev.FulScreen:
                        SetFullScreen();
                        break;
                    case Ev.Bloom:
                        SetBloom();
                        break;
                    case Ev.AntiAliasing:
                        SetAntiAliasing();
                        break;
                    case Ev.SSR:
                        SetSSR();
                        break;
                    case Ev.MotionBlur:
                        SetMotionBlur();
                        break;
                    case Ev.Volume:
                        //Add this in
                        break;
                }
            }
        }
    }

    void StartGame()
    {
        SceneManager.LoadScene(nextLevel);
    }

    void Options()
    {
        otherMenuParent.SetActive(true);
		for (int i = 0; i < others.Count - 1; i++)
		{
			others[i].isOver = false;
		}
        menuParent.SetActive(false);
    }

    void QuitGame()
    {
        Application.Quit();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isOver = false;
    }

    void TrueFalseButton()
    {
        onOff = !onOff;
        if (rend != null)
        {
            if (onOff == true)
            {
                rendImage.color = Color.white;
            }
            else
            {
                rendImage.color = new Color(1,1,1,0.5f);
            }
			rend.enabled = onOff;
        }
    }


    void SetResolution()
    {
        Screen.SetResolution(Mathf.RoundToInt(newRes.x), Mathf.RoundToInt(newRes.y), fullScreen);
    }

    void SetFullScreen()
    {
        TrueFalseButton();
        fullScreen = !fullScreen;
        Screen.SetResolution(Screen.width, Screen.height, fullScreen);
    }

    void SetBloom()
    {
        TrueFalseButton();
        pp.profile.bloom.enabled = onOff;
    }

    void SetMotionBlur()
    {
        TrueFalseButton();
        pp.profile.motionBlur.enabled = onOff;
    }

    void SetSSR()
    {
        TrueFalseButton();
        pp.profile.screenSpaceReflection.enabled = onOff;
    }

    void SetAntiAliasing()
    {
        TrueFalseButton();
        pp.profile.antialiasing.enabled = onOff;
    }
}