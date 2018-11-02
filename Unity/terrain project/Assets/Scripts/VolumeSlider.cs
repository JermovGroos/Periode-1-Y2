using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VolumeSlider : MonoBehaviour {

Slider slider;
AudioSource music;
	void Start () {
		music = FindObjectOfType<Music>().GetComponent<AudioSource>();;
		slider = GetComponent<Slider>();
		slider.value = 1;
	}
	
	void Update () {
		music.volume = slider.value;
	}
}
