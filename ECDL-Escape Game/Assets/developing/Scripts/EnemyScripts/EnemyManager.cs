using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public CombatManager combatManager;
    public PlayerMovement2 movement;
    public Transform myPos;
    [SerializeField] int myHealth = 2;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            combatManager.enemy = myPos.GetComponent<Rigidbody2D>(); // Sends Rigidbody2D component to Combat Manager
            combatManager.enemyHealth = myHealth;
            movement.inCombat = true;
            movement.enemyPos = myPos;
            Invoke("EnableCombatManager", 1f);
            Debug.Log("Sei entrato in combattimento");
        }
    }
    private void OnTriggerExit2D(Collider2D collision2) {
        if (collision2.CompareTag("Player")) {
            movement.inCombat = false;
            Invoke("DisableCombatManager", 1f);
            Debug.Log("Sei uscito dal combattimento");
        }
    }

    public void HitEnded() {
        Debug.Log("AO");
        myPos.gameObject.GetComponent<Animator>().SetBool("hit", false);
    }

    //Shows combat canvas and enables CombatManager script
    void EnableCombatManager() {
        combatManager.enabled = true;
        combatManager.EnableCombatCanvas();
    }

    //Disables combat canvas and CombatManager script
    void DisableCombatManager() {
        combatManager.DisableCombatCanvas();
        combatManager.enabled = false;
    }

}
