using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music_skript : MonoBehaviour
{
   private void Awake() 
   {
    DontDestroyOnLoad(transform.gameObject); 
   }
}
