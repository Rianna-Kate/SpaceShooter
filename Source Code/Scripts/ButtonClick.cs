using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ButtonClick : MonoBehaviour
{
    public UnityEngine.UI.Button startBtn;
    public UnityEngine.UI.Button instructionBtn;
    public UnityEngine.UI.Button backBtn;
    public UnityEngine.UI.Button quitBtn;
    
    void Start()
    {
        startBtn.onClick.AddListener(delegate { LoadScene("Main"); });
        instructionBtn.onClick.AddListener(delegate { LoadScene("Instructions"); });
        backBtn.onClick.AddListener(delegate { LoadScene("Start"); });
        quitBtn.onClick.AddListener(delegate {Application.Quit(); });
    }

    private void LoadScene(string sceneToLoad)
    {
        SceneManager.LoadScene("Scenes/" + sceneToLoad);
    }
}
