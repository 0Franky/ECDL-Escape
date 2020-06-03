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

    public void DisableCombatCanvas(float timeDelay = 0.6f) {
        Invoke("InvokeAnimationFadeout", timeDelay - 0.6f);
        StartCoroutine(ToggleButtons(true, enemy.gameObject.tag, timeDelay));
        StartCoroutine(ToggleButtons(true, "Question", timeDelay));
        Invoke("DisableCombatCanvasInvoked", timeDelay);
    }

    private void InvokeAnimationFadeout() {
        combatCanvas.GetComponent<Animator>().SetBool("disappear", true);
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
        StartCoroutine(ToggleButtons(false, "Question"));
        Color btnColor = button.GetComponent<Image>().color;
        btnColor.a = 1;
        button.GetComponent<Image>().color = btnColor;
        ColorBlock cbGreen = button.colors;
        ColorBlock cbRed = button.colors;
        cbGreen.disabledColor = Color.green;
        cbRed.disabledColor = Color.red;
        if (QuestionAnswerUtils.checkAnswer(Int16.Parse(button.name))) {
            button.colors = cbGreen;
        } else {
            button.colors = cbRed;
            int i;
            for (i = 0; !QuestionAnswerUtils.checkAnswer(i); i++) ;
            combatCanvas.transform.Find("Question").gameObject.GetComponentsInChildren<Button>(true)[i].colors = cbGreen;
        }
        refreshBtnUI(button);
        DisableCombatCanvas(1.6f);
        QuestionAnswerUtils.nextQuestion();
    }

    private void refreshBtnUI(Button button) {
        button.interactable = !button.interactable;
        button.interactable = !button.interactable;
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
            if (i < answers.Count) {
                buttons[i].GetComponentInChildren<Text>().text = answers[i];
                buttons[i].gameObject.SetActive(true);
            } else {
                buttons[i].gameObject.SetActive(false);
            }
        }
    }

    IEnumerator ToggleButtons(bool activate, string parentID, float delayTime = 0f) {
        yield return new WaitForSeconds(delayTime);
        Component[] buttons = combatCanvas.transform.Find(parentID).gameObject.GetComponentsInChildren<Button>(true);
        foreach (Button button in buttons) {
            button.interactable = activate;
        }
    }
}
