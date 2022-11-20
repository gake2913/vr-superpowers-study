using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public Animator FadeToBlackAnimator;
    public float SwitchSceneDelay = 1f;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame) StartCoroutine(SwitchScene("Sorting_NoPower_Prep"));
        if (Keyboard.current.digit2Key.wasPressedThisFrame) StartCoroutine(SwitchScene("Sorting_NormalPower_Prep"));
        if (Keyboard.current.digit3Key.wasPressedThisFrame) StartCoroutine(SwitchScene("Sorting_WrongPower_Prep"));
        if (Keyboard.current.qKey.wasPressedThisFrame) StartCoroutine(SwitchScene("Train_NoPower_Prep"));
        if (Keyboard.current.wKey.wasPressedThisFrame) StartCoroutine(SwitchScene("Train_NormalPower_Prep"));
        if (Keyboard.current.eKey.wasPressedThisFrame) StartCoroutine(SwitchScene("Train_WrongPower_Prep"));

        if (Keyboard.current.spaceKey.wasPressedThisFrame) StartCoroutine(SwitchScene(SceneManager.GetActiveScene().name.Replace("Prep", "Task")));

        if (Keyboard.current.escapeKey.wasPressedThisFrame) Application.Quit();
    }

    private IEnumerator SwitchScene(string sceneName)
    {
        Logger.CreateLog("");
        Logger.CreateLog("Loading Scene: " + sceneName, this);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        asyncLoad.allowSceneActivation = false;

        FadeToBlackAnimator.SetTrigger("Fade");

        float timer = 0;
        float lastProgress = -1;
        while (timer < SwitchSceneDelay)
        {
            yield return new WaitForEndOfFrame();
            timer += Time.deltaTime;

            float progress = asyncLoad.progress;
            if (progress > lastProgress)
                Logger.CreateLog("Scene Loading Progress: " + (progress * 100) + "%", this);
            lastProgress = progress;
        }
        
        while (!asyncLoad.isDone)
        {
            if (asyncLoad.progress >= 0.9f) asyncLoad.allowSceneActivation = true;

            yield return null;

            Logger.CreateLog("Scene Loading Progress: " + (asyncLoad.progress * 100) + "%", this);
        }

        Logger.CreateLog("Scene Loading done.", this);
        Logger.CreateLog("");

        FadeToBlackAnimator.SetTrigger("Fade");
    }
}
