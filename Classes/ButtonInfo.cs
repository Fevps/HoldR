﻿using System;

namespace Rift.Classes
{
    public class ButtonInfo
    {
        public string buttonText = "-";
        public string overlapText = null;
        public Action method = null;
        public Action enableMethod = null;
        public Action disableMethod = null;
        public bool enabled = false;
        public bool isTogglable = true;
        public string toolTip = "";
        public bool isCategoryButton = false;
    }
}
