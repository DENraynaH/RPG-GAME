using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image playerPanel;
    public Image targetPanel;

    public Image targetResource;
    public Image targetHealth;

    public Image playerResource;
    public Image playerHealth;

    public TextMeshProUGUI targetText;

    public static UIManager Instance;

    private void Start()
    {
        Instance = this;

        playerPanel.gameObject.SetActive(true);
        targetPanel.gameObject.SetActive(false);
    }

}
