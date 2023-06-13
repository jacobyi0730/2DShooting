using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


// 태어날 때 점수를 0점으로 하고싶다. UI로도 표현하고싶다.
// 적이 총알과 부딪혔다면 점수를 1점 증가시키고싶다.
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    private void Awake()
    {
        instance = this;
    }


    public TextMeshProUGUI textScore;
    int score;
    // Start is called before the first frame update
    void Start()
    {
        // 태어날 때 점수를 0점으로 하고싶다. UI로도 표현하고싶다.
        SCORE = 0;
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
