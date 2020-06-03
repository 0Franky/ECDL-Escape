using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour {

    public Rigidbody2D player;
    public Rigidbody2D enemy;
    public int enemyHealth;
    public GameObject combatCanvas;

    void OnEnable() {
        Debug.Log("CombatManager Active");
    }

    // Update is called once per frame
    void Update() {
        // Test, premi k e disattivi/attivi il nemico nella scena
        if (Input.GetKeyDown("k")) {
            if (enemy.gameObject.activeInHierarchy)
                enemy.gameObject.SetActive(false);
            else
                enemy.gameObject.SetActive(true);
        }
    }

    public void EnableCombatCanvas() {
        combatCanvas.transform.Find(enemy.gameObject.tag).gameObject.SetActive(true);
        combatCanvas.SetActive(true);
    }

    public void DisableCombatCanvas() {
        combatCanvas.GetComponent<Animator>().SetBool("disappear", true);
        StartCoroutine(ToggleButtons(true, 0.5f));
        Invoke("DisableCombatCanvasInvoked", 0.5f);
    }

    public void HeadClicked() {
        DisableButtonsAndShowQuestion();
        Debug.Log("Head Clicked");
    }

    public void BodyClicked() {
        DisableButtonsAndShowQuestion();
        Debug.Log("Body Clicked");
    }

    void DisableCombatCanvasInvoked() {
        combatCanvas.transform.Find(enemy.gameObject.tag).gameObject.SetActive(false);
        combatCanvas.SetActive(false);
    }
    void DisableButtonsAndShowQuestion() {
        StartCoroutine(ToggleButtons(false));
        combatCanvas.transform.Find("Question").gameObject.SetActive(true);
        combatCanvas.transform.Find("Time").gameObject.SetActive(true);
    }

    IEnumerator ToggleButtons(bool activate, float delayTime = 0f) {
        yield return new WaitForSeconds(delayTime);
        Component[] buttons = combatCanvas.transform.Find(enemy.gameObject.tag).gameObject.GetComponentsInChildren<Button>(true);
        foreach (Button button in buttons) {
            button.enabled = activate;
        }
    }
}
