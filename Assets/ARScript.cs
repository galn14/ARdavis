using System.Collections;
using System.Collections.Generic;
using IATK;
using UnityEngine;
using System;
using Vuforia;
using TMPro;

public class ARScript : MonoBehaviour
{

    public TMP_Text indicator;


    private GameObject visuObject;

    void Awake()
    {
        visuObject = CreateGraph();
    }

    void Start()
    {
        SwapModel();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SwapModel()
    {

    }

    GameObject CreateGraph()
    {
        string csvPath = PlayerPrefs.GetString("FilePath");
        string xDimension = PlayerPrefs.GetString("dropdownX");
        string yDimension = PlayerPrefs.GetString("dropdownY");
        string zDimension = PlayerPrefs.GetString("dropdownZ");

        GameObject container = GameObject.Find("VisualisationContainer");

        GameObject visualizationObject = new GameObject("ScatterplotVisualization");

        ScatterplotVisualisation visu = visualizationObject.AddComponent<ScatterplotVisualisation>();

        visualizationObject.transform.SetParent(container.transform);

        CSVDataSource dataSource = visualizationObject.AddComponent<CSVDataSource>();
        dataSource.LoadFromFile(csvPath);
        Visualisation davis = visualizationObject.AddComponent<Visualisation>();

        davis.dataSource = dataSource;
        davis.xDimension.Attribute = xDimension;
        davis.yDimension.Attribute = yDimension;
        davis.zDimension.Attribute = zDimension;
        davis.size = 1;
        davis.geometry = AbstractVisualisation.GeometryType.Points;

        visu.visualisationReference = davis;

        visu.CreateVisualisation();
        visu.UpdateVisualisationAxes(AbstractVisualisation.PropertyType.X);
        visu.UpdateVisualisationAxes(AbstractVisualisation.PropertyType.Y);
        visu.UpdateVisualisationAxes(AbstractVisualisation.PropertyType.Z);
        visu.UpdateVisualisationAxes(AbstractVisualisation.PropertyType.Scaling);

        for (int i = 0; i < visualizationObject.transform.childCount; i++)
        {
            Transform child = visualizationObject.transform.GetChild(i);
            child.gameObject.SetActive(true);
        }

        visualizationObject.SetActive(true);


        indicator.text = visu.X_AXIS.ToString();

        return container;

    }
}
