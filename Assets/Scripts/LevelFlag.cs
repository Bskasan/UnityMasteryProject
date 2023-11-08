using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFlag : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.MoveToNextLevel();
    }
}
