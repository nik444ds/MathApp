using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AdditionGame : MonoBehaviour
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
        // Desabilita os botões
        buttonA.interactable = false;
        buttonB.interactable = false;
        buttonC.interactable = false;

        int number1 = Random.Range(0, limitValue);
        int number2 = Random.Range(0, limitValue);
        CorrectAnswer = number1 + number2;
        questionText.text = number1.ToString() + " + " + number2.ToString() + " = ?";

        List<int> wrongAnswers = new List<int>();
        int wrongAnswer1 = Random.Range(1, limitValue + limitValue);
        int wrongAnswer2 = Random.Range(1, limitValue + limitValue);

        List<int> answers = new List<int>();
        answers.Add(CorrectAnswer); // adiciona a resposta correta à lista de respostas
        answers.Add(wrongAnswer1); // adiciona uma resposta incorreta à lista de respostas
        answers.Add(wrongAnswer2); // adiciona outra resposta incorreta à lista de respostas

        // Mistura as respostas
        answers.Sort();
        Shuffle(answers);

        // Habilita os botões e define as respostas
        buttonA.interactable = true;
        buttonB.interactable = true;
        buttonC.interactable = true;
        buttonA.GetComponentInChildren<Text>().text = answers[0].ToString();
        buttonB.GetComponentInChildren<Text>().text = answers[1].ToString();
        buttonC.GetComponentInChildren<Text>().text = answers[2].ToString();
    }

    private void Shuffle<T>(List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            int k = Random.Range(0, n--);
            T value = list[n];
            list[n] = list[k];
            list[k] = value;
        }
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