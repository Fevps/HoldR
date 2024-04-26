using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine.InputSystem;
using UnityEngine;
using Object = UnityEngine.Object;
using Rift.Classes;
using GorillaTag;
using HarmonyLib;
using Rift.Menu;
using Rift.Notifications;
using Photon.Voice.PUN.UtilityScripts;
using Photon.Realtime;
using GorillaNetworking;
using PlayFab.ClientModels;
using PlayFab;
using System.Text.RegularExpressions;

namespace Rift.Mods
{
    internal class OtherMods
    {
        public static string[] Gliders = new string[]
        {
            "Environment Objects/PersistentObjects_Prefab/Gliders_Placement_Prefab/Root/LeafGliderFunctional/GliderHoldable",
            "Environment Objects/PersistentObjects_Prefab/Gliders_Placement_Prefab/Root/LeafGliderFunctional (1)/GliderHoldable",
            "Environment Objects/PersistentObjects_Prefab/Gliders_Placement_Prefab/Root/LeafGliderFunctional (4)/GliderHoldable",
            "Environment Objects/PersistentObjects_Prefab/Gliders_Placement_Prefab/Root/LeafGliderFunctional (5)/GliderHoldable",
            "Environment Objects/PersistentObjects_Prefab/Gliders_Placement_Prefab/Root/LeafGliderFunctional (6)/GliderHoldable",
            "Environment Objects/PersistentObjects_Prefab/Gliders_Placement_Prefab/Root/LeafGliderFunctional (7)/GliderHoldable",
            "Environment Objects/PersistentObjects_Prefab/Gliders_Placement_Prefab/Root/LeafGliderFunctional (8)/GliderHoldable",
            "Environment Objects/PersistentObjects_Prefab/Gliders_Placement_Prefab/Root/LeafGliderFunctional (9)/GliderHoldable",
            "Environment Objects/PersistentObjects_Prefab/Gliders_Placement_Prefab/Root/LeafGliderFunctional (10)/GliderHoldable",
            "Environment Objects/PersistentObjects_Prefab/Gliders_Placement_Prefab/Root/LeafGliderFunctional (11)/GliderHoldable",
            "Environment Objects/PersistentObjects_Prefab/Gliders_Placement_Prefab/Root/LeafGliderFunctional (12)/GliderHoldable",
            "Environment Objects/PersistentObjects_Prefab/Gliders_Placement_Prefab/Root/LeafGliderFunctional (17)/GliderHoldable",
            "Environment Objects/PersistentObjects_Prefab/Gliders_Placement_Prefab/Root/LeafGliderFunctional (18)/GliderHoldable",
            "Environment Objects/PersistentObjects_Prefab/Gliders_Placement_Prefab/Root/LeafGliderFunctional (19)/GliderHoldable",
            "Environment Objects/PersistentObjects_Prefab/Gliders_Placement_Prefab/Root/LeafGliderFunctional (20)/GliderHoldable",
            "Environment Objects/PersistentObjects_Prefab/Gliders_Placement_Prefab/Root/LeafGliderFunctional (21)/GliderHoldable",
            "Environment Objects/PersistentObjects_Prefab/Gliders_Placement_Prefab/Root/LeafGliderFunctional (23)/GliderHoldable",
            "Environment Objects/PersistentObjects_Prefab/Gliders_Placement_Prefab/Root/LeafGliderFunctional (24)/GliderHoldable",
        };

        public static void GliderPosition(Vector3 position)
        {
            int i = UnityEngine.Random.Range(0, Gliders.Length);
            GliderHoldable glider = GameObject.Find(Gliders[i]).GetComponent<GliderHoldable>();
            glider.OnGrab(null, null);
            if (glider.photonView.OwnerActorNr != PhotonNetwork.LocalPlayer.ActorNumber)
            {
                glider.photonView.OwnerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
            }
            if (glider.photonView.ControllerActorNr != PhotonNetwork.LocalPlayer.ActorNumber)
            {
                glider.photonView.ControllerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
            }
            glider.transform.position = position;
        }

        public static void RespawnGliders()
        {
            int i = UnityEngine.Random.Range(0, Gliders.Length);
            GameObject.Find(Gliders[i]).GetComponent<GliderHoldable>().Respawn();
        }

