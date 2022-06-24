using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

namespace HighscoreModule
{

    public class HighscoreUI : MonoBehaviour
    {
        [SerializeField] private GameHighscore _score;
        [SerializeField] private GameObject _loader;
        [SerializeField] private GameObject _scoreList;
        [SerializeField] private ObjectPool _scoreElementPool;

        [SerializeField] private GameEventBase onScoreListPopulated;

        private void OnEnable()
        {
            _score.onScoreFetched += PopulateScores;
        }

        private void OnDisable()
        {
            _score.onScoreFetched -= PopulateScores;
        }

        public void OnViewDisplayed()
        {
            StartCoroutine(_score.Refresh());
        }

        public void OnViewHidden()
        {
            _loader.SetActive(true);
            _scoreList.SetActive(false);
        }

        private void PopulateScores()
        {
            //Wtf gotta fix this pointer
            for (int i = 0; i < _score.scores.scores.Length; i++)
            {
                var ob = _scoreElementPool.GetPooledObject();
                ob.GetComponent<ScoreElementUI>()
                    .SetScoreDetails(i + 1 + (_score.scoresPerPage * (_score.currentPage-1)), _score.scores.scores[i]);
            }

            onScoreListPopulated.Raise();
        }
    }
}
