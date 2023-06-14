using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


// 태어날 때 점수를 0점으로 하고싶다. UI로도 표현하고싶다.
// 적이 총알과 부딪혔다면 점수를 1점 증가시키고싶다.

// 태어날 때 최고점수를 읽어오고싶다. UI로도 표현하고싶다.
// 점수가 갱신될때 만약 최고점수보다 크다면 최고점수를 갱신된점수로 바꾸고 저장하고싶다.
public class ScoreManager : MonoBehaviour
{
    readonly string saveKey = "HIGH_SCORE";

    public static ScoreManager instance;

    private void Awake()
    {
        instance = this;
    }


    public TextMeshProUGUI textScore;
    int score;

    public TextMeshProUGUI textHighScore;
    int highScore;

    // Start is called before the first frame update
    void Start()
    {
        // 태어날 때 점수를 0점으로 하고싶다. UI로도 표현하고싶다.
        SCORE = 0;

        // 태어날 때 최고점수를 읽어오고싶다. UI로도 표현하고싶다.
        HIGH_SCORE = PlayerPrefs.GetInt(saveKey, 0);
    }

    public int HIGH_SCORE
    {
        get { return highScore; }
        set
        {
            highScore = value;
            textHighScore.text = "HighScore : " + highScore;
        }
    }

    public int SCORE
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            textScore.text = "Score : " + score;
            // 1. 만약 score가 highScore보다 크다면
            if (score > HIGH_SCORE)
            {
                // 2. highScore에 score를 대입하고싶다.
                HIGH_SCORE = score;
                // 3. 저장하고 싶다.
                PlayerPrefs.SetInt(saveKey, HIGH_SCORE);

            }
        }
    }

    public void SetScore(int value)
    {
        score = value;
        textScore.text = "Score : " + score;
    }
    public int GetScore()
    {
        return score;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
