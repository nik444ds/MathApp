using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SubtractionGame : MonoBehaviour
{
    public Text questionText;
    public int CorrectAnswer;
    public int limitValue = 100;

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
        int number1 = Random.Range(0, limitValue);
        int number2 = Random.Range(0, number1); // garante que o número 1 seja sempre maior do que o número 2
        CorrectAnswer = number1 - number2;
        questionText.text = number1.ToString() + " - " + number2.ToString() + " = ?";

        List<int> wrongAnswers = new List<int>();
        wrongAnswers.Add(Random.Range(number1 + 1, limitValue)); // adiciona uma resposta aleatória maior que o número 1
        wrongAnswers.Add(Random.Range(0, number2)); // adiciona uma resposta aleatória menor que o número 2

        List<int> answers = wrongAnswers;
        answers.Add(CorrectAnswer); // adiciona a resposta correta à lista de respostas

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
            GenerateQuestion();
        }
        else
        {
            Debug.Log("Incorrect!");
        }
    }
}