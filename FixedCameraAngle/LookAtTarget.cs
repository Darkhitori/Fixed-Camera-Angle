using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KreliStudio;


namespace Darkhitori.PlaymakerActions._FixedCameraAngle
{
    using HutongGames.PlayMaker;

    [ActionCategory("FixedCameraAngle")]
    [Tooltip("If true camera allways look at target")]
    public class LookAtTarget : FsmStateAction
    {
        [RequiredField]
        [CheckForComponent(typeof(CameraSocket))]
        public FsmOwnerDefault gameObject;
        
        public FsmBool lookAtTarget;
        
        [Tooltip("Repeat every frame while the state is active.")]
        public bool everyFrame;
        
        CameraSocket camComp;
        
        public override void Reset()
        {
            gameObject = null;
            lookAtTarget = false;
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
            
            camComp.lookAtTarget = lookAtTarget.Value;
        }


    }

}
