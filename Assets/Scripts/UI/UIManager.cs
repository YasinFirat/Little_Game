using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public UIManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
      
    }
    private void Start()
    {

        GameManager.instance.whenFinish.AddListener(NewGame);
        Time.timeScale = 0;
    }
    /// <summary>
    /// Aynı sahne tekrar çağrılır.
    /// </summary>
    public void NewGame()
    {
        StartCoroutine(NewGameEnumerator());
    }
    IEnumerator NewGameEnumerator()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void StartGame()
    {
        Time.timeScale = 1;
    }
}
