using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using GorillaLocomotion;
using Rift.Menu;
using static BetterDayNightManager;
using Newtonsoft.Json.Linq;
using Rift.Classes;
using UnityEngine.UIElements;
namespace Rift.Mods
{
    internal class Visuals
    {
        public static bool isRainbowVisuals = false;
        public static void Chams()
        {
            if (PhotonNetwork.InRoom || PhotonNetwork.InLobby)
            {
                foreach (VRRig players in GorillaParent.instance.vrrigs)
                {
                    if (players != GorillaTagger.Instance.offlineVRRig)
                    {
                        if (!isRainbowVisuals)
                        {
                            GradientColorKey[] colorkeys = new GradientColorKey[3];
                            colorkeys[0].color = new Color32(0, 0, 0, 30);
                            colorkeys[0].time = 0f;
                            colorkeys[1].color = new Color32(131, 46, 217, 30);
                            colorkeys[1].time = 0.5f;
                            colorkeys[2].color = new Color32(0, 0, 0, 30);
                            colorkeys[2].time = 1f;
                            Gradient gradient = new Gradient();
                            gradient.colorKeys = colorkeys;

                            float t = Mathf.PingPong(Time.time / 2f, 1f);
                            var colortochange = gradient.Evaluate(t);

                            colortochange.a = 0.75f;
                            players.mainSkin.material.color = colortochange;
                            players.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
                        }
                        else
                        {
                            if (players.mainSkin.material.name.Contains("fected"))
                            {
                                players.mainSkin.material.color = new Color32(255, 25, 1, 100);
                                players.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
                            }
                            else
                            {
                                players.mainSkin.material.color = new Color32(25, 255, 1, 100);
                                players.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
                            }
                        }
                    }
                }
            }
        }

        public static void DisableChams()
        {
            foreach (VRRig player in GorillaParent.instance.vrrigs)
            {
                player.mainSkin.material.color = player.mainSkin.material.color;
                player.mainSkin.material.shader = Shader.Find("GorillaTag/UberShader");
            }
        }

        public static void Tracers()
        {
            if (PhotonNetwork.InRoom || PhotonNetwork.InLobby)
            {
                foreach (VRRig player in GorillaParent.instance.vrrigs)
                {
                    if (player != GorillaTagger.Instance.offlineVRRig)
                    {
                        GameObject lineFollow = new GameObject("Line");
                        LineRenderer lineUser = lineFollow.AddComponent<LineRenderer>();

                        Color red = new Color32(255, 0, 0, 100);
                        Color green = new Color32(0, 255, 0, 50);

                        lineUser.material.shader = Shader.Find("GUI/Text Shader");

                        if (!isRainbowVisuals)
                        {
                            GradientColorKey[] colorkeys = new GradientColorKey[3];
                            colorkeys[0].color = new Color32(0, 0, 0, 30);
                            colorkeys[0].time = 0f;
                            colorkeys[1].color = new Color32(131, 46, 217, 30);
                            colorkeys[1].time = 0.5f;
                            colorkeys[2].color = new Color32(0, 0, 0, 30);
                            colorkeys[2].time = 1f;
                            Gradient gradient = new Gradient();
                            gradient.colorKeys = colorkeys;

                            float t = Mathf.PingPong(Time.time / 2f, 1f);
                            var colortochange = gradient.Evaluate(t);

                            colortochange.a = 0.75f;
                            lineUser.startColor = colortochange; lineUser.endColor = colortochange;
                        }
                        else
                        {
                            if (player.mainSkin.material.name.Contains("fected"))
                            {
                                red.a = 0.25f;
                                lineUser.startColor = red; lineUser.endColor = red;
                            }
                            else
                            {
                                green.a = 0.25f;
                                lineUser.startColor = green; lineUser.endColor = green;
                            }
                        }

                        lineUser.startWidth = 0.0225f; lineUser.endWidth = 0.0225f;

                        lineUser.useWorldSpace = true;

                        lineUser.positionCount = 2;
                        lineUser.SetPosition(0, GorillaTagger.Instance.bodyCollider.transform.position);
                        lineUser.SetPosition(1, player.transform.position);

                        UnityEngine.Object.Destroy(lineFollow, Time.deltaTime);
                    }
                }
            }
        }

