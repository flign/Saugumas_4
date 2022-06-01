﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saugumas_4
{
    class UserStringConverter
    {
        public static User GetStringToUser(string[] data)
        {
            if (data == null)
                throw new Exception("Tušio lauko negalima paversti į User objektą");

            string[] userData = data[0].Split(new string[] { ", " }, StringSplitOptions.None);
            User user = new User(userData[0], userData[1]);
            
            for (int i = 1; i < data.Length; i++)
            {
                string[] passwordData = data[i].Split(new string[] { ", " }, StringSplitOptions.None);
                if (passwordData.Length != 4)
                    continue;

                PasswordEntry passwordEntry = new PasswordEntry(passwordData[0], passwordData[1], passwordData[2], passwordData[3]);
                user.AddPassword(passwordEntry);
            }
            return user;
        }
    }
}
