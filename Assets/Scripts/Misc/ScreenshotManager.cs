using UnityEngine;
using System.IO;
using System.Collections;

public class ScreenshotManager : MonoBehaviour
{
    [Header("Debug Mode")]
    public bool allowKeyboardScreenshot = true;
    public KeyCode screenshotKey = KeyCode.P;

    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        if (allowKeyboardScreenshot && Input.GetKeyDown(screenshotKey))
        {
            StartCoroutine(CaptureScreenshot());
        }
#endif
    }

    public void TakeScreenshot()
    {
        StartCoroutine(CaptureScreenshot());
    }

    private IEnumerator CaptureScreenshot()
    {
        yield return new WaitForEndOfFrame();

        string timestamp = System.DateTime.Now.ToString("yyyyMMdd_HHmmss");
        string filename = "screenshot_" + timestamp + ".png";

#if UNITY_ANDROID
        string path = Path.Combine(Application.persistentDataPath, filename);
#else
        string path = Path.Combine(Application.dataPath, filename);
#endif

        ScreenCapture.CaptureScreenshot(path);
        Debug.Log("Screenshot saved to:" + path);
    }
}
