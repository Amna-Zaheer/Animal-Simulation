using System.Linq;
using UnityEngine;

public class ScoreUi : MonoBehaviour
{
    public RowUi rowUI;
    public ScoreManager scoreManager;
    private void Start()
    { 
        var scores = scoreManager.GetHighScores().ToArray();
        for (int i = 0; i < scores.Length; i++)
        {
            var row = Instantiate(rowUI, transform).GetComponent<RowUi>();
            row.row.text = (i + 1).ToString();
            row.nam.text = scores[i].nam;
            row.score.text = scores[i].score.ToString();
        }
    }
}