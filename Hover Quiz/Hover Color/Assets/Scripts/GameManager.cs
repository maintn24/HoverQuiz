using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Question[] questions;
    private List<Question> unansweredQuestions;

    private Question currentQuestion;

    [SerializeField]
    private Text quizText;

    [SerializeField]
    private Text AAnswer;

    [SerializeField]
    private Text BAnswer;

    [SerializeField]
    private Text CAnswer;

    [SerializeField]
    private Text DAnswer;

    [SerializeField]
    private float timeLoadingQuestion = 1f;

    [SerializeField]
    private float timeBetweenQuestion = 5f;

    [SerializeField]
    private Text checkingText;

    public Score score;
    public UnityEngine.GameObject questionPart;
    public UnityEngine.GameObject answerChecking;
    public UnityEngine.GameObject winUI;
    private float QuestionAnswered;
    public ObstacleMovement obsMovement;

    public float TryAgainDelayTime = 2f;

    private void Start()
    {
        QuestionAnswered = 0f;
        score.isEnded = false;
        obsMovement.enabled = true;
        questionPart.SetActive(false);
        StartCoroutine(GoToQuiz());
        if(unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions.ToList<Question>();
        }
        answerChecking.SetActive(false);///////////////

        SetCurrentQuestion();
    }

    void SetCurrentQuestion()
    {
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];

        quizText.text = currentQuestion.quiz;
        AAnswer.text = currentQuestion.AAns;
        BAnswer.text = currentQuestion.BAns;
        CAnswer.text = currentQuestion.CAns;
        DAnswer.text = currentQuestion.DAns;
    }


    void Pause()
    {
        Time.timeScale = 0f;
    }

    void Resume()
    {
        Time.timeScale = 1f;
    }

    void Win()
    {
        if (unansweredQuestions.Count == 0f)
        {
            questionPart.SetActive(false);
            winUI.SetActive(true);
            Pause();
        }
    }

    void Correct()
    {
        score.score += 10;
    }
    void Wrong()
    {
        score.score -= 10;
    }

    IEnumerator TransitionToContinue()
    {
        score.isEnded = false;
        Resume();
        
        unansweredQuestions.Remove(currentQuestion);

        yield return new WaitForSeconds(timeLoadingQuestion);

        answerChecking.SetActive(false);
        Win();

        SetCurrentQuestion();
        questionPart.SetActive(false);
        //

        StartCoroutine(GoToQuiz());
        QuestionAnswered += 1f;
        Debug.Log("Questions are answered:" + QuestionAnswered);
    }

    IEnumerator GoToQuiz()
    {
        yield return new WaitForSeconds(timeBetweenQuestion);

        questionPart.SetActive(true);
        score.isEnded = true;
        Pause();
    }

    public void UserSelectA()
    {
        if (currentQuestion.isA)
        {
            Debug.Log("Yes");
            checkingText.text = "CORRECT!!  +10pts";
            Correct();
        }
        else
        {
            Debug.Log("Nah");
            checkingText.text = "WRONG!!   -10pts";
            Wrong();
        }
        answerChecking.SetActive(true);

        StartCoroutine(TransitionToContinue());///////////

    }
    public void UserSelectB()
    {
        if (currentQuestion.isB)
        {
            Debug.Log("Yes");
            checkingText.text = "CORRECT!!  +10pts";
            Correct();

        }
        else
        {
            Debug.Log("Nah");
            checkingText.text = "WRONG!!   -10pts";
            Wrong();
        }
        answerChecking.SetActive(true);

        StartCoroutine(TransitionToContinue());///////////
    }
    public void UserSelectC()
    {
        if (currentQuestion.isC)
        {
            Debug.Log("Yes");
            checkingText.text = "CORRECT!!  +10pts";
            Correct();

        }
        else
        {
            Debug.Log("Nah");
            checkingText.text = "WRONG!!   -10pts";
            Wrong();
        }
        answerChecking.SetActive(true);

        StartCoroutine(TransitionToContinue());///////////
    }
    public void UserSelectD()
    {
        if (currentQuestion.isD)
        {
            Debug.Log("Yes");
            checkingText.text = "CORRECT!!  +10pts";
            Correct();

        }
        else
        {
            Debug.Log("Nah");
            checkingText.text = "WRONG!!   -10pts";
            Wrong();
        }
        answerChecking.SetActive(true);

        StartCoroutine(TransitionToContinue());///////////
    }




    
}
