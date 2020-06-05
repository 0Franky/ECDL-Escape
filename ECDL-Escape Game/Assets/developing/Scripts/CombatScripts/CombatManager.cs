using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour {

    public Rigidbody2D player;
    public Rigidbody2D enemy;
    public int enemyHealth;
    public LostLife playerHealth;
    public GameObject combatCanvas;
    public int numberModule = 1;
    public QuestionAnswerUtils QuestionAnswerUtils;
    public Slider timeSlider;
    bool head = false;
    bool body = false;
    

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

    public void TimeExpired() {
        //CheckPlayerHealth();
        Invoke("EnemyAtt", 1.9f);
        body = false;
        head = false;
        DisableCombatCanvas(1.6f);
        QuestionAnswerUtils.nextQuestion();
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
        timeSlider.GetComponent<SliderUtils>().isTimeActive = true;
        timeSlider.value = 5;
        DisableButtonsAndShowQuestion();
        head = true;
        Debug.Log("Head Clicked");
        
    }

    public void BodyClicked() {
        timeSlider.GetComponent<SliderUtils>().isTimeActive = true;
        timeSlider.value = 10;
        DisableButtonsAndShowQuestion();
        body = true;
        Debug.Log("Body Clicked");
    }

    public void AnswerClicked(Button button) {
        timeSlider.GetComponent<SliderUtils>().isTimeActive = false;
        StartCoroutine(resetColorDisabledButton("Question"));
        StartCoroutine(ToggleButtons(false, "Question"));
        StartCoroutine(setBGColorBtns(button));
    }

    IEnumerator setBGColorBtns(Button button, float delayTime = 0.1f) {
        yield return new WaitForSeconds(delayTime);

        ColorBlock cbGreen = button.colors;
        ColorBlock cbRed = button.colors;
        cbGreen.disabledColor = Color.green;
        cbRed.disabledColor = Color.red;
        if (QuestionAnswerUtils.checkAnswer(Int16.Parse(button.name))) {
            button.colors = cbGreen;
            if (body) {
                Invoke("PlayerAtt01", 1.9f);
                enemyHealth--;
            }
            if (head) {                                                          // Se hai scelto di colpire alla testa e hai azzeccato la risposta, l'animazione del personaggio sarà diversa
                Invoke("PlayerAtt02", 1.9f);
                enemyHealth -= 2;
            }
        } else {
            Invoke("EnemyAtt", 1.9f);
            //Invoke("LifeHit", 1.9f);
            button.colors = cbRed;
            int i;
            for (i = 0; !QuestionAnswerUtils.checkAnswer(i); i++) ;
            combatCanvas.transform.Find("Question").gameObject.GetComponentsInChildren<Button>(true)[i].colors = cbGreen;
        }
        body = false;
        head = false;
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

    void CheckEnemyHealth() {
        if (enemyHealth <= 0) {
            Invoke("EnemyDeath", 1f);
        }
        else {
            Invoke("EnemyHit", 1f);
            Invoke("EnableCombatCanvas", 1.8f);
        }
    }
    void CheckPlayerHealth() {
        Invoke("LifeHit", 0.2f);
        if (playerHealth.numberLife <= 1) {
            Invoke("PlayerDeath", 0.2f);
        }
        else {
            Invoke("PlayerHit", 0.2f);
            Invoke("EnableCombatCanvas", 1.8f);
        }
    }

    void LifeHit() {
        playerHealth.LifeHit();
    }

    void PlayerAtt01() {
        player.GetComponent<Animator>().SetBool("attack01", true);
        CheckEnemyHealth();
    }
    void PlayerAtt02() {
        player.GetComponent<Animator>().SetBool("attack02", true);
        CheckEnemyHealth();
    }
    void EnemyAtt() {
        enemy.GetComponent<Animator>().SetBool("attack01", true);
        Invoke("EnemyAttackFalse", 0.1f);
        //Invoke("PlayerHit", 0.2f);
        CheckPlayerHealth();
    }

    void PlayerHit() {
        player.GetComponent<Animator>().SetBool("hit", true);
    }
    void EnemyHit() {
        enemy.GetComponent<Animator>().SetBool("hit", true);
        Invoke("EnemyHitFalse", 0.1f);
    }
    void EnemyDeath() {
        enemy.GetComponent<Animator>().SetBool("died", true);
        Invoke("DisableEnemyObject", 1.6f);
    }
    void PlayerDeath() {
        player.GetComponent<Animator>().SetBool("died", true);
    }
    void EnemyHitFalse() {
        enemy.GetComponent<Animator>().SetBool("hit", false);
    }
    void EnemyAttackFalse() {
        enemy.GetComponent<Animator>().SetBool("attack01", false);
    }
    void DisableEnemyObject() {
        enemy.gameObject.SetActive(false);
    }

    IEnumerator ToggleButtons(bool activate, string parentID, float delayTime = 0f) {
        return ActionOnButtons((Button button) => button.interactable = activate, parentID, delayTime);
    }

    IEnumerator resetColorDisabledButton(string parentID, float delayTime = 0f) {
        return ActionOnButtons((Button button) => {
            ColorBlock cb = button.colors;
            Color c = cb.disabledColor;
            c.a = 0f;
            cb.disabledColor = c;
            button.colors = cb;
        }, parentID, delayTime);
    }

    IEnumerator ActionOnButtons(Action<Button> callback, string parentID, float delayTime = 0f) {
        yield return new WaitForSeconds(delayTime);
        Component[] buttons = combatCanvas.transform.Find(parentID).gameObject.GetComponentsInChildren<Button>(true);
        foreach (Button button in buttons) {
            callback(button);
        }
    }
}
