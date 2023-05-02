using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FinisherFigureSpawner : MonoBehaviour
{
   [SerializeField] private Transform spawnPoint;
   [SerializeField] private GameObject[] figures;

   private void Awake()
   {
      Instantiate(figures[Random.Range(0, figures.Length)], spawnPoint);
   }
}
