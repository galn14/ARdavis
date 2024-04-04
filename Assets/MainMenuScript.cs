using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using NativeFilePickerNamespace;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    public TMP_Text pathText;

    // Start is called before the first frame update
    void Start()
    {
        string storedFilePath = PlayerPrefs.GetString("FilePath", string.Empty);
        if (!string.IsNullOrEmpty(storedFilePath))
        {
            Debug.Log($"File path loaded from PlayerPrefs: {storedFilePath}");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void keluar()
    {
        Debug.Log("Game Close");
        Application.Quit();
    }

    public void OpenFilePicker()
    {
        StartCoroutine(PickFileCoroutine());
    }

    public void goToNext()
    {
        SceneManager.LoadScene("NextMenu");
    }

    public void goToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private IEnumerator PickFileCoroutine()
    {
        // Request permission if not already granted
        if (NativeFilePicker.CheckPermission() != NativeFilePicker.Permission.Granted)
        {
            yield return NativeFilePicker.RequestPermission();
        }

        // Check again after permission request
        if (NativeFilePicker.CheckPermission() == NativeFilePicker.Permission.Granted)
        {
            // Ensure the file picker is not already busy
            if (!NativeFilePicker.IsFilePickerBusy())
            {

                NativeFilePicker.PickFile((path) =>
                {
                    if (!string.IsNullOrEmpty(path))
                    {
                        Debug.Log($"Selected file: {path}");
                        PlayerPrefs.SetString("FilePath", path);
                        pathText.text = path;
                        PlayerPrefs.Save();
                    }
                });
            }
        }
        else
        {
            Debug.LogWarning("Permission to access files was denied.");
        }
    }
}
