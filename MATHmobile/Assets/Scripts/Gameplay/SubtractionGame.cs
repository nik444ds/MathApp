using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubtractionGame : MonoBehaviour
{
    public Text questionText;
    public int CorrectAnswer;
    public int limitValue = 100;
    public int difficulty = 1;

    public Button buttonA;
    public Button buttonB;
    public Button buttonC;

    private void Start()
    {
        GenerateQuestion();
        buttonA.onClick.AddListener(() => CheckAnswer(buttonA));
        buttonB.onClick.AddListener(() => CheckAnswer(buttonB));
        buttonC.onClick.AddListener(() => CheckAnswer(buttonC));
    }

    private void GenerateQuestion()
    {
        int number1;
        int number2;
        do
        {
            number1 = Random.Range(0, limitValue / difficulty);
            number2 = Random.Range(0, number1);
        } while (number1 - number2 == CorrectAnswer); // garante que a subtração seja diferente da última

        CorrectAnswer = number1 - number2;
        questionText.text = number1.ToString() + " - " + number2.ToString() + " = ?";

        List<int> wrongAnswers = new List<int>();
        do
        {
            int wrongAnswer = Random.Range(number1 + 1, limitValue / difficulty);
            if (!wrongAnswers.Contains(wrongAnswer))
            {
                wrongAnswers.Add(wrongAnswer);
            }
        } while (wrongAnswers.Count < 2); // garante que haja pelo menos 2 respostas erradas

        List<int> answers = wrongAnswers;
        answers.Add(CorrectAnswer);

        int correctButtonIndex = Random.Range(0, 3);
        buttonA.GetComponentInChildren<Text>().text = answers[correctButtonIndex == 0 ? 2 : 0].ToString();
        buttonB.GetComponentInChildren<Text>().text = answers[correctButtonIndex == 1 ? 2 : 1].ToString();
        buttonC.GetComponentInChildren<Text>().text = answers[correctButtonIndex].ToString();
    }

    public void CheckAnswer(Button button)
    {
        int realAnswer = int.Parse(button.GetComponentInChildren<Text>().text);
        if (realAnswer == CorrectAnswer)
        {
            Debug.Log("Correct!");
            difficulty++;
            GenerateQuestion();
        }
        else
        {
            Debug.Log("Incorrect!");
        }
    }
}