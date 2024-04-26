using System;
using System.Collections.Generic;
using System.Text;
using Object = UnityEngine.Object;
using UnityEngine;
using Rift.Menu;

namespace Rift.Mods
{
    internal class Cosmetics
    {
        public static int i = 1;
        public static int j = 1;
        public static void BadgeChanger()
        {
            i++;
            if (i > 10)
            {
                i = 1;
            }
            if (i == 1)
            {
                GameObject.Find("Local Gorilla Player/rig/body/Old Cosmetics Body/GT1 BADGE").SetActive(false);
                Buttons.buttons[6][9].buttonText = "Gear Changer [NONE]";
                Buttons.buttons[6][9].overlapText = "Gear Changer [NONE]"; 
            }
            if (i == 2)
            {
                GameObject.Find("Local Gorilla Player/rig/body/2024_02_RotatingTees Body/LBAEY.").SetActive(true);
                Buttons.buttons[6][9].buttonText = "Gear Changer [LBAEY]";
                Buttons.buttons[6][9].overlapText = "Gear Changer [LBAEY]";
            }
            if (i == 3)
            {
                GameObject.Find("Local Gorilla Player/rig/body/2024_02_RotatingTees Body/LBAEY.").SetActive(false);

                GameObject.Find("Local Gorilla Player/rig/body/2024_02_RotatingTees Body/LBAEZ.").SetActive(true);
                Buttons.buttons[6][9].buttonText = "Gear Changer [LBAEZ]";
                Buttons.buttons[6][9].overlapText = "Gear Changer [LBAEZ]";
            }
            if (i == 4)
            {
                GameObject.Find("Local Gorilla Player/rig/body/2024_02_RotatingTees Body/LBAEZ.").SetActive(false);

                GameObject.Find("Local Gorilla Player/rig/body/2024_02_RotatingTees Body/LBAFA.").SetActive(true);
                Buttons.buttons[6][9].buttonText = "Gear Changer [LBAFA]";
                Buttons.buttons[6][9].overlapText = "Gear Changer [LBAFA]";
            }
            if (i == 5)
            {
                GameObject.Find("Local Gorilla Player/rig/body/2024_02_RotatingTees Body/LBAFA.").SetActive(false);

                GameObject.Find("Local Gorilla Player/rig/body/2024_02_RotatingTees Body/LBAFB.").SetActive(true);
                Buttons.buttons[6][9].buttonText = "Gear Changer [LBAFB]";
                Buttons.buttons[6][9].overlapText = "Gear Changer [LBAFB]";
            }
            if (i == 6)
            {
                GameObject.Find("Local Gorilla Player/rig/body/2024_02_RotatingTees Body/LBAFB.").SetActive(false);

                GameObject.Find("Local Gorilla Player/rig/body/2024_02_RotatingTees Body/LBAFD.").SetActive(true);
                Buttons.buttons[6][9].buttonText = "Gear Changer [LBAFD]";
                Buttons.buttons[6][9].overlapText = "Gear Changer [LBAFD]";
            }
            if (i == 7)
            {
                GameObject.Find("Local Gorilla Player/rig/body/2024_02_RotatingTees Body/LBAFD.").SetActive(false);

                GameObject.Find("Local Gorilla Player/rig/body/2024_02_RotatingTees Body/LBAFG.").SetActive(true);
                Buttons.buttons[6][9].buttonText = "Gear Changer [LBAFG]";
                Buttons.buttons[6][9].overlapText = "Gear Changer [LBAFG]";
            }
            if (i == 8)
            {
                GameObject.Find("Local Gorilla Player/rig/body/2024_02_RotatingTees Body/LBAFG.").SetActive(false);

                GameObject.Find("Local Gorilla Player/rig/body/Old Cosmetics Body/ADMINISTRATOR BADGE").SetActive(true);
                Buttons.buttons[6][9].buttonText = "Gear Changer [ADMIN]";
                Buttons.buttons[6][9].overlapText = "Gear Changer [ADMIN]";
            }
            if (i == 9)
            {
                GameObject.Find("Local Gorilla Player/rig/body/Old Cosmetics Body/ADMINISTRATOR BADGE").SetActive(false);

                GameObject.Find("Local Gorilla Player/rig/body/Old Cosmetics Body/EARLY ACCESS").SetActive(true);
                Buttons.buttons[6][9].buttonText = "Gear Changer [EARLY ACCESS]";
                Buttons.buttons[6][9].overlapText = "Gear Changer [EARLY ACCESS]";
            }
            if (i == 10)
            {
                GameObject.Find("Local Gorilla Player/rig/body/Old Cosmetics Body/EARLY ACCESS").SetActive(false);

                GameObject.Find("Local Gorilla Player/rig/body/Old Cosmetics Body/GT1 BADGE").SetActive(true);
                Buttons.buttons[6][9].buttonText = "Gear Changer [GT1]";
                Buttons.buttons[6][9].overlapText = "Gear Changer [GT1]";
            }
        }

