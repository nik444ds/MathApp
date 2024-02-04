using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MathGame : MonoBehaviour
{
    public Text problemText;

    public int correctAnswer;
    public int maxValue = 10;
    public int problemsSolved = 0;
    public int problemsToIncreaseMaxValue = 5;

    public Button button1;
    public Button button2;
    public Button button3;

    void Start()
    {
        GenerateProblem();
    }

    void GenerateProblem()
    {
        if (problemsSolved >= problemsToIncreaseMaxValue)
        {
            maxValue++;
            problemsSolved = 0;
        }

        int num1 = Random.Range(1, maxValue);
        int num2 = Random.Range(1, maxValue);
        correctAnswer = num1 * num2;
        problemText.text = num1.ToString() + " x " + num2.ToString() + " = ?";


        int wrongAnswer1 = Random.Range(1, maxValue * maxValue);
        int wrongAnswer2 = Random.Range(1, maxValue * maxValue);
        while (wrongAnswer1 == correctAnswer || wrongAnswer1 == wrongAnswer2)
        {
            wrongAnswer1 = Random.Range(1, maxValue * maxValue);
        }
        while (wrongAnswer2 == correctAnswer || wrongAnswer2 == wrongAnswer1)
        {
            wrongAnswer2 = Random.Range(1, maxValue * maxValue);
        }

        List<int> answers = new List<int> { wrongAnswer1, wrongAnswer2, correctAnswer };
        int correctButtonIndex = Random.Range(0, 3);

        button1.GetComponentInChildren<Text>().text = answers[correctButtonIndex == 0 ? 2 : 0].ToString();
        button2.GetComponentInChildren<Text>().text = answers[correctButtonIndex == 1 ? 2 : 1].ToString();
        button3.GetComponentInChildren<Text>().text = answers[correctButtonIndex].ToString();
    }

    public void CheckAnswer1()
    {
        int playerAnswer = int.Parse(button1.GetComponentInChildren<Text>().text);
        if (playerAnswer == correctAnswer)
        {
            Debug.Log("Correct!");
            problemsSolved++;
            GenerateProblem();
        }
        else
        {
            Debug.Log("Incorrect!");
        }
    }

    public void CheckAnswer2()
    {
        int playerAnswer = int.Parse(button2.GetComponentInChildren<Text>().text);
        if (playerAnswer == correctAnswer)
        {
            Debug.Log("Correct!");
            problemsSolved++;
            GenerateProblem();
        }
        else
        {
            Debug.Log("Incorrect!");
        }
    }

    public void CheckAnswer3()
    {
        int playerAnswer = int.Parse(button3.GetComponentInChildren<Text>().text);
        if (playerAnswer == correctAnswer)
        {
            Debug.Log("Correct!");
            problemsSolved++;
            GenerateProblem();
        }
        else
        {
            Debug.Log("Incorrect!");
        }
    }
}