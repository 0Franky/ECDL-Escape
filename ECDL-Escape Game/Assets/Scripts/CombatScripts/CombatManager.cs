using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour {

    public Rigidbody2D player;
    public Rigidbody2D enemy;
    public int enemyHealth;
    public GameObject combatCanvas;
    public int numberModule = 1;
    public QuestionAnswerUtils QuestionAnswerUtils;

    // Start is called before the first frame update
    void Start() {
        QuestionAnswerUtils.setModule(numberModule);
    }

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
        StartCoroutine(ToggleButtons(true, enemy.gameObject.tag, 0.6f));
        StartCoroutine(ToggleButtons(true, "Question", 0.6f));
        Invoke("DisableCombatCanvasInvoked", 0.6f);
    }

    public void HeadClicked() {
        DisableButtonsAndShowQuestion();
        Debug.Log("Head Clicked");
    }

    public void BodyClicked() {
        DisableButtonsAndShowQuestion();
        Debug.Log("Body Clicked");
    }

    public void AnswerClicked(Button button) {
        ToggleButtons(false, "Question", 0, false);
        Color btnColor = button.GetComponent<Image>().color;
        btnColor.a = 1;
        button.GetComponent<Image>().color = btnColor;
        ColorBlock cb = button.colors;
        if (QuestionAnswerUtils.checkAnswer(Int16.Parse(button.name))) {
            cb.normalColor = Color.green;
        } else {
            cb.normalColor = Color.red;
        }
        button.colors = cb;
        button.interactable = true;
    }

    void DisableCombatCanvasInvoked() {
        combatCanvas.transform.Find(enemy.gameObject.tag).gameObject.SetActive(false);
        combatCanvas.transform.Find("Question").gameObject.SetActive(false);
        combatCanvas.transform.Find("Time").gameObject.SetActive(false);
        combatCanvas.SetActive(false);
    }
    void DisableButtonsAndShowQuestion() {
        StartCoroutine(ToggleButtons(false, enemy.gameObject.tag));
        combatCanvas.transform.Find("Question").gameObject.SetActive(true);
        combatCanvas.transform.Find("Time").gameObject.SetActive(true);
        combatCanvas.transform.Find("Question").GetComponent<Text>().text = QuestionAnswerUtils.getQuestion();

        List<string> answers = QuestionAnswerUtils.getAnswers();
        Component[] buttons = combatCanvas.transform.Find("Question").gameObject.GetComponentsInChildren<Button>(true);
        for (int i = 0; i < buttons.Length; i++) {
            buttons[i].GetComponentInChildren<Text>().text = answers[i];
        }
    }

    IEnumerator ToggleButtons(bool activate, string parentID, float delayTime = 0f, bool asyncExc = true) {
        if (asyncExc) {
            yield return new WaitForSeconds(delayTime);
        }
        Component[] buttons = combatCanvas.transform.Find(parentID).gameObject.GetComponentsInChildren<Button>(true);
        foreach (Button button in buttons) {
            button.interactable = activate;
        }
    }
}
