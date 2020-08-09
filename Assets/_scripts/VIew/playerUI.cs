using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class playerUI : MonoBehaviour
{
    _playerAttributes playerAttributes;
    TextMeshPro textHP;
    TextMeshPro textDMG;
    TextMeshPro textCurrentEnemyHP;


    private void Start()
    {
        playerAttributes = GameObject.FindGameObjectWithTag("Player").GetComponent<_playerAttributes>();
    }
    

    void frameUI()
    {
        setHPUI();
    }
void setHPUI()
    {
        textHP.text = playerAttributes.hp.ToString();
    }
       
}
