using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DivisionGame : MonoBehaviour
{
    public Text problemText;

    public int correctAnswer;
    public int maxValue = 10;

    public Button button1;
    public Button button2;
    public Button button3;

    void Start()
    {
        GenerateProblem();
    }

    void GenerateProblem()
    {
        int num1 = Random.Range(1, maxValue);
        int num2 = Random.Range(1, maxValue);

        if (num1 < num2)
        {
            int temp = num1;
            num1 = num2;
            num2 = temp;
        }

        correctAnswer = Mathf.RoundToInt((float)num1 / (float)num2);
        string correctAnswerStr = num2 != 1 ? (correctAnswer > 0 ? $"{correctAnswer}/{num2}" : $"-{Mathf.Abs(correctAnswer)}/{num2}") : correctAnswer.ToString(); problemText.text = num1.ToString() + "  ÷  " + num2.ToString() + " = ?";

        List<string> answers = new List<string> { ConvertToFraction(Mathf.FloorToInt(num2 * Random.Range(1f, 10f))), ConvertToFraction(Mathf.FloorToInt(num2 * Random.Range(1f, 10f))), ConvertToFraction(correctAnswer) };
        int correctButtonIndex = Random.Range(0, 3);

        button1.GetComponentInChildren<Text>().text = answers[correctButtonIndex == 0 ? 2 : 0];
        button2.GetComponentInChildren<Text>().text = answers[correctButtonIndex == 1 ? 2 : 1];
        button3.GetComponentInChildren<Text>().text = answers[correctButtonIndex];
    }

    public void CheckAnswer1()
    {
        if (Mathf.Abs(int.Parse(button1.GetComponentInChildren<Text>().text.Split('/')[0]) - int.Parse(button1.GetComponentInChildren<Text>().text.Split('/')[1]) * correctAnswer) < 0.01)
        {
            Debug.Log("Correct!");
            GenerateProblem();
        }
        else
        {
            Debug.Log("Incorrect!");
        }
    }

    public void CheckAnswer2()
    {
        if (Mathf.Abs(int.Parse(button2.GetComponentInChildren<Text>().text.Split('/')[0]) - int.Parse(button2.GetComponentInChildren<Text>().text.Split('/')[1]) * correctAnswer) < 0.01)
        {
            Debug.Log("Correct!");
            GenerateProblem();
        }
        else
        {
            Debug.Log("Incorrect!");
        }
    }

    public void CheckAnswer3()
    {
        if (Mathf.Abs(int.Parse(button3.GetComponentInChildren<Text>().text.Split('/')[0]) - int.Parse(button3.GetComponentInChildren<Text>().text.Split('/')[1]) * correctAnswer) < 0.01)
        {
            Debug.Log("Correct!");
            GenerateProblem();
        }
        else
        {
            Debug.Log("Incorrect!");
        }
    }

    string ConvertToFraction(int value)
    {
        int gcd = GCD(value, 1);
        return $"{value / gcd}/{1 / gcd}";
    }

    int GCD(int a, int b)
    {
        return b == 0 ? a : GCD(b, a % b);
    }
}