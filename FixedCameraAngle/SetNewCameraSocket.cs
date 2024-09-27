using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KreliStudio;


namespace Darkhitori.PlaymakerActions._FixedCameraAngle
{
    using HutongGames.PlayMaker;

    [ActionCategory("FixedCameraAngle")]
    [Tooltip("")]
    public class SetNewCameraSocket : FsmStateAction
    {
        [RequiredField]
        [CheckForComponent(typeof(CameraController))]
        public FsmOwnerDefault gameObject;
        
        [ObjectType(typeof(CameraSocket))]
        public FsmObject cameraSocket;
        
        [Tooltip("Repeat every frame while the state is active.")]
        public bool everyFrame;
        
        CameraController camComp;
        
        public override void Reset()
        {
            gameObject = null;
            cameraSocket = null;
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
            
            camComp = go.GetComponent<CameraController>();
            
            camComp.SetNewCameraSocket((CameraSocket)cameraSocket.Value);
        }


    }

}
