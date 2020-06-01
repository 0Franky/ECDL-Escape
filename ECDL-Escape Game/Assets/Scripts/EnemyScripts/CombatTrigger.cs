using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTrigger : MonoBehaviour {

    public CombatManager combatManager;
    public PlayerMovement2 movement;
    public Transform myPos;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            combatManager.enemy = myPos.GetComponent<Rigidbody2D>(); // Sends Rigidbody2D component to Combat Manager
            movement.inCombat = true;
            movement.enemyPos = myPos;
            Debug.Log("Sei entrato in combattimento");
        }
    }
    private void OnTriggerExit2D(Collider2D collision2) {
        if (collision2.CompareTag("Player")) {
            movement.inCombat = false;
            Debug.Log("Sei uscito dal combattimento");
        }
    }
}
