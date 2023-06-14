using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 태어날 때 GameOverUI를 비활성화 하고싶다.
// 플레이어의 체력이 0이 될 때 GameOverUI를 활성화 하고싶다.
// Restart 버튼을 누르면 재시작 하고싶다.
// Quit 버튼을 누르면 종료 하고싶다.
public class GameManager : MonoBehaviour
{
    // 싱글톤으로 만들어 보세요!
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }

    public GameObject gameOverUI;
    // Start is called before the first frame update
    void Start()
    {
        // 태어날 때 GameOverUI를 비활성화 하고싶다.
        gameOverUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Restart 버튼을 누르면 재시작 하고싶다.
    public void OnMyRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    // Quit 버튼을 누르면 종료 하고싶다.
    public void OnMyQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }
}
