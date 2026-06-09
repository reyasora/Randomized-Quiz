using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public List<Quiz> quizzes;
    public int currentQuizIndex;

    public GameObject[] options;
    public TextMeshProUGUI questionText;

    private void Start()
    {
        quizQuestionGenerate();
    }

    public void correctAnswer()
    {
        quizzes.RemoveAt(currentQuizIndex);
        quizQuestionGenerate();
    }

    void changeAnswers()
    {

        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Answers>().isCorrect = false;
        }

        List<int> answerIndexes = new List<int>();

        for (int i = 0; i < quizzes[currentQuizIndex].answers.Length; i++)
        {
            answerIndexes.Add(i);
        }

        for (int i = 0; i < answerIndexes.Count; i++)
        {
            int randomIndex = Random.Range(i, answerIndexes.Count);

            int value = answerIndexes[i];
            answerIndexes[i] = answerIndexes[randomIndex];
            answerIndexes[randomIndex] = value;
        }

        for (int i = 0; i < options.Length; i++)
        {
            int answerIndex = answerIndexes[i];

            options[i].transform.GetChild(0)
                .GetComponent<TextMeshProUGUI>().text =
                quizzes[currentQuizIndex].answers[answerIndex];

            if (answerIndex == quizzes[currentQuizIndex].correctAnswerIndex - 1)
            {
                options[i].GetComponent<Answers>().isCorrect = true;
            }
        }
    }

    void quizQuestionGenerate()
    {
        if (quizzes.Count > 0)
        {
            currentQuizIndex = Random.Range(0, quizzes.Count);

            questionText.text = quizzes[currentQuizIndex].question;

            changeAnswers();
        }
        else
        {
            Debug.Log("Soal habis");
        }
    }
}



