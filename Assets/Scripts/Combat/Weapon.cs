using RPG.Core;
using System.Collections;
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
        [SerializeField] Projectile projectile = null;

        const string weaponName = "Weapon";

        public void Spawn(Transform righthandTransform,Transform lefthandTransform, Animator animator)
        {
            DestroyOleWepaon(righthandTransform, lefthandTransform);

            if (equippedPrefab != null)
            {
                Transform handTransform;
                handTransform = GetTransform(righthandTransform, lefthandTransform);
                GameObject weapon = Instantiate(equippedPrefab, handTransform);
                weapon.name = weaponName;
            }
            if (animatorOverride != null)
            {
                animator.runtimeAnimatorController = animatorOverride;

            }
        }

        private static void DestroyOleWepaon(Transform righthandTransform, Transform lefthandTransform)
        {
            Transform oldWeapon = righthandTransform.Find(weaponName);
            if(oldWeapon == null)
            {
                oldWeapon = lefthandTransform.Find(weaponName);
            }
            if (oldWeapon == null)
                return;
            oldWeapon.name = "DESTROYING";
            Destroy(oldWeapon.gameObject);
        }

        private Transform GetTransform(Transform righthandTransform, Transform lefthandTransform)
        {
            return isRightHanded ? righthandTransform : lefthandTransform;
        }

        public bool HasProjectile()
        {
            return projectile != null;
        }

        public void LanchProjectile(Transform righthand, Transform lefthand, Health target)
        {
            Projectile projectileInstance = Instantiate(projectile, GetTransform(righthand, lefthand).position, Quaternion.identity);
            projectileInstance.SetTarget(target, weaponDamage);
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