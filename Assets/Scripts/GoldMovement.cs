using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GoldMovement : MonoBehaviour
{
    private GameObject player;
    private int value = 45;
    private Tweener hoopTween;
    private float distance = 100;
    void Start()
    {
        player = GameObject.Find("Player");
        hoopTween = transform.DORotate(new Vector3(0, 360, 0), 0.5f).SetLoops(-1,LoopType.Yoyo);
    }

    private void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < 10f)
        {
            hoopTween.Kill();
            transform.DOMove(player.transform.position, 0.5f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().GetMoney(value);
            Destroy(gameObject);
        }
    }
}
