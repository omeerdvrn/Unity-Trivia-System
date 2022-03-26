using UnityEngine;

namespace TriviaSystem.Answer
{
    [System.Serializable]
    public class Answer
    {
        [TextArea]public string answerText = "";
        public bool correctness = false;
    }
}

