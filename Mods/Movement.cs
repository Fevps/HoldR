using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.UI;
using GorillaLocomotion;
using Rift.Classes;
using Photon.Pun;
using static NetworkSystem;
using UnityEngine.Animations.Rigging;

namespace Rift.Menu
{
    internal class Movement
    {
        public static void FlickJump()
        {
            if (ControllerInputPoller.instance.leftGrab || Mouse.current.leftButton.isPressed)
            {
                Player.Instance.leftControllerTransform.transform.position = GorillaTagger.Instance.leftHandTransform.position + new Vector3(0f, -1.85f, 0f);
            }
            if (ControllerInputPoller.instance.rightGrab || Mouse.current.rightButton.isPressed)
            {
                Player.Instance.rightControllerTransform.transform.position = GorillaTagger.Instance.rightHandTransform.position + new Vector3(0f, -1.85f, 0f);
            }
        }

        public static void PlayspaceMovement()
        {
            if (ControllerInputPoller.instance.leftGrab || Mouse.current.leftButton.isPressed)
            {
                Player.Instance.transform.position += GorillaTagger.Instance.bodyCollider.transform.forward * Time.deltaTime * -0.25f;
                Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
            if (ControllerInputPoller.instance.rightGrab || Mouse.current.rightButton.isPressed)
            {
                Player.Instance.transform.position += GorillaTagger.Instance.bodyCollider.transform.forward * Time.deltaTime * 0.25f;
                Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }

        public static void SlingshotYourself()
        {
            if (ControllerInputPoller.instance.leftGrab || Mouse.current.leftButton.isPressed)
            {
                Player.Instance.GetComponent<Rigidbody>().velocity += Player.Instance.headCollider.transform.forward * Time.deltaTime * Variables.flySpeed * 4.5f;
            }
        }

        public static bool left = false;
        public static bool right = false;
        public static void AutoRun()
        {
            if (!left && ControllerInputPoller.instance.rightGrab || !left && Mouse.current.rightButton.isPressed)
            {
                Vector3 runPosition = CalculatePreferredPosition();
                GorillaTagger.Instance.rightHandTransform.position = runPosition;
                right = true;
            }
            else { right = false; }
            if (!right && ControllerInputPoller.instance.leftGrab || !right && Mouse.current.leftButton.isPressed)
            {
                Vector3 runPosition = CalculatePreferredPosition();
                GorillaTagger.Instance.leftHandTransform.position = runPosition;
                left = true;
            }
            else { left = false; }
        }

        private static Vector3 CalculatePreferredPosition()
        {
            Transform headPosition = GorillaTagger.Instance.headCollider.transform;
            float xOffset = MathF.Cos(Time.frameCount / 2);
            float yOffset = -0.5f - MathF.Sin(Time.frameCount / 2);

            Vector3 newPosition = headPosition.position +
                                  headPosition.forward * xOffset +
                                  new Vector3(0, yOffset, 0);
            return newPosition;
        }

        public static bool ena = false;
        public static void Beyblade()
        {
            ena = true;
            GorillaTagger.Instance.offlineVRRig.enabled = false;
            GorillaTagger.Instance.offlineVRRig.transform.position = GorillaTagger.Instance.headCollider.transform.position;
            GorillaTagger.Instance.offlineVRRig.transform.rotation = Quaternion.Euler(GorillaTagger.Instance.offlineVRRig.transform.rotation.eulerAngles + new Vector3(0f, 10f, 0f));
            GorillaTagger.Instance.offlineVRRig.head.rigTarget.transform.rotation = GorillaTagger.Instance.offlineVRRig.transform.rotation;
            GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position + GorillaTagger.Instance.offlineVRRig.transform.right * -1f;
            GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position + GorillaTagger.Instance.offlineVRRig.transform.right * 1f;
        }

        public static void disableBlade()
        {
            ena = false;
            GorillaTagger.Instance.offlineVRRig.enabled = true;
        }

        public static void AnnoyRandomPlayer()
        {
            if (ControllerInputPoller.instance.rightGrab || Mouse.current.leftButton.isPressed)
            {
                foreach (VRRig vR in GorillaParent.instance.vrrigs)
                {
                    if (vR != GorillaTagger.Instance.offlineVRRig)
                    {
                        ena = true;
                        VRRig ii = RigManager.GetRandomVRRig(vR);
                        GorillaTagger.Instance.offlineVRRig.enabled = false;
                        GorillaTagger.Instance.offlineVRRig.transform.position = ii.transform.position;
                        GorillaTagger.Instance.myVRRig.transform.position = ii.transform.position;
                        GorillaTagger.Instance.leftHandTransform.transform.position = ii.transform.position;
                        GorillaTagger.Instance.rightHandTransform.transform.position = ii.transform.position;
                        GorillaTagger.Instance.offlineVRRig.transform.rotation = Quaternion.Euler(GorillaTagger.Instance.offlineVRRig.transform.rotation.eulerAngles + new Vector3(0f, 10f, 0f));
                        GorillaTagger.Instance.offlineVRRig.head.rigTarget.transform.rotation = GorillaTagger.Instance.offlineVRRig.transform.rotation;
                        GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position + GorillaTagger.Instance.offlineVRRig.transform.right * -1f;
                        GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position + GorillaTagger.Instance.offlineVRRig.transform.right * 1f;
                    }
                }
            }
            else
            {
                ena = false;
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
        }

        public static GameObject rplat;
        public static GameObject lplat;
        public static GameObject platformsL;
        public static GameObject platformsR;
        public static bool rplatEnabled = false;
        public static bool lplatEnabled = false;

        public static bool sticky = false;

        public static int platChanger = 1;

        public static void Plattys(Color color)
        {
            if (ControllerInputPoller.instance.rightGrab || Mouse.current.rightButton.isPressed)
            {
                if (!rplatEnabled)
                {
                    rplat = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    rplat.GetComponent<Renderer>().material.color = color;
                    rplat.transform.position = GorillaLocomotion.Player.Instance.rightControllerTransform.position;
                    rplat.transform.rotation = GorillaLocomotion.Player.Instance.rightControllerTransform.rotation;
                    rplat.transform.localScale = new Vector3(0.01f, 0.25f, 0.25f);
                    platformsR = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    platformsR.GetComponent<Renderer>().material.color = Color.black;
                    platformsR.transform.localPosition = rplat.transform.localPosition;
                    platformsR.transform.localRotation = rplat.transform.localRotation;
                    platformsR.transform.localScale = new Vector3(0.009f, 0.26f, 0.26f);
                    rplatEnabled = true;
                }
            }
            if (ControllerInputPoller.instance.leftGrab || Mouse.current.leftButton.isPressed)
            {
                if (!lplatEnabled)
                {
                    lplat = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    lplat.GetComponent<Renderer>().material.color = color;
                    lplat.transform.position = GorillaLocomotion.Player.Instance.leftControllerTransform.position;
                    lplat.transform.rotation = GorillaLocomotion.Player.Instance.leftControllerTransform.rotation;
                    lplat.transform.localScale = new Vector3(0.01f, 0.25f, 0.25f);
                    platformsL = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    platformsL.GetComponent<Renderer>().material.color = Color.black;
                    platformsL.transform.position = lplat.transform.position;
                    platformsL.transform.rotation = lplat.transform.rotation;
                    platformsL.transform.localScale = new Vector3(0.009f, 0.26f, 0.26f);
                    lplatEnabled = true;
                }
            }
            if (!ControllerInputPoller.instance.rightGrab)
            {
                if (rplatEnabled)
                {
                    GameObject.Destroy(rplat);
                    GameObject.Destroy(platformsR);
                    rplatEnabled = false;
                }
            }
            if (!ControllerInputPoller.instance.leftGrab)
            {
                if (lplatEnabled)
                {
                    GameObject.Destroy(lplat);
                    GameObject.Destroy(platformsL);
                    lplatEnabled = false;
                }
            }
        }

        public static void ThrowPlattys(Color color)
        {
            if (ControllerInputPoller.instance.rightGrab || Mouse.current.rightButton.isPressed)
            {
                if (!rplatEnabled)
                {
                    rplat = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    rplat.GetComponent<Renderer>().material.color = color;
                    rplat.transform.position = GorillaLocomotion.Player.Instance.rightControllerTransform.position;
                    rplat.transform.rotation = GorillaLocomotion.Player.Instance.rightControllerTransform.rotation;
                    rplat.transform.localScale = new Vector3(0.01f, 0.25f, 0.25f);
                    platformsR = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    platformsR.GetComponent<Renderer>().material.color = Color.black;
                    platformsR.transform.localPosition = rplat.transform.localPosition;
                    platformsR.transform.localRotation = rplat.transform.localRotation;
                    platformsR.transform.localScale = new Vector3(0.009f, 0.26f, 0.26f);
                    rplatEnabled = true;
                }
            }
            if (ControllerInputPoller.instance.leftGrab || Mouse.current.leftButton.isPressed)
            {
                if (!lplatEnabled)
                {
                    lplat = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    lplat.GetComponent<Renderer>().material.color = color;
                    lplat.transform.position = GorillaLocomotion.Player.Instance.leftControllerTransform.position;
                    lplat.transform.rotation = GorillaLocomotion.Player.Instance.leftControllerTransform.rotation;
                    lplat.transform.localScale = new Vector3(0.01f, 0.25f, 0.25f);
                    platformsL = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    platformsL.GetComponent<Renderer>().material.color = Color.black;
                    platformsL.transform.position = lplat.transform.position;
                    platformsL.transform.rotation = lplat.transform.rotation;
                    platformsL.transform.localScale = new Vector3(0.009f, 0.26f, 0.26f);
                    lplatEnabled = true;
                }
            }
            if (!ControllerInputPoller.instance.rightGrab)
            {
                if (rplatEnabled)
                {
                    GameObject.Destroy(rplat.GetComponent<Rigidbody>(), 2f);
                    GameObject.Destroy(rplat);
                    GameObject.Destroy(platformsR);
                    rplatEnabled = false;
                }
            }
            if (!ControllerInputPoller.instance.leftGrab)
            {
                if (lplatEnabled)
                {
                    GameObject.Destroy(lplat.GetComponent<Rigidbody>(), 2f);
                    GameObject.Destroy(lplat);
                    GameObject.Destroy(platformsL);
                    lplatEnabled = false;
                }
            }
        }
    }
}
