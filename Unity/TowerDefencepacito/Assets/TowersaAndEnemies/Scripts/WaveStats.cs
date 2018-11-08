using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WaveStats {
	public int[] spawns = new int[4];
	public float[] spawnSpeed = new float[4];
	public GameObject[] enemyPrefab = new GameObject[4];
}
