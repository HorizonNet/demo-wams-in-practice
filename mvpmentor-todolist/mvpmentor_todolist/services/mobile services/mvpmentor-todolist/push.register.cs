﻿using System;

using Newtonsoft.Json.Linq;

// http://go.microsoft.com/fwlink/?LinkId=290986&clcid=0x409

namespace mvpmentor_todolist
{
    internal class mvpmentor_todolistPush
    {
        public async static void UploadChannel()
        {
            var channel = await Windows.Networking.PushNotifications.PushNotificationChannelManager.CreatePushNotificationChannelForApplicationAsync();

            var token = Windows.System.Profile.HardwareIdentification.GetPackageSpecificToken(null);
            string installationId = Windows.Security.Cryptography.CryptographicBuffer.EncodeToBase64String(token.Id);

            var ch = new JObject();
            ch.Add("channelUri", channel.Uri);
            ch.Add("installationId", installationId);

            try
            {
                await App.MobileService.GetTable("channels").InsertAsync(ch);
            }
            catch (Exception exception)
            {
                HandleInsertChannelException(exception);
            }
        }

        private static void HandleInsertChannelException(Exception exception)
        {

        }
    }
}