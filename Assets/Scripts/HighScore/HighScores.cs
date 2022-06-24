using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace HighscoreModule
{
    [System.Serializable]
    public class HighScores
    {
        public Score[] scores;
        public int pages;
        public int current;
    }
}
