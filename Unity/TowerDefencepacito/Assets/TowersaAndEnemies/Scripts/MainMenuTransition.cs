using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuTransition : MonoBehaviour {

public GameObject audioPrefab;
public AudioClip[] clips;
Image img;
public int startMusic = 0;
	void Start () {
		transform.eulerAngles = new Vector3(0,0,71.12601f);
		img = transform.GetChild(0).GetComponent<Image>();
		FindObjectOfType<Music>().ChangeMusic(startMusic);
	}
	
	void Update () {
		transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.Euler(0,0,0),Time.deltaTime * 2);
		img.color = Color.Lerp(img.color,new Color(img.color.r,img.color.g,img.color.b,1),Time.unscaledDeltaTime);
		if(Input.GetButtonDown("Fire1") == true){
			//transform.eulerAngles = new Vector3(0,0,71.12601f);
		}
	}

	public void PlayAudio(int clip)
    {
        AudioSource a = Instantiate(audioPrefab, transform.position, Quaternion.identity).GetComponent<AudioSource>();
        a.clip = clips[clip];
        a.Play();
        Destroy(a.gameObject, a.clip.length);
    }
}