        public static void HandTracers()
        {
            if (PhotonNetwork.InRoom || PhotonNetwork.InLobby)
            {
                foreach (VRRig player in GorillaParent.instance.vrrigs)
                {
                    if (player != GorillaTagger.Instance.offlineVRRig)
                    {
                        GameObject lineFollow = new GameObject("Line");
                        LineRenderer lineUser = lineFollow.AddComponent<LineRenderer>();

                        Color red = new Color32(255, 0, 0, 100);
                        Color green = new Color32(0, 255, 0, 50);

                        lineUser.material.shader = Shader.Find("GUI/Text Shader");

                        if (!isRainbowVisuals)
                        {
                            GradientColorKey[] colorkeys = new GradientColorKey[3];
                            colorkeys[0].color = new Color32(0, 0, 0, 30);
                            colorkeys[0].time = 0f;
                            colorkeys[1].color = new Color32(131, 46, 217, 30);
                            colorkeys[1].time = 0.5f;
                            colorkeys[2].color = new Color32(0, 0, 0, 30);
                            colorkeys[2].time = 1f;
                            Gradient gradient = new Gradient();
                            gradient.colorKeys = colorkeys;

                            float t = Mathf.PingPong(Time.time / 2f, 1f);
                            var colortochange = gradient.Evaluate(t);

                            colortochange.a = 0.75f;
                            lineUser.startColor = colortochange; lineUser.endColor = colortochange;
                        }
                        else
                        {
                            if (player.mainSkin.material.name.Contains("fected"))
                            { 
                                red.a = 0.25f;
                                lineUser.startColor = red; lineUser.endColor = red;
                            }
                            else
                            {
                                green.a = 0.25f;
                                lineUser.startColor = green; lineUser.endColor = green;
                            }
                        }

                        lineUser.startWidth = 0.0225f; lineUser.endWidth = 0.0225f;

                        lineUser.useWorldSpace = true;

                        lineUser.positionCount = 2;
                        lineUser.SetPosition(0, GorillaTagger.Instance.leftHandTransform.transform.position);
                        lineUser.SetPosition(1, player.transform.position);

                        UnityEngine.Object.Destroy(lineFollow, Time.deltaTime);
                    }
                }
            }
        }

        public static void Beacons()
        {
            if (PhotonNetwork.InRoom || PhotonNetwork.InLobby)
            {
                foreach (VRRig player in GorillaParent.instance.vrrigs)
                {
                    if (player != GorillaTagger.Instance.offlineVRRig)
                    {
                        GameObject lineFollow = new GameObject("Line");
                        LineRenderer lineUser = lineFollow.AddComponent<LineRenderer>();

                        Color red = new Color32(255, 0, 0, 50);
                        Color green = new Color32(0, 255, 0, 50);

                        lineUser.material.shader = Shader.Find("GUI/Text Shader");

                        if (!isRainbowVisuals)
                        {
                            GradientColorKey[] colorkeys = new GradientColorKey[3];
                            colorkeys[0].color = new Color32(0, 0, 0, 30);
                            colorkeys[0].time = 0f;
                            colorkeys[1].color = new Color32(131, 46, 217, 30);
                            colorkeys[1].time = 0.5f;
                            colorkeys[2].color = new Color32(0, 0, 0, 30);
                            colorkeys[2].time = 1f;
                            Gradient gradient = new Gradient();
                            gradient.colorKeys = colorkeys;

                            float t = Mathf.PingPong(Time.time / 2f, 1f);
                            var colortochange = gradient.Evaluate(t);

                            colortochange.a = 0.75f;
                            lineUser.startColor = colortochange; lineUser.endColor = colortochange;
                        }
                        else
                        {
                            if (player.mainSkin.material.name.Contains("fected"))
                            {
                                red.a = 0.25f;
                                lineUser.startColor = red; lineUser.endColor = red;
                            }
                            else
                            {
                                green.a = 0.25f;
                                lineUser.startColor = green; lineUser.endColor = green;
                            }
                        }

                        lineUser.startWidth = 0.0225f; lineUser.endWidth = 0.0225f;

                        lineUser.useWorldSpace = true;

                        lineUser.positionCount = 2;
                        lineUser.SetPosition(0, player.transform.position + new Vector3(0, 20, 0));
                        lineUser.SetPosition(1, player.transform.position + new Vector3(0, -20, 0));

                        UnityEngine.Object.Destroy(lineFollow, Time.deltaTime);
                    }
                }
            }
        }

