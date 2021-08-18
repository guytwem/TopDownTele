using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TopDown.Abilities;
using UnityEngine.Serialization;

namespace TopDown.Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        public Camera cam;
        public NavMeshAgent agent;

        [FormerlySerializedAs("s_SelectAbility")] public SelectAbility sSelectAbility;
        
        [SerializeField] private List<int> characterAbilities = new List<int>();
        
        void Update()
        {
            if (Input.GetMouseButton(0))
            {
               Ray ray = cam.ScreenPointToRay(Input.mousePosition);
               RaycastHit hit;
               if(Physics.Raycast(ray, out hit))
               {
                   Debug.Log(hit);
                   agent.SetDestination((hit.point));
               }
               
                
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                sSelectAbility.charAbilities[characterAbilities[0]].TriggerAbility();
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                sSelectAbility.charAbilities[characterAbilities[1]].TriggerAbility();
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                sSelectAbility.charAbilities[characterAbilities[2]].TriggerAbility();
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                sSelectAbility.charAbilities[characterAbilities[3]].TriggerAbility();
            }


        }

        void AddAbility(int abilityIndex)
        {
            characterAbilities.Add(abilityIndex);
        }

        void RemoveAbility(int abilityIndex)
        {
            for (int i = 0; i < characterAbilities.Count; i++)
            {
                if (characterAbilities[i] == abilityIndex)
                {
                    characterAbilities.Remove(i);
                    return;
                    
                }
            }
        }
    }
}

    


