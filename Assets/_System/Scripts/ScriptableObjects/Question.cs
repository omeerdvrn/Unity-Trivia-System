using System.Collections.Generic;
using TriviaSystem.Answer;
using UnityEngine;

[CreateAssetMenu( menuName = "TriviaSystem/Create Question",fileName = "New Question")]
[System.Serializable]
public class Question : ScriptableObject
{
    [TextArea]
    public string questionText;
    public List<Answer> answers = new List<Answer>();
    
    public Answer GetCorrectAnswer()
    {
        if (answers.Count == 0)
            return null;
        Answer correct = null;
        foreach (var ans in answers)
        {
            if (ans.correctness)
                correct = ans;
        }
        return correct;
    }
}
