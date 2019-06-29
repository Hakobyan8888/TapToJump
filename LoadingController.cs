using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingController : MonoBehaviour {

    public GameObject LoadingScreenObj;
    public Slider slider;

    public GameObject Button;

    AsyncOperation async;

    public void LaodScreenExample(string LVL)
    {
        StartCoroutine(LoadingScreen(LVL));
        Button.SetActive(false);
    }

    IEnumerator LoadingScreen(string lvl)
    {
        LoadingScreenObj.SetActive(true);
        async = SceneManager.LoadSceneAsync(lvl);
        async.allowSceneActivation = false;

        while(async.isDone == false)
        {
            slider.value = async.progress;
            if (async.progress == 0.01f)
            {
                slider.value = 0.02f;
                async.allowSceneActivation = true;
            }
            if (async.progress == 0.03f)
            {
                slider.value = 0.04f;
                async.allowSceneActivation = true;
            }
            if (async.progress == 0.06f)
            {
                slider.value = 0.08f;
                async.allowSceneActivation = true;
            }
            if (async.progress == 0.09f)
            {
                slider.value = 0.1f;
                async.allowSceneActivation = true;
            }
            if (async.progress == 0.15f)
            {
                slider.value = 0.2f;
                async.allowSceneActivation = true;
            }
            if (async.progress == 0.25f)
            {
                slider.value = 0.3f;
                async.allowSceneActivation = true;
            }
            if (async.progress == 0.35f)
            {
                slider.value = 0.4f;
                async.allowSceneActivation = true;
            }
            if (async.progress == 0.45f)
            {
                slider.value = 0.5f;
                async.allowSceneActivation = true;
            }
            if (async.progress == 0.55f)
            {
                slider.value = 0.6f;
                async.allowSceneActivation = true;
            }
            if (async.progress == 0.75f)
            {
                slider.value = 0.8f;
                async.allowSceneActivation = true;
            }
            if (async.progress == 0.85f)
            {
                slider.value = 0.9f;
                async.allowSceneActivation = true;
            }
            if (async.progress == 0.9f)
            {
                slider.value = 1f;
                async.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
