using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    // reminder: instead of Text use TMP_Text

    public List<QandA> qA;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject quizPanel;
    public GameObject goPanel; //gameover panel

    public GameObject triviaPanel; //the whole quiz area

    public GameObject fail;
    public GameObject pass;

    public TMP_Text questionTxt;
    public TMP_Text scoreTxt;

    private int _totalQuestions = 0;
    public int score;

    public Player player;

    private bool brain = false;
    private void Start()
    {
        _totalQuestions = qA.Count;
        goPanel.SetActive(false);
        GenerateQuestion();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //might have to change this and just have it reload the questions
    }

    public void NextLevel()
    {
        //code that lets you proceed to the next level
        Debug.Log("You may proceed to the next level"); //change this 
        triviaPanel.SetActive(false);
        player.LevelComplete();
    }

    public void GameOver()
    {
        quizPanel.SetActive(false);
        goPanel.SetActive(true);
        scoreTxt.text = score + "/" + _totalQuestions;
        brain = player.Brain();
        if (brain)
        {
            if (score > 1)
            {
                pass.SetActive(true);
            }

            else
            {
                fail.SetActive(true);
            }
        }
        else
        {
            if (score > 2)
            {
                pass.SetActive(true);
            }

            else
            {
                fail.SetActive(true);
            }
        }
        

    }

    public void Correct()
    {
        score++;
        qA.RemoveAt(currentQuestion);
        GenerateQuestion();
    }
    public void Wrong()
    {
        qA.RemoveAt(currentQuestion);
        GenerateQuestion();
    }

    void SetAnswer()
    {
        for(int i=0; i<options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = qA[currentQuestion].answers[i];

            if(qA[currentQuestion].correctAnswer == i+1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void GenerateQuestion()
    {
        if(qA.Count > 0)
        {
            currentQuestion = Random.Range(0, qA.Count);

            questionTxt.text = qA[currentQuestion].question;
            SetAnswer();
        }
        else
        {
            Debug.Log("Out of Questions");
            GameOver();
        }
        

    }

}