        public static void GearChanger()
        {
            j++;
            if (j > 7)
            {
                j = 1;
            }
            if (j == 1)
            {
                GameObject.Find("Local Gorilla Player/rig/body/head/Old Cosmetics Head/FACE SCARF").SetActive(false);
                Buttons.buttons[14][1].buttonText = "Gear Changer [NONE]"; 
                Buttons.buttons[14][1].overlapText = "Gear Changer [NONE]";
            }
            if (j == 2)
            {
                GameObject.Find("Local Gorilla Player/rig/body/Old Cosmetics Body/POCKET GORILLA BUN BLUE").SetActive(true);
                Buttons.buttons[14][1].buttonText = "Gear Changer [BUNNY] [BLUE]";
                Buttons.buttons[14][1].overlapText = "Gear Changer [BUNNY] [BLUE]";
            }
            if (j == 3)
            {
                GameObject.Find("Local Gorilla Player/rig/body/Old Cosmetics Body/POCKET GORILLA BUN BLUE").SetActive(false);

                GameObject.Find("Local Gorilla Player/rig/body/Old Cosmetics Body/POCKET GORILLA BUN PINK").SetActive(true);
                Buttons.buttons[14][1].buttonText = "Gear Changer [BUNNY] [PINK]";
                Buttons.buttons[14][1].overlapText = "Gear Changer [BUNNY] [PINK]";
            }
            if (j == 4)
            {
                GameObject.Find("Local Gorilla Player/rig/body/Old Cosmetics Body/POCKET GORILLA BUN PINK").SetActive(false);

                GameObject.Find("Local Gorilla Player/rig/body/Old Cosmetics Body/POCKET GORILLA BUN YELLOW").SetActive(true);
                Buttons.buttons[14][1].buttonText = "Gear Changer [BUNNY] [YELLOW]";
                Buttons.buttons[14][1].overlapText = "Gear Changer [BUNNY] [YELLOW]";
            }
            if (j == 5)
            {
                GameObject.Find("Local Gorilla Player/rig/body/Old Cosmetics Body/POCKET GORILLA BUN YELLOW").SetActive(false);

                GameObject.Find("Local Gorilla Player/rig/body/head/Summer Head/SEAGULL").SetActive(true);
                Buttons.buttons[14][1].buttonText = "Gear Changer [BUNNY] [SEAGULL]";
                Buttons.buttons[14][1].overlapText = "Gear Changer [BUNNY] [SEAGULL]";
            }
            if (j == 6)
            {
                GameObject.Find("Local Gorilla Player/rig/body/head/Summer Head/SEAGULL").SetActive(false);

                GameObject.Find("Local Gorilla Player/rig/body/head/Old Cosmetics Head/ROSY CHEEKS").SetActive(true);
                Buttons.buttons[14][1].buttonText = "Gear Changer [BUNNY] [ROSY]";
                Buttons.buttons[14][1].overlapText = "Gear Changer [BUNNY] [ROSY]";
            }
            if (j == 7)
            {
                GameObject.Find("Local Gorilla Player/rig/body/head/Old Cosmetics Head/ROSY CHEEKS").SetActive(false);

                GameObject.Find("Local Gorilla Player/rig/body/head/Old Cosmetics Head/FACE SCARF").SetActive(true);
                Buttons.buttons[14][1].buttonText = "Gear Changer [BUNNY] [SCARF]";
                Buttons.buttons[14][1].overlapText = "Gear Changer [BUNNY] [SCARF]";
            }
        }
    }
}
