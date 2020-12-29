using TMPro;
using UnityEngine;

public class ScorePanel : MonoBehaviour
{
    public TMP_Text ScoreText;

    public int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = $"Score: {score}";
    }
}
