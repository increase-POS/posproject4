﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupPosServer
{
    class Global
    {
        public const string APIKey = "1234";

        //     public static string APIUri = "http://localhost:44730/api/";
        public static string APIUri = "http://localhost:44730/api/";

        public static string ScannedImageLocation = "Thumb/Scan/scan.jpg";
        public const string TMPFolder = "Thumb";
        public const string TMPItemsFolder = "Thumb/items"; // folder to save items photos locally 
        public const string TMPAgentsFolder = "Thumb/agents"; // folder to save agents photos locally 
        public const string TMPUsersFolder = "Thumb/users"; // folder to save users photos locally 
        public const string TMPSettingFolder = "Thumb/setting"; // folder to save Logo photos locally 
        public const string TMPCardsFolder = "Thumb/cards"; // folder to save Logo photos locally 

    }
}
