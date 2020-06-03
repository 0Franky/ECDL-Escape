using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour {

    public Rigidbody2D player;
    public Rigidbody2D enemy;
    public int enemyHealth;
    //GameObject enemyGO;

    // Start is called before the first frame update
    void Start() {

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
