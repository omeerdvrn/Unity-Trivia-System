using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.UI;

namespace TriviaSystem
{
    using NaughtyAttributes;
        public class TriviaController : MonoBehaviour
        {
            #region Singleton
        
            private static TriviaController _instance;
            public static TriviaController GetInstance()
            {
                return _instance;
            }
        
            #endregion
        
            #region Variables
        
            [SerializeField] private List<Question> _questionList = new List<Question>();
            [SerializeField] private IntEvent OnSelectedCorrect, OnSelectedWrong;
            [SerializeField] [Range(0, 10)] private int _correctValue, _wrongValue;
            private int _nextQuestionID = 0;
            public Question currentQuestion;
            #endregion
        
            
            private void Awake()//Contains singleton parts.
            {
                if (_instance == null)
                {
                    _instance = this;
                }
            }
        
            private void Start()
            {
                UpdateAndShowNextQuestionData();
            }
         
            [Button("Next")]
            public void UpdateAndShowNextQuestionData()
            {
                if (_nextQuestionID >= _questionList.Count)
                {
                    Debug.LogWarning($"There is no more question data to show.");
                    return;
                }
                    
                currentQuestion = _questionList[_nextQuestionID];
                UIController.GetInstance().ShowCurrentTriviaData(currentQuestion);
                _nextQuestionID++;
            }
        
            public void Select(Button btn)
            {
                bool b = CheckIfButtonCorrect(btn);
                if (b)
                {
                    OnSelectedCorrect.Raise(_correctValue);
                    Debug.Log("Correct");
                }
                else
                {
                    OnSelectedWrong.Raise(_wrongValue);
                    Debug.Log("Wrong");
                }
            }
            private bool CheckIfButtonCorrect(Button btn)
            {
                return UIController.GetInstance().buttonData[btn].correctness;
            }
            
        }

}
