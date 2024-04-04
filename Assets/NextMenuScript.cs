using System.Collections;
using System.Collections.Generic;
using IATK;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextMenuScript : MonoBehaviour
{

    public TMP_Text pathText;
    public TMP_Dropdown dropdownX;
    public TMP_Dropdown dropdownY;
    public TMP_Dropdown dropdownZ; 

    private List<string> dimensions;

    // Start is called before the first frame update
    void Start()
    {
        string storedFilePath = PlayerPrefs.GetString("FilePath", string.Empty);
        pathText.text = storedFilePath;

        string csvPath = PlayerPrefs.GetString("FilePath");
        CSVDataSource dataSource = gameObject.AddComponent<CSVDataSource>();
        dataSource.LoadFromFile(csvPath);

        // Get the available dimensions
        dimensions = new List<string>();
        for (int i = 0; i < dataSource.DimensionCount; i++)
        {
            dimensions.Add(dataSource[i].Identifier);
        }

        // Populate the dropdown menus
        dropdownX.ClearOptions();
        dropdownX.AddOptions(dimensions);

        dropdownY.ClearOptions();
        dropdownY.AddOptions(dimensions);

        dropdownZ.ClearOptions();
        dropdownZ.AddOptions(dimensions);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void goToAR()
    {
        string xDimension = dropdownX.options[dropdownX.value].text;
        string yDimension = dropdownY.options[dropdownY.value].text;
        string zDimension = dropdownZ.options[dropdownZ.value].text;

        PlayerPrefs.SetString("dropdownX", xDimension);
        PlayerPrefs.SetString("dropdownY", yDimension);
        PlayerPrefs.SetString("dropdownZ", zDimension);

        PlayerPrefs.Save();

        SceneManager.LoadScene("datavisual");
    }

    public void ResetButton() {
        dropdownX.value  = 0;
        dropdownY.value  = 0;
        dropdownZ.value  = 0;
    }
}
