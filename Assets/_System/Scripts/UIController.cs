using System.Collections.Generic;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.Collections.Generic;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace TriviaSystem
{
    [System.Serializable]
    public class UIController : MonoBehaviour
    {
        #region Singleton
    
        private static UIController _instance;
        public static UIController GetInstance()
        {
            return _instance;
        }
    
        #endregion
        
        #region Variables
    
        [SerializeField] private GameObject _questionPanel;
        [SerializeField] private TMP_Text _questionText;
        [SerializeField] private List<Button> _buttons;
        public UDictionary<Button, Answer.Answer> buttonData;
        
        #endregion
        
        private void Awake()//Contains singleton parts
        {
            if (_instance == null)
            {
                _instance = this;
            }
        }
        
        public void SetTriviaPanel(bool flag)
        {
            _questionPanel.SetActive(flag);
        }
    
        public void ShowCurrentTriviaData(Question q)
        {
            SetButtonData(q);
            _questionText.text = q.questionText;
            foreach (var btn in _buttons)
            {
                btn.GetComponentInChildren<TMP_Text>().text = buttonData[btn].answerText;
            }
        }
    
        [Button("Shuffle")]
        public void ShuffleButtons()
        {
            if (_buttons.Count <= 0)
                return;
            
            List<Button> list = new List<Button>();
            for (int i = 0; i < _buttons.Count; i++)
            {
                list.Add(_buttons[i]);
            }
            
            _buttons.Clear();
            var count = list.Count;
            for (var i = 0; i < count; i++)
            {
                var x = Random.Range(0, list.Count - 1);
                _buttons.Add(list[x]);
                list.Remove(list[x]);
            }
            TriviaController.GetInstance().UpdateAndShowNextQuestionData();
        }
        
        private void SetButtonData(Question q)
        {
            buttonData = new UDictionary<Button, Answer.Answer>();
            for (int i = 0; i < _buttons.Count; i++)
            {
                buttonData.Add(_buttons[i], q.answers[i]);
            }
        }
    
    }
}

