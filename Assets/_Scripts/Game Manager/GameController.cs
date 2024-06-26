using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : ZuMonoBehaviour
{
    [SerializeField] protected static GameController instance;
    public static GameController Instance => instance;

    [SerializeField] protected GameObject GameOverUI;
    public bool isGameOver = false;

    protected override void Awake()
    {
        base.Awake();
        if(instance == null)
        {
            GameController.instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadGameOverUI();
    }

    protected virtual void LoadGameOverUI()
    {
        if (this.GameOverUI != null) return;
        this.GameOverUI = GameObject.Find("Game Over UI");
        this.GameOverUI.SetActive(false);
        Debug.Log(transform.name + ": LoadGameOverUI", gameObject);
    }

    public virtual void GameOver()
    {
        this.isGameOver = true;
        StartCoroutine(GameOverDelay());
    }

    private IEnumerator GameOverDelay()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(3);
        yield return waitForSeconds;
        this.GameOverUI.SetActive(true);
    }
}
