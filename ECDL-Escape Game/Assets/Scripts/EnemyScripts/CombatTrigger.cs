using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTrigger : MonoBehaviour {

    public CombatManager combatManager;
    public PlayerMovement2 movement;
    public Transform myPos;
    public GameObject combatCanvas;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            combatManager.enemy = myPos.GetComponent<Rigidbody2D>(); // Sends Rigidbody2D component to Combat Manager
            movement.inCombat = true;
            movement.enemyPos = myPos;
            Invoke("ShowCombatCanvas", 1f);
            Debug.Log("Sei entrato in combattimento");
        }
    }
    private void OnTriggerExit2D(Collider2D collision2) {
        if (collision2.CompareTag("Player")) {
            movement.inCombat = false;
            Debug.Log("Sei uscito dal combattimento");
        }
    }

    void ShowCombatCanvas() {
        combatCanvas.transform.Find(myPos.gameObject.tag).gameObject.SetActive(true);
        combatCanvas.SetActive(true);
    }

}
