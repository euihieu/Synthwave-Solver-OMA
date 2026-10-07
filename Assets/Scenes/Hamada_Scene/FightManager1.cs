// using UnityEngine;
// using System.Collections;

// public class FightManager : MonoBehaviour
// {
//     // This script handles the fight mechanics
//     public bool isFighting { get; private set; }
//     private float timer = 5;

//     public static FightManager instance { get; private set; }


//     ///////////////////////////////////////////////////////
//     ///////////////////////////////////////////////////////
//     private void Awake()
//     {
//         instance = this;
//     }

//     private void Start()
//     {
//         isFighting = false;
//     }
//     ///////////////////////////////////////////////////////
//     ///////////////////////////////////////////////////////


//     public void fight()
//     {
//         if (!isFighting)
//         {
//             isFighting = true;
//         }

//         StartCoroutine(fightCR());
//         Debug.Log("Fight started");
//     }

//     public IEnumerator fightCR()
//     {
//         Debug.Log("isFighting");
//         yield return new WaitForSeconds(timer);
//         isFighting = false;
//     }

//     public void EndFight()
//     {
//         StopCoroutine(fightCR());
//         isFighting = false;
//     }
// }
