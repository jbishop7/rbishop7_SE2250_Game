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
    public TMP_Text scoreText;
    public TMP_Text mainScoreText;

    public GameObject quizPanel;
    public GameObject goPanel; //gameover panel

    public GameObject triviaPanel; //the whole quiz area

    public GameObject fail;
    public GameObject pass;

    public TMP_Text questionTxt;
    public TMP_Text scoreTxt;

    private int _totalQuestions = 0;
    private float elapsedTime = 0; // The amount of time that has elapsed.
    
    float bonusTimer;
    public int score;

    public Player player;

    private bool brain = false;

    public GameObject dialogue;
    private DialogueManager dMan;
    private void Start()
    {
        dMan = FindObjectOfType<DialogueManager>();
        _totalQuestions = qA.Count;
        goPanel.SetActive(false);
        GenerateQuestion();
        
       
    }
    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
    
    void Update()
    {
        bonusTimer = 0;
        // Update your timer every frame.
        bonusTimer += Time.deltaTime;
        SetScoreText();
        
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
        dialogue.SetActive(true);
        dMan.NextLevel();
        
    }

    public void GameOver()
    {
        quizPanel.SetActive(false);
        goPanel.SetActive(true);
        scoreTxt.text = score + "/" + "10";
        brain = player.Brain();
        if (brain)
        {
            if (score > 4)
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
            if (score > 6)
            {
                pass.SetActive(true);
            }

            else
            {
                fail.SetActive(true);
            }
        }
        

    }

    void AssignPoints()
    {
        // Add points based on how much time has elapsed.
        // The player gets 2 points for finishing at or under 2 seconds,
        // 1 point between 2 and 10 seconds, and no points above ten seconds.
        if (bonusTimer <= 1f)
        {
            score += 2;
            Player.Instance.increaseScore(2);
        }
        else if (bonusTimer > 1f && bonusTimer <= 3f)
        {
            score += 1;
            Player.Instance.increaseScore(1);
        }
        SetScoreText();
        
    }
    //here!!

    public void Correct()
    {

        AssignPoints();
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
