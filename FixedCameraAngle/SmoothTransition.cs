using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KreliStudio;


namespace Darkhitori.PlaymakerActions._FixedCameraAngle
{
    using HutongGames.PlayMaker;

    [ActionCategory("FixedCameraAngle")]
    [Tooltip("If true the camera does not jump between new camera socket but move smoothly beetwen this current position to new camera socket")]
    public class SmoothTransition : FsmStateAction
    {
        [RequiredField]
        [CheckForComponent(typeof(CameraSocket))]
        public FsmOwnerDefault gameObject;
        
        public FsmBool smoothTransition;
        
        [Tooltip("Repeat every frame while the state is active.")]
        public bool everyFrame;
        
        CameraSocket camComp;
        
        public override void Reset()
        {
            gameObject = null;
            smoothTransition = false;
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
            
            camComp.smoothTransition = smoothTransition.Value;
        }


    }

}