        public static void HeadChams()
        {
            if (PhotonNetwork.InRoom || PhotonNetwork.InLobby)
            {
                foreach (VRRig i in GorillaParent.instance.vrrigs)
                {
                    if (i != GorillaTagger.Instance.offlineVRRig)
                    {
                        GameObject bodySphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);

                        Color red = new Color32(255, 0, 0, 50);
                        Color green = new Color32(0, 255, 0, 50);

                        bodySphere.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                        if (!isRainbowVisuals)
                        {
                            GradientColorKey[] colorkeys = new GradientColorKey[3];
                            colorkeys[0].color = new Color32(0, 0, 0, 30);
                            colorkeys[0].time = 0f;
                            colorkeys[1].color = new Color32(131, 46, 217, 30);
                            colorkeys[1].time = 0.5f;
                            colorkeys[2].color = new Color32(0, 0, 0, 30);
                            colorkeys[2].time = 1f;
                            Gradient gradient = new Gradient();
                            gradient.colorKeys = colorkeys;

                            float t = Mathf.PingPong(Time.time / 2f, 1f);
                            var colortochange = gradient.Evaluate(t);

                            colortochange.a = 0.75f;
                            bodySphere.GetComponent<Renderer>().material.color = colortochange;
                        }
                        else
                        {
                            if (i.mainSkin.material.name.Contains("fected"))
                            {
                                red.a = 0.25f;
                                bodySphere.GetComponent<Renderer>().material.color = red;
                            }
                            else
                            {
                                green.a = 0.25f;
                                bodySphere.GetComponent<Renderer>().material.color = green;
                            }
                        }
                        bodySphere.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

                        bodySphere.transform.position = i.transform.position + new Vector3(0, 1, 0);
                        UnityEngine.Object.Destroy(bodySphere.GetComponent<BoxCollider>());
                        UnityEngine.Object.Destroy(bodySphere.GetComponent<Rigidbody>());
                        UnityEngine.Object.Destroy(bodySphere, Time.deltaTime);
                    }
                }
            }
        }

        public static void BoxESP()
        {
            if (PhotonNetwork.InRoom || PhotonNetwork.InLobby)
            {
                foreach (VRRig i in GorillaParent.instance.vrrigs)
                {
                    if (i != GorillaTagger.Instance.offlineVRRig)
                    {
                        GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        UnityEngine.Object.Destroy(box.GetComponent<BoxCollider>());
                        UnityEngine.Object.Destroy(box.GetComponent<Rigidbody>());
                        UnityEngine.Object.Destroy(box, Time.deltaTime);
                        box.transform.localScale = new Vector3(0.75f, 1.5f, 0.75f);
                        box.transform.position = i.transform.position;
                        Color red = new Color32(255, 0, 0, 50);
                        Color green = new Color32(0, 255, 0, 50);
                        box.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                        if (!isRainbowVisuals)
                        {
                            GradientColorKey[] colorkeys = new GradientColorKey[3];
                            colorkeys[0].color = new Color32(0, 0, 0, 30);
                            colorkeys[0].time = 0f;
                            colorkeys[1].color = new Color32(131, 46, 217, 30);
                            colorkeys[1].time = 0.5f;
                            colorkeys[2].color = new Color32(0, 0, 0, 30);
                            colorkeys[2].time = 1f;
                            Gradient gradient = new Gradient();
                            gradient.colorKeys = colorkeys;

                            float t = Mathf.PingPong(Time.time / 2f, 1f);
                            var colortochange = gradient.Evaluate(t);

                            colortochange.a = 0.75f;
                            box.GetComponent<Renderer>().material.color = colortochange;
                        }
                        else
                        {
                            if (i.mainSkin.material.name.Contains("fected"))
                            {
                                red.a = 0.25f;
                                box.GetComponent<Renderer>().material.color = red;
                            }
                            else
                            {
                                green.a = 0.25f;
                                box.GetComponent<Renderer>().material.color = green;
                            }
                        }
                    }
                }
            }
        }

