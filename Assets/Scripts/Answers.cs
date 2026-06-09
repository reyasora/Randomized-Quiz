using UnityEngine;

public class Answers : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;

    public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("Jawaban Benar!");
            quizManager.correctAnswer();
        }
        else
        {
            Debug.Log("Jawaban Salah!");
            quizManager.correctAnswer();
        }
    }
}
