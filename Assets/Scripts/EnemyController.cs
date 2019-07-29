using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public GameObject enemyShot;
    public Transform enemyShotSpawn;
    private int countah;
    

    public void Update()
    {
        if (countah % 150 == 75)
        {
            Fire();
        }
        countah++;
    }

    private void Fire()
    {
        Instantiate(enemyShot, enemyShotSpawn.position, enemyShotSpawn.rotation);
    }
}