        GameObject drawnObject = RainbowDraw();
        private static List<GameObject> drawObjects = new List<GameObject>();
        public static GameObject RainbowDraw()
        {
            GameObject drawnObject = null;

            if (ControllerInputPoller.instance.leftGrab || Mouse.current.leftButton.isPressed)
            {
                GameObject draw = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                UnityEngine.Object.Destroy(draw.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(draw.GetComponent<Collider>());
                UnityEngine.Object.Destroy(draw, 5f);
                draw.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                draw.transform.position = Player.Instance.leftControllerTransform.position;

                drawnObject = draw;
                drawObjects.Add(draw);

                if (!isRainbowVisuals)
                {
                    GradientColorKey[] colorkeys = new GradientColorKey[3];
                    colorkeys[0].color = new Color32(0, 0, 0, 30);
                    colorkeys[0].time = 0f;
                    colorkeys[1].color = new Color32(131, 46, 217, 30);
                    colorkeys[1].time = 0.5f;
                    colorkeys[2].color = new Color32(0, 0, 0, 30);
                    colorkeys[2].time = 1f;
                    Gradient gradient = new Gradient();
                    gradient.colorKeys = colorkeys;
                    float t = Mathf.PingPong(Time.time / 2f, 1f);
                    var colortochange = gradient.Evaluate(t);

                    draw.GetComponent<Renderer>().material.color = colortochange;
                }
                else
                {
                    draw.GetComponent<Renderer>().material.color = Variables.ButtonDisabled;
                }
            }
            if (ControllerInputPoller.instance.rightGrab || Mouse.current.rightButton.isPressed)
            {
                GameObject draw = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                UnityEngine.Object.Destroy(draw.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(draw.GetComponent<Collider>());
                UnityEngine.Object.Destroy(draw, 5f);
                draw.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                draw.transform.position = Player.Instance.rightControllerTransform.position;

                drawnObject = draw;
                drawObjects.Add(draw);

                if (!isRainbowVisuals)
                {
                    GradientColorKey[] colorkeys = new GradientColorKey[3];
                    colorkeys[0].color = new Color32(0, 0, 0, 30);
                    colorkeys[0].time = 0f;
                    colorkeys[1].color = new Color32(131, 46, 217, 30);
                    colorkeys[1].time = 0.5f;
                    colorkeys[2].color = new Color32(0, 0, 0, 30);
                    colorkeys[2].time = 1f;
                    Gradient gradient = new Gradient();
                    gradient.colorKeys = colorkeys;
                    float t = Mathf.PingPong(Time.time / 2f, 1f);
                    var colortochange = gradient.Evaluate(t);

                    draw.GetComponent<Renderer>().material.color = colortochange;
                }
                else
                {
                    draw.GetComponent<Renderer>().material.color = Variables.ButtonDisabled;
                }
            }
            return drawnObject;
        }

        public static void ForceRain()
        {
            BetterDayNightManager.instance.weatherCycle[BetterDayNightManager.instance.currentWeatherIndex] = WeatherType.Raining;
            BetterDayNightManager.instance.CurrentWeather();
        }

        public static void ClearWeather()
        {
            BetterDayNightManager.instance.weatherCycle[BetterDayNightManager.instance.currentWeatherIndex] = WeatherType.None;
            BetterDayNightManager.instance.CurrentWeather();
        }

        public static int weatherMonicle = 2;
        public static void WeatherChangers()
        {
            weatherMonicle++;
            if (weatherMonicle > 5)
            {
                weatherMonicle = 2;
            }
            if (weatherMonicle == 2)
            {
                BetterDayNightManager.instance.SetTimeOfDay(1);
                Buttons.buttons[6][8].buttonText = "Time Changer [Aesthetic]";
                Buttons.buttons[6][8].overlapText = "Time Changer [Aesthetic]";
            }
            if (weatherMonicle == 3)
            {
                BetterDayNightManager.instance.SetTimeOfDay(3);
                Buttons.buttons[6][8].buttonText = "Time Changer [Day]";
                Buttons.buttons[6][8].overlapText = "Time Changer [Day]";
            }
            if (weatherMonicle == 4)
            {
                BetterDayNightManager.instance.SetTimeOfDay(0);
                Buttons.buttons[6][8].buttonText = "Time Changer [Night]";
                Buttons.buttons[6][8].overlapText = "Time Changer [Night]";
            }
            if (weatherMonicle == 5)
            {
                BetterDayNightManager.instance.SetTimeOfDay(6);
                Buttons.buttons[6][8].buttonText = "Time Changer [Fall]";
                Buttons.buttons[6][8].overlapText = "Time Changer [Fall]";
            }
            Main.RecreateMenu();
        }

        public static void Gauntlet()
        {
            GameObject game1 = GorillaTagger.Instance.rightHandTransform.gameObject;
            GameObject game = UnityEngine.Object.Instantiate(game1);
            game = new GameObject();
            game.transform.localScale = GorillaTagger.Instance.rightHandTransform.localScale + new Vector3(0.05f, 0.05f, 0.05f);
            game.transform.position = GorillaTagger.Instance.rightHandTransform.position;
            game.transform.rotation = GorillaTagger.Instance.rightHandTransform.rotation;
            game.GetComponent<Renderer>().material.shader = Variables.GUIShader;
            if (!isRainbowVisuals)
            {
                GradientColorKey[] colorkeys = new GradientColorKey[7];
                colorkeys[0].color = Color.red;
                colorkeys[0].time = 0f;
                colorkeys[1].color = Color.yellow;
                colorkeys[1].time = 0.2f;
                colorkeys[2].color = Color.green;
                colorkeys[2].time = 0.3f;
                colorkeys[3].color = Color.cyan;
                colorkeys[3].time = 0.5f;
                colorkeys[4].color = Color.blue;
                colorkeys[4].time = 0.6f;
                colorkeys[5].color = Color.magenta;
                colorkeys[5].time = 0.8f;
                colorkeys[6].color = Color.red;
                colorkeys[6].time = 1f;
                Gradient gradient = new Gradient();
                gradient.colorKeys = colorkeys;
                float t = Mathf.PingPong(Time.time / 2f, 1f);
                var colortochange = gradient.Evaluate(t);
                game.GetComponent<Renderer>().material.color = colortochange;
            }
            else
            {
                game.GetComponent<Renderer>().material.color = Settings.OutlineColor;
            }
            ControllerInputPoller.instance.rightControllerIndexFloat = 0f;
            ControllerInputPoller.instance.rightControllerGripFloat = 0f;
            ControllerInputPoller.instance.rightControllerPrimaryButton = false;
            ControllerInputPoller.instance.rightControllerSecondaryButton = false;

            UnityEngine.Object.Destroy(game, Time.deltaTime);
            UnityEngine.Object.Destroy(game.GetComponent<Collider>());
            UnityEngine.Object.Destroy(game.GetComponent<Rigidbody>());
        }

        public static void BreadCrumbVisuals()
        {
            if (PhotonNetwork.InRoom)
            {
                foreach (VRRig i in GorillaParent.instance.vrrigs)
                {
                    if (i != GorillaTagger.Instance.offlineVRRig)
                    {
                        GameObject crumb = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        UnityEngine.Object.Destroy(crumb.GetComponent<Rigidbody>());
                        UnityEngine.Object.Destroy(crumb.GetComponent<Collider>());
                        UnityEngine.Object.Destroy(crumb, 7.5f);
                        crumb.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                        crumb.transform.LookAt(GorillaTagger.Instance.headCollider.transform.position);
                        crumb.transform.position = i.transform.position;
                        Color red = new Color32(255, 0, 0, 50);
                        Color green = new Color32(0, 255, 0, 50);
                        crumb.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                        if (!isRainbowVisuals)
                        {
                            GradientColorKey[] colorkeys = new GradientColorKey[3];
                            colorkeys[0].color = new Color32(0, 0, 0, 30);
                            colorkeys[0].time = 0f;
                            colorkeys[1].color = new Color32(131, 46, 217, 30);
                            colorkeys[1].time = 0.5f;
                            colorkeys[2].color = new Color32(0, 0, 0, 30);
                            colorkeys[2].time = 1f;
                            Gradient gradient = new Gradient();
                            gradient.colorKeys = colorkeys;
                            float t = Mathf.PingPong(Time.time / 2f, 1f);
                            var colortochange = gradient.Evaluate(t);
                            crumb.GetComponent<Renderer>().material.color = colortochange;
                        }
                        else
                        {
                            if (i.mainSkin.material.name.Contains("fected"))
                            {
                                red.a = 0.25f;
                                crumb.GetComponent<Renderer>().material.color = red;
                            }
                            else
                            {
                                green.a = 0.25f;
                                crumb.GetComponent<Renderer>().material.color = green;
                            }
                        }
                    }
                }
            }
        }

        public static void SnakeVisuals()
        {
            if (PhotonNetwork.InRoom)
            {
                foreach (VRRig i in GorillaParent.instance.vrrigs)
                {
                    if (i != GorillaTagger.Instance.offlineVRRig)
                    {
                        GameObject crumb = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        UnityEngine.Object.Destroy(crumb.GetComponent<Rigidbody>());
                        UnityEngine.Object.Destroy(crumb.GetComponent<Collider>());
                        UnityEngine.Object.Destroy(crumb, 1f);
                        crumb.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                        crumb.transform.LookAt(GorillaTagger.Instance.headCollider.transform.position);
                        crumb.transform.position = i.transform.position;
                        Color red = new Color32(255, 0, 0, 50);
                        Color green = new Color32(0, 255, 0, 50);
                        crumb.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                        if (!isRainbowVisuals)
                        {
                            GradientColorKey[] colorkeys = new GradientColorKey[3];
                            colorkeys[0].color = new Color32(0, 0, 0, 30);
                            colorkeys[0].time = 0f;
                            colorkeys[1].color = new Color32(131, 46, 217, 30);
                            colorkeys[1].time = 0.5f;
                            colorkeys[2].color = new Color32(0, 0, 0, 30);
                            colorkeys[2].time = 1f;
                            Gradient gradient = new Gradient();
                            gradient.colorKeys = colorkeys;
                            float t = Mathf.PingPong(Time.time / 2f, 1f);
                            var colortochange = gradient.Evaluate(t);
                            crumb.GetComponent<Renderer>().material.color = colortochange;
                        }
                        else
                        {
                            if (i.mainSkin.material.name.Contains("fected"))
                            {
                                red.a = 0.25f;
                                crumb.GetComponent<Renderer>().material.color = red;
                            }
                            else
                            {
                                green.a = 0.25f;
                                crumb.GetComponent<Renderer>().material.color = green;
                            }
                        }
                    }
                }
            }
        }
    }
}
