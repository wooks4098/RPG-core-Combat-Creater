﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RPG.Combat
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Weapons/Make New Weapon",order =0)]
    public class Weapon : ScriptableObject
    {
        [SerializeField] AnimatorOverrideController animatorOverride = null;
        [SerializeField] GameObject equippedPrefab = null;
        [SerializeField] float weaponDamage = 5f;
        [SerializeField] float weaponRange = 1.5f;
        [SerializeField] bool isRightHanded = true;

        public void Spawn(Transform righthandTransform,Transform lefthandTransform, Animator animator)
        {
            if(equippedPrefab != null)
            {
                Transform handTransform;
                handTransform = isRightHanded ? righthandTransform : lefthandTransform ;
                Instantiate(equippedPrefab, handTransform);

            }
            if (animatorOverride != null)
            {
                animator.runtimeAnimatorController = animatorOverride;

            }
        }


        public float GetDamage()
        {
            return weaponDamage;
        }

        public float GetRange()
        {
            return weaponRange;
        }
    }
}