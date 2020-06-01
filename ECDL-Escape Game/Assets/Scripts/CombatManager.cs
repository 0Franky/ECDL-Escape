using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour {

    public Rigidbody2D player;
    public Rigidbody2D enemy;
    //GameObject enemyGO;

    // Start is called before the first frame update
    void Start() {
        //enemyGO = enemy.gameObject;
    }

    // Update is called once per frame
    void Update() {
        
        // Test, premi k e disattivi/attivi il nemico nella scena
        //if(Input.GetKeyDown("k")) {
        //    if (enemyGO.activeInHierarchy)
        //        enemyGO.SetActive(false);
        //    else
        //        enemyGO.SetActive(true);
        //}
    }
}
