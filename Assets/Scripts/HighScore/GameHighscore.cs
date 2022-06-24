using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace HighscoreModule
{

    [CreateAssetMenu(menuName = "HighScoreModule/GameHighScore")]
    public class GameHighscore : MongoDataObject
    {
        public HighScores scores;
        public delegate void HighscoreDelegate();
        public HighscoreDelegate onScoreFetched;

        public int scoresPerPage = 5;
        public int currentPage = 1;

        public override IEnumerator Refresh()
        {
            var request = connectionDetails.BuildGetFunctionRequest(functionName, 
                $"page={currentPage}&resultsPerPage={scoresPerPage}");

            UnityWebRequestAsyncOperation op = request.SendWebRequest();
            yield return new WaitUntil(() => op.isDone);
            Debug.Log($"HTTP Request /{functionName} completed : Status({request.responseCode})");

            SetHighscores(request.downloadHandler.text);
            onScoreFetched?.Invoke();
        }

        private void SetHighscores(string scoresjson)
        {
            scores = JsonConvert.DeserializeObject<HighScores>(scoresjson);
        }

        public void NextPage()
        {
            currentPage += 1;
            onChange?.Invoke(this);
        }

        public void PreviousPage()
        {
            currentPage -= 1;
            onChange?.Invoke(this);
        }
    }
}