        public static void GrabAGlider()
        {
            if (PhotonNetwork.LocalPlayer.IsMasterClient)
            {
                if (ControllerInputPoller.instance.leftGrab || Mouse.current.leftButton.isPressed)
                {
                    Object.FindObjectOfType<GliderHoldable>().transform.position = GorillaTagger.Instance.leftHandTransform.transform.position;
                }
            }
        }

        public static int GliderValue = 0;
        public static void GliderAll()
        {
            if (PhotonNetwork.LocalPlayer.IsMasterClient)
            {
                foreach (Player i in PhotonNetwork.PlayerList)
                {
                    if (GliderValue == 0)
                    {
                        GameObject.Find("Environment Objects/PersistentObjects_Prefab/Gliders_Placement_Prefab/Root/LeafGliderFunctional/GliderHoldable").GetComponent<GliderHoldable>().transform.position = GorillaGameManager.instance.FindPlayerVRRig(i).transform.position;
                    }
                    else
                    {
                        GameObject.Find("Environment Objects/PersistentObjects_Prefab/Gliders_Placement_Prefab/Root/LeafGliderFunctional (" + GliderValue + ")/GliderHoldable").GetComponent<GliderHoldable>().transform.position = GorillaGameManager.instance.FindPlayerVRRig(i).transform.position;
                    }
                }
                if (GliderValue > 20)
                {
                    GliderValue = 0;
                }
                else
                {
                    GliderValue++;
                }
            }
        }

        public static void GliderAll1()
        {
            foreach (Player i in PhotonNetwork.PlayerList)
            {
                GliderPosition(GorillaGameManager.instance.FindVRRigForPlayer(i).transform.position);
            }
        }
        public static void GrabEveryGlider()
        {
            VRRig i = RigManager.GetRandomVRRig(true);
            GliderPosition(i.transform.position);
        }

        public static void SpamAllGliders()
        {
            foreach (Player i in PhotonNetwork.PlayerList)
            {
                GliderPosition(RigManager.GetVRRigFromPlayer(i).transform.position);
                GliderPosition(RigManager.GetVRRigFromPlayer(i).transform.position + Vector3.up * 1f);
            }
        }

        public static void FloatGliders()
        {
            foreach (Player ii in PhotonNetwork.PlayerList)
            {
                GliderPosition(RigManager.GetVRRigFromPlayer(ii).transform.position += Vector3.up * 5f);
            }
        }  

