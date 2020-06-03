using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class QuestionAnswerUtils : MonoBehaviour {

    /* VARS */
    private int currentModule;
    private List<int> doneQuestions = new List<int>();

    /* QUESTION/ANSWER VARS */
    private List<QuestionAnswer> questionAnswerData = new List<QuestionAnswer>();

    /* FILE NAMES */
    private string MODULE_1 = "Modulo1";
    private string MODULE_2 = "Modulo2";
    private string FILE_DONE_QUESTIONS = "qd.bin";

    // Start is called before the first frame update
    void Start() {
        //setModule(1, false); /* PER TEST */
        //getQuestion(); /* PER TEST */
        //getAnswers(); /* PER TEST */
        //checkAnswer(0); /* PER TEST */
    }

    // Update is called once per frame
    void Update() {

    }

    /*
     PARAMS:
        numerModule = numero del modulo di cui caricheremo le domande; 
        loadModule = boolean -> carica tutte le domande; se false continua dall'ultimo salvataggio
     */
    public void setModule(int numerModule, bool loadFromStart = true) {
        currentModule = numerModule;
        loadData(loadFromStart);
    }

    /* Restituisce la domanda */
    public string getQuestion() {
        return questionAnswerData[0].getQuestion();
    }

    /* Restituisce un array di possibili risposte */
    public List<string> getAnswers() {
        List<string> answers = new List<string>();
        foreach (Answer answer in questionAnswerData[0].getAnswerList()) {
            answers.Add(answer.getAnswer());
        }
        return answers;
    }

    /*
     PARAMS:
        numberAnswer = numero della domanda (corrispondente alla cella dell'array passato di possibili risposte); restituisce true se la risposta è corretta, false altrimenti; 

     Inoltre richiama nextQuestion()
     */
    public bool checkAnswer(int numberAnswer) {
        bool result = questionAnswerData[0].getAnswerList()[numberAnswer].isCorrect();
        nextQuestion();
        return result;
    }

    /* Carica le domande da file */
    private void loadData(bool loadFromStart = true) {
        string fileName = MODULE_1;
        if (currentModule == 2) {
            fileName = MODULE_2;
        }

        doneQuestions.Clear();
        questionAnswerData.Clear();

        if (!loadFromStart) {
            loadDoneQuestions();
        }

        TextAsset dataString = Resources.Load<TextAsset>(fileName);

        string[] rows = dataString.text.Split(new char[] { '\n' });

        for (int k = 0; k < rows.Length; k++) {
            if (isStringAcceptable(rows[k]) && !doneQuestions.Contains(k)) {
                string[] cols = rows[k].Split(new char[] { ';' });

                QuestionAnswer questionAnswer = new QuestionAnswer();
                for (int i = 0; i < cols.Length; i++) {
                    if (isStringAcceptable(cols[i])) {
                        if (i == 0) {
                            questionAnswer.setNumberQuestion(Int16.Parse(cols[i]));
                        } else if (i == 1) {
                            questionAnswer.setQuestion(cols[i]);
                        } else {
                            questionAnswer.addAnswer(new Answer(cols[i], i == 2));
                        }
                    }
                }

                questionAnswerData.Insert(new System.Random().Next(0, questionAnswerData.Count), questionAnswer);
            }
        }
    }

    private bool isStringAcceptable(string str) {
        return !String.IsNullOrEmpty(str) && !str.Equals("\r");
    }

    /* Carica la domanda successiva */
    private void nextQuestion() {
        doneQuestions.Add(questionAnswerData[0].getNumberQuestion());
        saveDoneQuestions();
        questionAnswerData.RemoveAt(0);
        if (questionAnswerData.Count == 0) {
            loadData();
        }
    }

    private void saveDoneQuestions() {
        if (File.Exists(FILE_DONE_QUESTIONS)) {
            File.Delete(FILE_DONE_QUESTIONS);
        }

        Stream s = File.OpenWrite(FILE_DONE_QUESTIONS);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(s, doneQuestions);
        s.Close();
    }

    private void loadDoneQuestions() {
        if (File.Exists(FILE_DONE_QUESTIONS)) {
            Stream s = File.OpenRead(FILE_DONE_QUESTIONS);
            BinaryFormatter bf = new BinaryFormatter();
            doneQuestions = (List<int>)bf.Deserialize(s);
            s.Close();
        }
    }


    /* CLASSI DI SUPPORTO */
    class Answer {
        private string answer;
        private bool _isCorrect;

        public Answer(string answer, bool _isCorrect = false) {
            this.answer = answer;
            this._isCorrect = _isCorrect;
        }

        public string getAnswer() {
            return answer;
        }

        public bool isCorrect() {
            return _isCorrect;
        }
    }


    class QuestionAnswer {
        private int numberQuestion;
        private string question;
        private List<Answer> answerList = new List<Answer>();

        public QuestionAnswer() { }

        public void setNumberQuestion(int numberQuestion) {
            this.numberQuestion = numberQuestion;
        }

        public void setQuestion(string question) {
            this.question = question;
        }

        public void addAnswer(Answer answer) {
            this.answerList.Insert(new System.Random().Next(0, answerList.Count), answer);
        }

        public int getNumberQuestion() {
            return numberQuestion;
        }

        public string getQuestion() {
            return question;
        }

        public List<Answer> getAnswerList() {
            return answerList;
        }
    }
}
