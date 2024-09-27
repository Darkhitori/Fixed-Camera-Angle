using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KreliStudio;


namespace Darkhitori.PlaymakerActions._FixedCameraAngle
{
    using HutongGames.PlayMaker;

    [ActionCategory("FixedCameraAngle")]
    [Tooltip("Player or something what you want to follow")]
    public class Target : FsmStateAction
    {
        [RequiredField]
        [CheckForComponent(typeof(CameraSocket))]
        public FsmOwnerDefault gameObject;
        
        public FsmGameObject target;
        
        [Tooltip("Repeat every frame while the state is active.")]
        public bool everyFrame;
        
        CameraSocket camComp;
        
        public override void Reset()
        {
            gameObject = null;
            target = null;
            everyFrame = false;
        }

        // Code that runs on entering the state.
        public override void OnEnter()
        {
            DoMethod();
            if (!everyFrame)
            {
                Finish();
            }
        }
        
        public override void OnUpdate()
        {
            DoMethod();
        }

        
        void DoMethod()
        {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            if(go == null)
            {
                return;
            }
            
            camComp = go.GetComponent<CameraSocket>();
            
            camComp.target = target.Value.transform;
        }


    }

}
