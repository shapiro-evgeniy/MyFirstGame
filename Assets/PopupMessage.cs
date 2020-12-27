using System;
using UnityEngine;
using UnityEngine.UI;

public class PopupMessage : MonoBehaviour
{
    public GameObject popupWindow;
    public Text textExercise;
    public Text textAnswer;

    private Exercise _exercise;
    private Action<bool> _callBack;

    public void Close()
    {
        popupWindow.SetActive(false);
        Time.timeScale = 1f;        
        _callBack(_exercise.CheckAnswer(textAnswer.text));
    }

    public void Open(Action<bool> callBack)
    {
        _callBack = callBack;
        popupWindow.SetActive(true);
        Time.timeScale = 0f;

        _exercise = new Exercise();

        textExercise.text = _exercise.StringPresent;

        textAnswer.text = string.Empty;
    }

    public void DigitButton(int digit)
    {
        textAnswer.text += digit.ToString();
    }

    public void ClearButton()
    {
        textAnswer.text = string.Empty;
    }
}

internal class Exercise
{
    private readonly int _a;
    private readonly int _b;

    public Exercise()
    {
        System.Random random = new System.Random();
        _a = random.Next(3, 10);
        _b = random.Next(3, 10);
    }

    public string StringPresent 
    { 
        get
        {
            return $"{_a} x {_b} = ";
        }
    }

    public bool CheckAnswer(string userAnswer)
    {
        if (!int.TryParse(userAnswer, out int result))
        {
            return false;
        }

        return _a * _b == result;
    }
}