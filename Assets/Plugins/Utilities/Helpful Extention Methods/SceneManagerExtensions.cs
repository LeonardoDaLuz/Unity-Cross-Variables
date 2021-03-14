using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagerExtension : MonoBehaviour
{
    /// <summary>
    /// Compare if this layerNumber is in layermask
    /// </summary>
    /// <param name="mask"></param>
    /// <param name="layer"></param>
    /// <returns></returns>

    public static GameObject fadeCanvas;
    public static void LoadSceneWithFades(string sceneName, float duration)
    {
        if (fadeCanvas == null)
        {
            fadeCanvas = (GameObject)Instantiate((GameObject)FileUtility.LoadFile("FadeCanvasPrefab"), Vector2.zero, Quaternion.identity);
        }
        fadeCanvas.SetActive(true);
        Image blackImage = fadeCanvas.GetComponentInChildren<Image>();
        blackImage.SetAlpha(0f);
        blackImage.StartCoroutine(LoadSceneWithFadesCo(blackImage, sceneName, duration));
    }

    private static IEnumerator LoadSceneWithFadesCo(Image blackImage, string sceneName, float duration)
    {
        DontDestroyOnLoad(fadeCanvas);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        asyncLoad.allowSceneActivation = false;
        yield return blackImage.FadeIn(duration);
        Time.timeScale = 1f;
        asyncLoad.allowSceneActivation = true;
        while (!asyncLoad.isDone)
        {
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForEndOfFrame();
        yield return new WaitForFixedUpdate();
        yield return blackImage.FadeOut(duration);
        fadeCanvas.SetActive(false);

    }

    public static void FadeInCallAndFadeOut(MonobehaviourMethods.GenericMethod CallOnBlackScreen, float duration)
    {
        if (fadeCanvas == null)
        {
            fadeCanvas = (GameObject)Instantiate((GameObject)FileUtility.LoadFile("FadeCanvasPrefab"), Vector2.zero, Quaternion.identity);
        }
        fadeCanvas.SetActive(true);
        Image blackImage = fadeCanvas.GetComponentInChildren<Image>();
        blackImage.SetAlpha(0f);
        Time.timeScale = 1f;
        blackImage.StartCoroutine(FadeToSameSceneCo(blackImage, CallOnBlackScreen, duration));
    }

    private static IEnumerator FadeToSameSceneCo(Image blackImage, MonobehaviourMethods.GenericMethod CallOnBlackScreen, float duration)
    {
        yield return blackImage.FadeIn(duration);
        CallOnBlackScreen();
        yield return blackImage.FadeOut(duration);
        Time.timeScale = 1f;
        fadeCanvas.SetActive(false);
    }
}