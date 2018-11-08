using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMouseButtonText : MonoBehaviour
{

    Text txt;
    Manager manager;
    public enum Button
    {
        Left = 0,
        Right = 1,
        Middle = 2
    }
    public Button button = Button.Left;
	TowerSelection twrSelect;
	Cam cam;

    void Start()
    {
        txt = GetComponent<Text>();
        manager = FindObjectOfType<Manager>();
		twrSelect = FindObjectOfType<TowerSelection>();
		cam = FindObjectOfType<Cam>();
    }

    void Update()
    {
        txt.text = CheckState((int)button);
    }

    string CheckState(int butt)
    {
        string toReturn = "";
        switch (butt)
        {
            case 0:
                if(manager.talking == true){
					toReturn = "Next";
				} else {
					toReturn = "";
					if(twrSelect.canDoStuff == true){
					   toReturn = "Buy";
				   }
				}
                break;
            case 1:
               if(manager.talking == false){
				   if(twrSelect.canDoStuff == true){
					   toReturn = "Cancel";
				   } else if(cam.curCamPos == 0){
					   toReturn = "Camera";
				   }
			   }
                break;
            case 2:
                if(manager.talking == false){
				   if(twrSelect.canDoStuff == true){
					   toReturn = "Scroll";
				   } else {
					   toReturn = "Zoom";
				   }
			   }
                break;
        }
        return toReturn;
    }
}
