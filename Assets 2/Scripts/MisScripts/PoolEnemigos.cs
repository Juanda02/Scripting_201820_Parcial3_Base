using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolEnemigos : MonoBehaviour {

    public GameObject prefabEnemy;

    public Color baseColor;

    public Color taggedColor;

    public GameObject[] enemies = new GameObject[4];

    public Transform[] spawnPoints = new Transform[4];

    void Awake()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i] = Instantiate(prefabEnemy,spawnPoints[i].position, spawnPoints[i].rotation);
            enemies[i].GetComponent<Actor>().baseColor = this.baseColor;
            enemies[i].GetComponent<Actor>().taggedColor = this.taggedColor;
        }
        GameManager.Instance.transformActors[1] = enemies[0].transform;
        GameManager.Instance.transformActors[2] = enemies[1].transform;
        GameManager.Instance.transformActors[3] = enemies[2].transform;
        GameManager.Instance.transformActors[4] = enemies[3].transform;
        
    }

   

}