        public static void TagAura()
        {
            float distance = 4f;
            VRRig outRig = null;
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("fected") && vrrig != GorillaTagger.Instance.offlineVRRig && Vector3.Distance(GorillaTagger.Instance.bodyCollider.transform.position, vrrig.transform.position) < distance && !vrrig.mainSkin.material.name.Contains("fected"))
                {
                    distance = Vector3.Distance(GorillaTagger.Instance.bodyCollider.transform.position, vrrig.transform.position) * 4f;
                    outRig = vrrig;
                }
            }
            GorillaTagger.Instance.leftHandTransform.position = outRig.transform.position;
            GorillaTagger.Instance.rightHandTransform.position = outRig.transform.position;
        }

        public static void SetMasterModded()
        {
            if (!Variables.isMaster())
            {
                if (Variables.inModded())
                {
                    PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);
                }
                else
                {
                    NotifiLib.SendNotification("You aren't in a modded lobby.");
                }
            }
            else
            {
                NotifiLib.SendNotification("You are already master client.");
            }
        }

        public static bool AcidEnabled = false;
        public static void AcidSelf()
        {
            if (AcidEnabled == false)
            {
                AcidPlayer(PhotonNetwork.LocalPlayer);
                AcidEnabled = true;
            }
            else
            {
                RemoveAcidPlayer(PhotonNetwork.LocalPlayer);
                AcidEnabled = false;
            }
        }
        public static bool AcidAllEnabled = false;
        public static void AcidAll()
        {
            int PlayerCount = PhotonNetwork.CountOfPlayers;
            if (!AcidAllEnabled)
            {
                int playerCountInLobby = PhotonNetwork.PlayerList.Length;
                Traverse.Create(ScienceExperimentManager.instance).Field("inGamePlayerCount").SetValue(playerCountInLobby);
                ScienceExperimentManager.PlayerGameState[] states = new ScienceExperimentManager.PlayerGameState[playerCountInLobby];
                for (int i = 0; i < playerCountInLobby; i++)
                {
                    ScienceExperimentManager.PlayerGameState state = new ScienceExperimentManager.PlayerGameState();
                    state.touchedLiquid = true;
                    state.playerId = PhotonNetwork.PlayerList[i] == null ? 0 : PhotonNetwork.PlayerList[i].ActorNumber;
                    states[i] = state;
                }
                Traverse.Create(ScienceExperimentManager.instance).Field("inGamePlayerStates").SetValue(states);
                AcidAllEnabled = true;
            }
            else
            {
                int playerCountInLobby = PhotonNetwork.PlayerList.Length;
                Traverse.Create(ScienceExperimentManager.instance).Field("inGamePlayerCount").SetValue(playerCountInLobby);
                ScienceExperimentManager.PlayerGameState[] states = new ScienceExperimentManager.PlayerGameState[playerCountInLobby];
                for (int i = 0; i < playerCountInLobby; i++)
                {
                    ScienceExperimentManager.PlayerGameState state = new ScienceExperimentManager.PlayerGameState();
                    state.touchedLiquid = false;
                    state.playerId = PhotonNetwork.PlayerList[i] == null ? 0 : PhotonNetwork.PlayerList[i].ActorNumber;
                    states[i] = state;
                }
                Traverse.Create(ScienceExperimentManager.instance).Field("inGamePlayerStates").SetValue(states);
                AcidAllEnabled = false;
            }
        }

        public static void AcidPlayer(Player player)
        {
            if (PhotonNetwork.InRoom)
            {
                int PlayerCount = PhotonNetwork.CountOfPlayers;
                Traverse.Create(ScienceExperimentManager.instance).Field("inGamePlayerCount").SetValue(PlayerCount);
                ScienceExperimentManager.PlayerGameState[] states = new ScienceExperimentManager.PlayerGameState[PlayerCount];
                for (int i = 0; i < PlayerCount; i++)
                {
                    ScienceExperimentManager.PlayerGameState state = new ScienceExperimentManager.PlayerGameState();
                    state.touchedLiquid = true;
                    state.playerId = (player != null) ? player.ActorNumber : 0;
                    states[i] = state;
                }
                Traverse.Create(ScienceExperimentManager.instance).Field("inGamePlayerStates").SetValue(states);
            }
        }
        public static void RemoveAcidPlayer(Player player)
        {
            if (PhotonNetwork.InRoom)
            {
                int PlayerCount = PhotonNetwork.CountOfPlayers;
                Traverse.Create(ScienceExperimentManager.instance).Field("inGamePlayerCount").SetValue(PlayerCount);
                ScienceExperimentManager.PlayerGameState[] states = new ScienceExperimentManager.PlayerGameState[PlayerCount];
                for (int i = 0; i < PlayerCount; i++)
                {
                    ScienceExperimentManager.PlayerGameState state = new ScienceExperimentManager.PlayerGameState();
                    state.touchedLiquid = false;
                    state.playerId = (player != null) ? player.ActorNumber : 0;
                    states[i] = state;
                }
                Traverse.Create(ScienceExperimentManager.instance).Field("inGamePlayerStates").SetValue(states);
            }
        }

        public static bool enabl = false;
        public static void InfectSelf()
        {
            if (PhotonNetwork.InRoom)
            {
                if (!Movement.ena)
                {
                    foreach (VRRig i in GorillaParent.instance.vrrigs)
                    {
                        if (i != GorillaTagger.Instance.offlineVRRig)
                        {
                            if (i.mainSkin.material.name.Contains("fected") && !GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("fected"))
                            {
                                enabl = true;
                            }
                            else
                            {
                                GorillaTagger.Instance.offlineVRRig.enabled = true;
                                enabl = false;
                            }
                            if (enabl)
                            {
                                GorillaTagger.Instance.offlineVRRig.enabled = false;
                                GorillaTagger.Instance.offlineVRRig.transform.position = i.transform.position;
                                GorillaTagger.Instance.myVRRig.transform.position = i.transform.position;
                                GorillaTagger.Instance.leftHandTransform.transform.position = i.transform.position;
                                GorillaTagger.Instance.rightHandTransform.transform.position = i.transform.position;
                            }
                            else
                            {
                                GorillaTagger.Instance.offlineVRRig.enabled = true;
                                enabl = false;
                            }
                        }
                    }
                }
            }
        }

        public static void FixSelf()
        {
            enabl = false;
            GorillaTagger.Instance.offlineVRRig.enabled = true;
        }

        public static void InfectSpamAll() 
        { 
            Player player = RigManager.GetRandomPlayer(true); 
            if (RigManager.GetVRRigFromPlayer(player).mainSkin.material.name.Contains("fected")) 
            {
                Object.FindObjectOfType<GorillaTagManager>().currentInfected.Remove(player); 
            } 
            else 
            {
                Object.FindObjectOfType<GorillaTagManager>().AddInfectedPlayer(player); 
            } 
        }

        public static void InfectAll()
        {
            if (PhotonNetwork.InRoom || PhotonNetwork.InLobby)
            {
                if (!Movement.ena)
                {
                    foreach (VRRig i in GorillaParent.instance.vrrigs)
                    {
                        if (i != GorillaTagger.Instance.offlineVRRig)
                        {
                            if (!i.mainSkin.material.name.Contains("fected") && GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("fected"))
                            {
                                GorillaTagger.Instance.offlineVRRig.enabled = false;
                                GorillaTagger.Instance.offlineVRRig.transform.position = i.transform.position + new Vector3(0, 1, 0);
                                GorillaTagger.Instance.myVRRig.transform.position = i.transform.position + new Vector3(0, 1, 0);
                                GorillaTagger.Instance.leftHandTransform.transform.position = i.transform.position;
                                GorillaTagger.Instance.rightHandTransform.transform.position = i.transform.position;
                            }
                            else
                            {
                                GorillaTagger.Instance.offlineVRRig.enabled = true;
                            }
                        }
                    }
                }
            }
        }

        public static void InfectGun()
        {
            if (PhotonNetwork.InRoom)
            {
                if (ControllerInputPoller.instance.rightGrab || Mouse.current.rightButton.isPressed)
                {
                    foreach (VRRig i in GorillaParent.instance.vrrigs)
                    {
                        if (i != GorillaTagger.Instance.offlineVRRig)
                        {
                            RaycastHit hit;
                            Physics.Raycast(GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.rightHandTransform.forward, out hit);
                            GameObject Pointer = GameObject.CreatePrimitive(0);
                            Pointer.transform.position = hit.point;
                            Pointer.transform.localScale = new Vector3(0.185f, 0.185f, 0.185f);
                            Pointer.GetComponent<Renderer>().material.color = Settings.OutlineColor;
                            Object.Destroy(Pointer.GetComponent<SphereCollider>());
                            Object.Destroy(Pointer.GetComponent<Rigidbody>());
                            Object.Destroy(Pointer.GetComponent<Collider>());
                            Object.Destroy(Pointer, Time.deltaTime);
                            if (Mouse.current.leftButton.isPressed && Pointer.transform.position == i.transform.position || ControllerInputPoller.instance.rightControllerIndexFloat > 0.5f && Pointer.transform.position == i.transform.position)
                            {
                                if (!Movement.ena)
                                {
                                    if (!i.mainSkin.material.name.Contains("fected") && GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("fected"))
                                    {
                                        GorillaTagger.Instance.offlineVRRig.enabled = false;
                                        GorillaTagger.Instance.offlineVRRig.transform.position = i.transform.position + new Vector3(0, 1, 0);
                                        GorillaTagger.Instance.myVRRig.transform.position = i.transform.position + new Vector3(0, 1, 0);
                                        GorillaTagger.Instance.leftHandTransform.transform.position = i.transform.position;
                                        GorillaTagger.Instance.rightHandTransform.transform.position = i.transform.position;
                                    }
                                    else
                                    {
                                        GorillaTagger.Instance.offlineVRRig.enabled = true;
                                    }
                                }
                                else
                                {
                                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                                }
                            }
                            else
                            {
                                GorillaTagger.Instance.offlineVRRig.enabled = true;
                            }
                        }
                    }
                }
                else
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                }
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
        }

        public static void StartBattle()
        {
            GorillaBattleManager Manager = GameObject.Find("Gorilla Battle Manager").GetComponent<GorillaBattleManager>();
            Manager.StartBattle();
        }

        public static void EndBattle()
        {
            GorillaBattleManager Manager = GameObject.Find("Gorilla Battle Manager").GetComponent<GorillaBattleManager>();
            Manager.BattleEnd();
        }

        public static void BattleInvincibility()
        {
            GorillaBattleManager Manager = GameObject.Find("Gorilla Battle Manager").GetComponent<GorillaBattleManager>();
            Manager.playerLives[PhotonNetwork.LocalPlayer.ActorNumber] = int.MaxValue;
        }

        public static void AllBattleInvincibility()
        {
            foreach (Player i in PhotonNetwork.PlayerList)
            {
                GorillaBattleManager Manager = GameObject.Find("Gorilla Battle Manager").GetComponent<GorillaBattleManager>();
                Manager.playerLives[i.ActorNumber] = int.MaxValue;
            }
        }

        public static void ResetHealth()
        {
            GorillaBattleManager Manager = GameObject.Find("Gorilla Battle Manager").GetComponent<GorillaBattleManager>();
            Manager.playerLives[PhotonNetwork.LocalPlayer.ActorNumber] = 3;
        }

        public static void ResetAllHealth()
        {
            foreach (Player i in PhotonNetwork.PlayerList)
            {
                GorillaBattleManager Manager = GameObject.Find("Gorilla Battle Manager").GetComponent<GorillaBattleManager>();
                Manager.playerLives[i.ActorNumber] = 3;
            }
        }

        public static void Down1HP()
        {
            GorillaBattleManager Manager = GameObject.Find("Gorilla Battle Manager").GetComponent<GorillaBattleManager>();
            Manager.playerLives[PhotonNetwork.LocalPlayer.ActorNumber] -= 1;
        }

        public static void Up1HP()
        {
            GorillaBattleManager Manager = GameObject.Find("Gorilla Battle Manager").GetComponent<GorillaBattleManager>();
            Manager.playerLives[PhotonNetwork.LocalPlayer.ActorNumber] += 1;
        }

        public static void KillOtherTeam()
        {
            GorillaBattleManager Manager = GameObject.Find("Gorilla Battle Manager").GetComponent<GorillaBattleManager>();
            foreach (Player i in PhotonNetwork.PlayerListOthers)
            {
                Manager.playerLives[i.ActorNumber] = 0;
            }
        }

        public static void Down1HPAll()
        {
            foreach (Player i in PhotonNetwork.PlayerList)
            {
                GorillaBattleManager Manager = GameObject.Find("Gorilla Battle Manager").GetComponent<GorillaBattleManager>();
                Manager.playerLives[i.ActorNumber] -= 1;
            }
        }

        public static void Up1HPAll()
        {
            foreach (Player i in PhotonNetwork.PlayerList)
            {
                GorillaBattleManager Manager = GameObject.Find("Gorilla Battle Manager").GetComponent<GorillaBattleManager>();
                Manager.playerLives[i.ActorNumber] += 1;
            }
        }

        public static void StartHunt()
        {
            GorillaHuntManager Manager = GameObject.Find("Gorilla Hunt Manager").GetComponent<GorillaHuntManager>();
            Manager.StartHunt();
        }

        public static void EndHunt()
        {
            GorillaHuntManager Manager = GameObject.Find("Gorilla Hunt Manager").GetComponent<GorillaHuntManager>();
            Manager.HuntEnd();
        }

        public static void BadNameBypasser()
        {
            if (GorillaComputer.instance.currentState == GorillaComputer.ComputerState.Name)
            {
                NetworkSystem.Instance.SetMyNickName(GorillaComputer.instance.currentName);
                PlayerPrefs.SetString("playerName", GorillaComputer.instance.currentName);
                PlayerPrefs.Save();
            }
        }
    }
}
