using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Include the TextMeshPro namespace

public class TimeGreeting : MonoBehaviour
{
    public TextMeshProUGUI greetingText; // Reference to the TextMeshProUGUI component

    void Start()
    {
        UpdateGreeting();
    }

    void UpdateGreeting()
    {
        // Get the current hour of the day (24-hour format)
        int hour = System.DateTime.Now.Hour;

        // Determine the appropriate greeting based on the current time
        if (hour >= 6 && hour < 12)
        {
            greetingText.text = "Good Morning";
        }
        else if (hour >= 12 && hour < 18)
        {
            greetingText.text = "Good Afternoon";
        }
        else
        {
            greetingText.text = "Good Evening";
        }
    }
}

