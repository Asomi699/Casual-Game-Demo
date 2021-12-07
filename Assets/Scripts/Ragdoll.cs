using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
   [SerializeField] private Player _player;
   
   [SerializeField] private List<Rigidbody> _bodyParts;
   [SerializeField] private GameObject _skeleton;

   private void OnEnable()
   {
      _player.Fail += OnFall;
   }

   public void OnFall()
   {
      GetComponentInChildren<Animator>().enabled = false;
      _skeleton.SetActive(true);
      
      foreach (var rigidbody in _bodyParts)
      {
         rigidbody.useGravity = true;
         rigidbody.isKinematic = false;
      }
      
      _player.Fail -= OnFall;
   }
}
