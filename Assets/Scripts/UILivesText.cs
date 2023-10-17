using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UILivesText : MonoBehaviour
{
    private TMP_Text tmproText;

    private void Awake()
    {
        tmproText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        tmproText.SetText($"x {GameManager.Instance.Lives.ToString()}");
    }
}
