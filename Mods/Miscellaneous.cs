using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Linq;
using GorillaNetworking;
using Photon.Pun.UtilityScripts;
using Rift.Menu;
using Rift.Classes;
using UnityEngine;
using Rift.Notifications;

namespace Rift.Mods
{
    internal class Miscellaneous
    {
        public static void GetInfo()
        {
            if (!Directory.Exists("Rift"))
            {
                Directory.CreateDirectory("Rift");
            }
            if (!File.Exists("Rift\\ids.txt"))
            {
                File.Create("Rift\\ids.txt");
            }
            try
            {
                if (PhotonNetwork.InRoom || PhotonNetwork.InLobby)
                {
                    foreach (Player i in PhotonNetwork.PlayerListOthers)
                    {
                        VRRig rig = RigManager.GetVRRigFromPlayer(i);
                        float r = Mathf.FloorToInt(rig.playerColor.r * 9f);
                        float g = Mathf.FloorToInt(rig.playerColor.g * 9f);
                        float b = Mathf.FloorToInt(rig.playerColor.b * 9f);
                        string o = r.ToString() + " " + g.ToString() + " " + b.ToString();
                        string id = " Name:" + i.NickName + ", ID:" + i.UserId + ", ColorCode: " + o;
                        IEnumerable<string> ids = id.Split();
                        if (!File.ReadLines("Rift\\ids.txt").Contains(id))
                        {
                            File.AppendAllLines("Rift\\ids.txt", ids);
                        }
                    }
                }
                Process.Start("Rift\\ids.txt");
            } catch
            {
                NotifiLib.SendNotification("Re-Enable the mod, something broke");
            }
        }
    }
}
